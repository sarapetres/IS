using Shop.Domain.DomainModels;
using Shop.Services.Interface;
using Shop.Domain.Dto;

namespace Shop.Services.Interface;

public interface ITicketService
{
    public bool AddToShoppingCart(ShoppingCartDto item, string userID);

    public void CreateNewTicket(Ticket t);

    public void DeleteTicket(int id);

    public List<Ticket> GetAllTickets();

    public Ticket GetDetailsForTicket(int id);

    public ShoppingCartDto GetShoppingCartInfo(int id);

    public void UpdateExistingTicket(Ticket t);
    
    public List<Ticket> GetTicketsForMovie(int id);
}