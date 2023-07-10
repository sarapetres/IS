using System.ComponentModel.DataAnnotations.Schema;
using Shop.Domain.DomainModels;

namespace Shop.Domain.DomainModels
{
    public class TicketInShoppingCart: BaseEntity
    {
        public int ticketId { get; set; }

        public int cartId { get; set; }

        [ForeignKey("ticketId")]
        public Ticket ticket { get; set; }

        [ForeignKey("cartId")]
        public ShoppingCart cart { get; set; }

        public int quantity { get; set; }
    }
}
