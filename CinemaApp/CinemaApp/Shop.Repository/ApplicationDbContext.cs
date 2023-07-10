using CinemaApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.DomainModels;
using Shop.Domain.Identity;

namespace CinemaApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ShopAppUser>
    {
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketInShoppingCart> ticketInShoppingCarts { get; set; }

        public virtual DbSet<ShopAppUser> shopAppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TicketInShoppingCart>().HasKey(c => new { c.cartId, c.ticketId });
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}