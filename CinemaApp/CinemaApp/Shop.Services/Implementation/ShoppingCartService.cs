using Shop.Domain.DomainModels;
using Shop.Domain.Dto;
using Shop.Repository.Interface;
using Shop.Services.Interface;

namespace Shop.Services.Implementation;

public class ShoppingCartService : IShoppingCartService
{

    private readonly IRepository<ShoppingCart> _shoppingCartRepository;
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<TicketsInOrder> _ticketInOrderRepository;
    private readonly IUserRepository _userRepository;


    public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IUserRepository userRepository,
        IRepository<Order> orderRepository, IRepository<TicketsInOrder> ticketInOrderRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _userRepository = userRepository;
        _orderRepository = orderRepository;
        _ticketInOrderRepository = ticketInOrderRepository;
    }


    public bool deleteProductFromSoppingCart(string userId, Guid productId)
    {
        if (!string.IsNullOrEmpty(userId) && productId != null)
        {
            var loggedInUser = this._userRepository.Get(userId);

            var userShoppingCart = loggedInUser.userCart;

            var itemToDelete = userShoppingCart.ticketInShoppingCarts.Where(z => z.ticketId.Equals(productId)).FirstOrDefault();

            userShoppingCart.ticketInShoppingCarts.Remove(itemToDelete);

            this._shoppingCartRepository.Update(userShoppingCart);

            return true;
        }

        return false;
    }

    public ShoppingCartDto getShoppingCartInfo(string userId)
    {
        if (!string.IsNullOrEmpty(userId))
        {
            var loggedInUser = this._userRepository.Get(userId);

            var userCard = loggedInUser.userCart;

            var allTickets = userCard.ticketInShoppingCarts.ToList();

            var allProductPrices = allTickets.Select(z => new
            {
                ProductPrice = z.ticket.price,
                Quantity = z.quantity
            }).ToList();
            
            int totalPrice = 0;

            foreach (var item in allProductPrices)
            {
                totalPrice += item.Quantity * item.ProductPrice;
            }

            var reuslt = new ShoppingCartDto
            {
                TicketsInShoppingCart = allTickets,
                TotalPrice = totalPrice
            };

            return reuslt;
        }

        return new ShoppingCartDto();
    }

}