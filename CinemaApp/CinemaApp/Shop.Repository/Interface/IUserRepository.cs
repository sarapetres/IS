
using Shop.Domain.Identity;

namespace Shop.Repository.Interface;

public interface IUserRepository
{

    IEnumerable<ShopAppUser> GetAll();
    ShopAppUser Get(string id);
    void Insert(ShopAppUser entity);
    void Update(ShopAppUser entity);
    void Delete(ShopAppUser entity);

}