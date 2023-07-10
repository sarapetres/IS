using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CinemaApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.DomainModels;
using Shop.Domain.Dto;
using TicketApp.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketApp.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context){
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(z => z.Id == userId)
                .Include("UserShoppingCart.TicketInShoppingCart")
                .Include("UserShoppingCart.TicketInShoppingCart.Ticket")
                .Include("UserShoppingCart.TicketInShoppingCart.Ticket.Movie")
                .FirstOrDefault();

            var userShoppingCart = user.userCart;

            var ticketList = userShoppingCart.ticketInShoppingCarts.Select(z => new
            {
                Quantity = z.quantity,
                TicketPrice = z.ticket.price
            });

            int totalPrice = 0;
            foreach(var ticket in ticketList)
            {
                totalPrice += ticket.TicketPrice * ticket.Quantity;
            }

            ShoppingCartDto model = new ShoppingCartDto
            {
                TotalPrice = totalPrice,
                TicketsInShoppingCart = userShoppingCart.ticketInShoppingCarts.ToList()
            };

            return View(model);
        }

        public IActionResult DeleteFromShoppingCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(z => z.Id == userId)
                .Include("UserShoppingCart.TicketInShoppingCart")
                .Include("UserShoppingCart.TicketInShoppingCart.Ticket")
                .Include("UserShoppingCart.TicketInShoppingCart.Ticket.Movie")
                .FirstOrDefault();

            var userShoppingCart = user.userCart;
            var forRemoval = userShoppingCart.ticketInShoppingCarts.Where(z => z.Id == id).FirstOrDefault();
            userShoppingCart.ticketInShoppingCarts.Remove(forRemoval);
            _context.Update(userShoppingCart);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PayTickets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(z => z.Id == userId)
                .Include("UserShoppingCart.TicketInShoppingCart")
                .Include("UserShoppingCart.TicketInShoppingCart.Ticket")
                .Include("UserShoppingCart.TicketInShoppingCart.Ticket.Movie")
                .FirstOrDefault();

            var userShoppingCart = user.userCart;

            Order newOrder = new Order
            {
                UserId = user.Id,
                OrderedBy = user
            };

            List<TicketsInOrder> ticketsInOrders = userShoppingCart.ticketInShoppingCarts.Select(z => new TicketsInOrder
            {
                Ticket = z.ticket,
                TicketId = z.ticketId,
                Order = newOrder,
                OrderId = newOrder.orderId

            }).ToList();

            foreach(var item in ticketsInOrders)
            {
                _context.Add(item);
            }

            user.userCart.ticketInShoppingCarts.Clear();
            _context.Update(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}