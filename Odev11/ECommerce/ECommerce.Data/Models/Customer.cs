using System;
using ECommerce.Data.Models.Abstract;

namespace ECommerce.Data.Models;

public class Customer : BaseClass
{
    public string FirstName {get;set;} = "";
    public string LastName {get;set;} = "";
    public string Email {get;set;} = "";
    public string City {get;set;} = "";

}
