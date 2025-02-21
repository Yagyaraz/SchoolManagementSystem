using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Rack
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class BookTye
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BookName { get; set; }

        public string ISBN { get; set; }

        public string BookNumber { get; set; }

        public string ClassNumber { get; set; }

        public List<string> Authors { get; set; } = new List<string>();

        public int Year { get; set; }

        public DateTime? PublishedDate { get; set; }

        public string PublishedLocation { get; set; }

        public int Pages { get; set; }

        public string Edition { get; set; }

        public string Language { get; set; }

        public int CountryId { get; set; } 

        public string MaterialType { get; set; }

        [Range(1, int.MaxValue)]
        public int Copies { get; set; } = 1;

        public bool CanIssue { get; set; }
    }
    public class BookIssue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; } 

        [Required]
        public DateTime DateIssued { get; set; }

        [Required]
        public int ReturnAfterDays { get; set; }

        public DateTime ReturnDate { get; set; }

        [Required]
        public int UserType { get; set; } 

        [Required]
        public int IssuedToId { get; set; }
    }
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int StudentName {  get; set; }
    }
    public class Keyword
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public bool Status { get; set; }
    }
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public bool Status { get; set; }
    }
}

