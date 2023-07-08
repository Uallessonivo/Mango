using Mango.Services.CartAPI.Models.Dtos;

namespace Mango.Services.CartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
