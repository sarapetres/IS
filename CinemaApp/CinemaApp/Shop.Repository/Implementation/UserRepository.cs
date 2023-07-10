using CinemaApp.Data;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Identity;
using Shop.Repository.Interface;

namespace Shop.Repository.Implementation;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext context;
    private DbSet<ShopAppUser> entities;
    string errorMessage = string.Empty;

    public UserRepository(ApplicationDbContext context)
    {
        this.context = context;
        entities = context.Set<ShopAppUser>();
    }
    public IEnumerable<ShopAppUser> GetAll()
    {
        return entities.AsEnumerable();
    }

    public ShopAppUser Get(string id)
    {
        return entities
            .Include(z => z.userCart)
            .Include("userCart.ticketInShoppingCarts")
            .Include("userCart.ticketInShoppingCarts.ticket")
            .SingleOrDefault(s => s.Id == id);
    }
    
    public void Insert(ShopAppUser entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Add(entity);
        context.SaveChanges();
    }

    public void Update(ShopAppUser entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Update(entity);
        context.SaveChanges();
    }

    public void Delete(ShopAppUser entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Remove(entity);
        context.SaveChanges();
    }
}