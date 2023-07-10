using System.ComponentModel.DataAnnotations;
using Shop.Domain.DomainModels;
using Shop.Domain.Identity;

namespace Shop.Domain.DomainModels;

public class Order : BaseEntity
{
    
        [Key]
        public int orderId { get; set; }

        public string UserId { get; set; }

        public ShopAppUser OrderedBy { get; set; }

        public List<TicketsInOrder> TicketsInOrder { get; set; }
        
}