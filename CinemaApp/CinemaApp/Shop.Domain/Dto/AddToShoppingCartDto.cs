using Microsoft.Build.ObjectModelRemoting;
using Shop.Domain.DomainModels;

namespace Shop.DomainModels.Dto
{
    public class AddToShoppingCartDto
    {
        public Ticket selectedTicket { get; set; }

        public int ticketId { get; set; }   

        public int quantity { get; set; }
    }
}
