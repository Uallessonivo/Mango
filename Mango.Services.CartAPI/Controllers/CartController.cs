using AutoMapper;
using Mango.Services.CartAPI.Data;
using Mango.Services.CartAPI.Models;
using Mango.Services.CartAPI.Models.Dtos;
using Mango.Services.CouponAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ResponseDto _response;
        private IMapper _mapper;
        private readonly AppDbContext _appDbContext;

        public CartController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpPost("CartUpsert")]
        public async Task<ResponseDto> CartUpsert(CartDto cartDto)
        {
            try
            {
                var cartHeaderFromDb = await _appDbContext.CartHeaders.FirstOrDefaultAsync(u => u.UserId == cartDto.CartHeader!.UserId);

                if (cartHeaderFromDb == null)
                {
                    // create header and details
                    CartHeader cartHeader = _mapper.Map<CartHeader>(cartDto.CartHeader);
                    _appDbContext.CartHeaders.Add(cartHeader);
                    _appDbContext.SaveChanges();

                    cartDto.CartDetails!.First().CartHeaderId = cartHeader.CartHeaderId;
                    _appDbContext.CartDetails.Add(_mapper.Map<CartDetails>(cartDto.CartDetails!.First()));
                    await _appDbContext.SaveChangesAsync();
                }
                else
                {
                    // if header is not null
                    // check if details has same product
                    var cartDetailsFromDb = await _appDbContext.CartDetails.
                        FirstOrDefaultAsync(u => u.ProductId == cartDto.CartDetails!.First().ProductId && u.CardHeaderId == cartHeaderFromDb.CartHeaderId);

                    if (cartDetailsFromDb == null)
                    {
                        // create cart details
                        cartDto.CartDetails!.First().CartHeaderId = cartHeaderFromDb.CartHeaderId;
                        _appDbContext.CartDetails.Add(_mapper.Map<CartDetails>(cartDto.CartDetails!.First()));
                        await _appDbContext.SaveChangesAsync();
                    }
                    else
                    {
                        // update count in cart details
                        cartDto.CartDetails!.First().Count += cartDetailsFromDb.Count;
                        cartDto.CartDetails!.First().CartHeaderId = cartDetailsFromDb.CardHeaderId;
                        cartDto.CartDetails!.First().CartDetailsId = cartDetailsFromDb.CartDetailsId;
                        _appDbContext.CartDetails.Update(_mapper.Map<CartDetails>(cartDto.CartDetails!.First()));
                        await _appDbContext.SaveChangesAsync();
                    }

                    _response.Result = cartDto;
                }
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }

            return _response;
        }
    }
}
