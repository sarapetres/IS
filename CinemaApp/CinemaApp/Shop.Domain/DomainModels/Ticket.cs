using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Domain.DomainModels;

namespace Shop.Domain.DomainModels
{
    public class Ticket:BaseEntity
    {
     
        [Required]
        public int price { get; set; }
        [Required]
        public DateTime dateTime { get; set; }
        [Required]
        public string nameVenue { get; set; }

        [ForeignKey("movieId")]
        public int movieId { get; set; }
        public required Movie movie { get; set; }    

        public ICollection<TicketInShoppingCart> ticketInShoppingCarts { get; set;}
    }
}
