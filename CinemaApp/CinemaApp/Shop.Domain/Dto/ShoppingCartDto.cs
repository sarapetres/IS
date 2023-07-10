using Shop.Domain.DomainModels;

namespace Shop.Domain.Dto;

public class ShoppingCartDto
{
    public List<TicketInShoppingCart> TicketsInShoppingCart { get; set; }
    public int TotalPrice { get; set; }
}