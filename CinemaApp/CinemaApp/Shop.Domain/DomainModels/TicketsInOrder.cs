using System;
using System.ComponentModel.DataAnnotations.Schema;
using CinemaApp.Models;
using Shop.Domain.DomainModels;

namespace Shop.Domain.DomainModels
{
    public class TicketsInOrder : BaseEntity
    {
        [ForeignKey("ticketId")]
        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        public Order Order { get; set; }

    }
}