using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesRental.Infrastructure.Models
{
    public class Rental
    {
        public int id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int RentalStatusId { get; set; }
        public RentalStatus RentalStatus { get; set; }

        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public TimeSpan Difference { get
            {
                
                return DateTime.Now.Subtract(RentalDate);
            } }

    }
}
