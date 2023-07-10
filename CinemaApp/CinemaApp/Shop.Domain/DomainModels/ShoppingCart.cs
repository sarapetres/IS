using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.DomainModels
{
    public class ShoppingCart:BaseEntity
    {
        [Key]
        public int cartId { get; set; }

        public string appliicationUserId { get; set; }

        public ICollection<TicketInShoppingCart> ticketInShoppingCarts { get; set; }
    }
}
