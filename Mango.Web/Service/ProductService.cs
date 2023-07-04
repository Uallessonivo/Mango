using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service;

public class ProductService : IProductService
{
    private readonly IBaseService _baseService;

    public ProductService(IBaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<ResponseDto>? GetAllProductsAsync()
    {
        return await _baseService.SendAsync(new RequestDto
        {
            ApiType = Sd.ApiType.GET,
            Url = Sd.ProductAPIBase + "/api/Product"
        })!;
    }

    public async Task<ResponseDto>? GetProductByIdAsync(int id)
    {
        return await _baseService.SendAsync(new RequestDto
        {
            ApiType = Sd.ApiType.GET,
            Url = Sd.ProductAPIBase + "/api/Product/" + id
        })!;
    }

    public async Task<ResponseDto>? CreateProductsAsync(ProductDto ProductDto)
    {
        return await _baseService.SendAsync(new RequestDto
        {
            ApiType = Sd.ApiType.POST,
            Data = ProductDto,
            Url = Sd.ProductAPIBase + "/api/Product"
        })!;
    }

    public async Task<ResponseDto>? UpdateProductsAsync(ProductDto ProductDto)
    {
        return await _baseService.SendAsync(new RequestDto
        {
            ApiType = Sd.ApiType.PUT,
            Data = ProductDto,
            Url = Sd.ProductAPIBase + "/api/Product"
        })!;
    }

    public async Task<ResponseDto>? DeleteProductsAsync(int id)
    {
        return await _baseService.SendAsync(new RequestDto
        {
            ApiType = Sd.ApiType.DELETE,
            Url = Sd.ProductAPIBase + "/api/Product/" + id
        })!;
    }
}