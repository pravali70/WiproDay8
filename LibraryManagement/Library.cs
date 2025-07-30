using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Borrower> Borrowers { get; set; } = new List<Borrower>();

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RegisterBorrower(Borrower borrower)
        {
            Borrowers.Add(borrower);
        }

        public void BorrowBook(string isbn, string libraryCardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);

            if (book == null) throw new Exception("Book not found.");
            if (borrower == null) throw new Exception("Borrower not found.");

            borrower.BorrowBook(book);
        }

        public void ReturnBook(string isbn, string libraryCardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);

            if (book == null) throw new Exception("Book not found.");
            if (borrower == null) throw new Exception("Borrower not found.");

            borrower.ReturnBook(book);
        }

        public List<string> ViewBooks()
        {
            return Books.Select(b => $"{b.Title} by {b.Author} - ISBN: {b.ISBN} - {(b.IsBorrowed ? "Borrowed" : "Available")}").ToList();
        }

        public List<string> ViewBorrowers()
        {
            return Borrowers.Select(b => $"{b.Name} - Card: {b.LibraryCardNumber} - Books: {string.Join(", ", b.BorrowedBooks.Select(bb => bb.Title))}").ToList();
        }
    }
}
