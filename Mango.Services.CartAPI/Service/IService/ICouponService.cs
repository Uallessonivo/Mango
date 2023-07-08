using Mango.Services.CartAPI.Models.Dtos;

namespace Mango.Services.CartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
