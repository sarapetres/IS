
using Microsoft.AspNetCore.Identity;
using Shop.Domain.DomainModels;

namespace Shop.Domain.Identity
{
    public class ShopAppUser:IdentityUser
    {
        public string name { get; set; }

        public string surname { get; set; }

        public virtual ShoppingCart userCart { get; set; }  
    }
}
