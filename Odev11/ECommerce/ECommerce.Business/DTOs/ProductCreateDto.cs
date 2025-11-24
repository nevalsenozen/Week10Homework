using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Business.DTOs;

public class ProductCreateDto
{
    [Required(ErrorMessage = "Ürün adı zorunludur!")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Fiyat zorunludur!")]
    [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır!")]
    public decimal Price { get; set; }


    [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı negatif olamaz!")]
    public int StockQuantity { get; set; }
}