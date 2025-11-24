using System;


namespace ECommerce.Business.DTOs;

public class CustomerDto
{
    public int Id {get;set;}
    public string FirstName {get;set;} = "";
    public string LastName {get;set;} = "";
    public string Email {get;set;} = "";
    public string City {get;set;} = "";

}
