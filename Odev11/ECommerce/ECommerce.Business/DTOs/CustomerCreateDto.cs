using System;
using System.ComponentModel.DataAnnotations;


namespace ECommerce.Business.DTOs;

public class CustomerCreateDto
{ 
    [Required(ErrorMessage ="Müşteri Adı Zorunludur!")]
    public string? FirstName {get;set;}

    [Required(ErrorMessage ="Müşteri Soyadı Zorunludur!")]
    public string? LastName {get;set;}

    [Required(ErrorMessage = "E-Mail Alanı Zorunludur!")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-mail adresi giriniz!")]
    public string? Email { get; set; }

    [Required(ErrorMessage ="Şehir Alanı Zorunludur!")]
    public string? City {get;set;}
   

    


}
