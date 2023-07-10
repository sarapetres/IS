using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Data;
using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Shop.Domain.DomainModels;
using Shop.Services.Interface;

namespace CinemaApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ITicketService _ticketService;

        public MoviesController(IMovieService movieService, ITicketService ticketService)
        {
            _movieService = movieService;
            _ticketService = ticketService;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
              return View(_movieService.GetAllMovies());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _movieService.GetDetailsForMovie(id ?? 0);

            if (movie == null)
            {
                return NotFound();
            }

            var tickets = _ticketService.GetTicketsForMovie(movie.Id);
            movie.Tickets = tickets;

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            _movieService.CreateNewMovie(movie);
            return RedirectToAction("Index");
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _movieService.GetDetailsForMovie(id ?? 0);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            _movieService.UpdateExistingMovie(movie);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _movieService.GetDetailsForMovie(id??0);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _movieService.DeleteMovie(id);
            return RedirectToAction("Index");
        }

        private bool MovieExists(int id)
        {
            return _movieService.GetDetailsForMovie(id) != null;
        }
    }
}
