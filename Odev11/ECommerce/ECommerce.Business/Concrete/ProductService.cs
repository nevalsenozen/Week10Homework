using System;
using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Business.DTOs;
using ECommerce.Business.DTOs.ResponseDtos;
using ECommerce.Data.Abstract;
using ECommerce.Data.Models;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Business.Concrete;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDto<ProductDto>> CreateProductAsync(ProductCreateDto productCreateDto)
    {
        try

        {

            var existingProduct = await _unitOfWork.Products
                .FindAsync(p => p.Name.Equals(productCreateDto.Name, StringComparison.CurrentCultureIgnoreCase));

            if (existingProduct.Any())
            {
                return ResponseDto<ProductDto>.Fail(
                    $"'{productCreateDto.Name}' isimli bir ürün zaten mevcut!",
                    StatusCodes.Status400BadRequest
                );
            }


            if (productCreateDto.Price <= 0 || productCreateDto.Price > 300_000)
            {
                return ResponseDto<ProductDto>.Fail(
                    $"Ürün fiyatı geçerli bir değer olmalıdır! (0 < Fiyat ≤ 300.000)",
                    StatusCodes.Status400BadRequest
                );
            }

            {
                var product = _mapper.Map<Product>(productCreateDto);

                await _unitOfWork.Products.AddAsync(product);

                var result = await _unitOfWork.CompleteAsync();

                if (result < 1)
                {
                    return ResponseDto<ProductDto>.Fail("Veri tabanından kaynaklı bir hata oluştuğu için, kaydetme işlemi yapılamadı!", StatusCodes.Status500InternalServerError);
                }

                var productDto = _mapper.Map<ProductDto>(product);

                return ResponseDto<ProductDto>.Success(productDto, StatusCodes.Status201Created);
            }
        }
        catch (Exception ex)
        {
            return ResponseDto<ProductDto>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDto<NoContent>> DeleteProductAsync(int id)
    {
        try
        {
            var deletedProduct = await _unitOfWork.Products.GetByIdAsync(id);
            if (deletedProduct == null)
            {
                return ResponseDto<NoContent>.Fail($"{id} id'li ürün bulunamadığı için silme işlemi gerçekleştirilemedi!", StatusCodes.Status404NotFound);
            }

            _unitOfWork.Products.Remove(deletedProduct);
            var result = await _unitOfWork.CompleteAsync();

            if (result < 1)
            {
                return ResponseDto<NoContent>.Fail("Ürün silinmeye çalışılırken, veri tabanından kaynaklı bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }

            return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDto<IEnumerable<ProductDto>>> GetAllProductsAsync()
    {
        try
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            if (!products.Any())
            {
                return ResponseDto<IEnumerable<ProductDto>>.Fail("Hiç ürün bulunamadı!", StatusCodes.Status404NotFound);
            }
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return ResponseDto<IEnumerable<ProductDto>>.Success(productDtos, StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDto<IEnumerable<ProductDto>>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }

    }

    public async Task<ResponseDto<IEnumerable<ProductDto>>> GetLowStockProductsAsync(int threshold)
    {
        var products = await _unitOfWork.Products.GetLowStockProductsAsync(threshold);
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        return null;
    }

    public async Task<ResponseDto<ProductDto>> GetProductByIdAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product != null)
        {
            var productDto = _mapper.Map<ProductDto>(product);

            return ResponseDto<ProductDto>.Success(productDto, 200);
        }
        return null;

    }

    public async Task<ResponseDto<NoContent>> UpdateProductAsync(int id, ProductUpdateDto productUpdateDto)
    {
        try
        {
            if (id != productUpdateDto.Id)
            {
                return ResponseDto<NoContent>.Fail("Id bilgileri tutarsız!", StatusCodes.Status400BadRequest);
            }

            var updatedProduct = await _unitOfWork.Products.GetByIdAsync(id);

            if (updatedProduct == null)
            {
                return ResponseDto<NoContent>.Fail($"{id} id'li ürün bulunamadığı için, güncelleme işlemi yapılamadı.", StatusCodes.Status404NotFound);
            }

            _mapper.Map(productUpdateDto, updatedProduct);

            _unitOfWork.Products.Update(updatedProduct);

            var result = await _unitOfWork.CompleteAsync();

            if (result < 1)
            {
                return ResponseDto<NoContent>.Fail("Ürün güncellenirken, veri tabanından kaynaklı bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }

            return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }
    }
}
