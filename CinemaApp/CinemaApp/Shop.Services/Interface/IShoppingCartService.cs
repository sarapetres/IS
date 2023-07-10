using Shop.Domain.Dto;

namespace Shop.Services.Interface;

public interface IShoppingCartService
{
    ShoppingCartDto getShoppingCartInfo(string userId);
    bool deleteProductFromSoppingCart(string userId, Guid productId);
}