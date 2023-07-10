using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Data;
using CinemaApp.Models;
using System.Security.Claims;
using Shop.Domain.DomainModels;
using Shop.DomainModels.Dto;
using Shop.Services.Interface;

namespace CinemaApp.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IMovieService _movieService;
        
        public TicketsController(ITicketService ticketService, IMovieService movieService)
        {
            _ticketService = ticketService;
            _movieService = movieService;
        }
      

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            return View(_ticketService.GetAllTickets());
        }


        public async Task<IActionResult> AddToCart(int ticketId)
        {
            var ticket = _ticketService.GetDetailsForTicket(ticketId);

            var model = new AddToShoppingCartDto();
            model.selectedTicket = ticket;
            model.ticketId = ticket.Id;
            model.quantity = 0;

            return View(model);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id??0);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            var movies = _movieService.GetAllMovies();
            ViewBag.MovieId = new SelectList(movies, "Id", "Title");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            _ticketService.CreateNewTicket(ticket);
            return RedirectToAction("Index");
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id ?? 0);
            if (ticket == null)
            {
                return NotFound();
            }
            //ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", ticket.MovieId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            _ticketService.UpdateExistingTicket(ticket);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id??0);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _ticketService.DeleteTicket(id);
            return RedirectToAction("Index");
        }

        private bool TicketExists(int id)
        {
            return _ticketService.GetDetailsForTicket(id) != null;
        }
        
        
    }
}
