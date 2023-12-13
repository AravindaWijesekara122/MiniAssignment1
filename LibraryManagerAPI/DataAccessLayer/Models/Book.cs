using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsBookAvailable { get; set; }
        public string Description { get; set; }
        public int? LentByUserId { get; set; }
        public int? CurrentlyBorrowedById { get; set; }
    }
}
