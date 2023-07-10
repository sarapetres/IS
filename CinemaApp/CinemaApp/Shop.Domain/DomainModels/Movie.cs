using System.ComponentModel.DataAnnotations;
using Shop.Domain.DomainModels;

namespace Shop.Domain.DomainModels
{
    public class Movie : BaseEntity
    {
        
        [Required]
        public string titleMovie { get; set; }
        [Required]
        public string descriptionMovie { get; set; }
        [Required]
        public DateTime yearRelease { get; set; }
        [Required]
        public string moviePoster { get; set; }
        [Required]
        public string genre { get; set; }

        public virtual ICollection<Ticket>? Tickets { get; set; }

    }
}
