using System;
using ECommerce.Business.DTOs;
using ECommerce.Business.DTOs.ResponseDtos;
using ECommerce.Data.Models;

namespace ECommerce.Business.Abstract;

public interface IProductService
{
    Task<ResponseDto<ProductDto>> GetProductByIdAsync(int id);
    Task<ResponseDto<IEnumerable<ProductDto>>> GetAllProductsAsync();
    Task<ResponseDto<IEnumerable<ProductDto>>> GetLowStockProductsAsync(int threshold);
    Task<ResponseDto<ProductDto>> CreateProductAsync(ProductCreateDto productCreateDto);
    Task<ResponseDto<NoContent>> UpdateProductAsync(int id, ProductUpdateDto productUpdateDto);
    Task<ResponseDto<NoContent>> DeleteProductAsync(int id);
    
}
