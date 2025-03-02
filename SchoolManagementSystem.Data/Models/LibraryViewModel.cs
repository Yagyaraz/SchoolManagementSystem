using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class RackViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class BookTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class BookViewModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public string BookNumber { get; set; }
        public string ClassNumber { get; set; }
        public int Year { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string PublishedLocation { get; set; }
        public int Pages { get; set; }
        public string Edition { get; set; }
        public string Language { get; set; }
        public int CountryId { get; set; }
        public string MaterialType { get; set; }
        public int Copies { get; set; } = 1;
        public bool CanIssue { get; set; }
        public List<AuthorViewModel> AuthorList { get; set; }= new List<AuthorViewModel>();
        public List<KeywordViewModel> KeywordList { get; set; }=new List<KeywordViewModel>();
    }
    public class BookIssueViewModel
    {

        public int Id { get; set; }
        public int BookId { get; set; }
        public DateTime DateIssued { get; set; }
        public int ReturnAfterDays { get; set; }
        public DateTime ReturnDate { get; set; }
        public int UserType { get; set; }
        public int IssuedToId { get; set; }
    }
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }
        public int StudentName { get; set; }
    }
    public class KeywordViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BookId { get; set; }
        public bool Status { get; set; }
    }
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BookId { get; set; }
        public bool Status { get; set; }
    }
}   



