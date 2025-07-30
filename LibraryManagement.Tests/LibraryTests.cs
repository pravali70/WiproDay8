using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LibraryManagement;

namespace LibraryManagement.Tests
{
    [TestFixture]
    public class LibraryTests
    {
        private Library library;

        [SetUp]
        public void Setup()
        {
            library = new Library();
        }

        [Test]
        public void AddBook_ShouldAddBookToLibrary()
        {
            var book = new Book("C# Basics", "Author A", "123");
            library.AddBook(book);

            Assert.AreEqual(1, library.Books.Count);
            Assert.AreEqual("123", library.Books[0].ISBN);
        }

        [Test]
        public void RegisterBorrower_ShouldAddBorrowerToLibrary()
        {
            var borrower = new Borrower("John Doe", "CARD123");
            library.RegisterBorrower(borrower);

            Assert.AreEqual(1, library.Borrowers.Count);
            Assert.AreEqual("CARD123", library.Borrowers[0].LibraryCardNumber);
        }

        [Test]
        public void BorrowBook_ShouldMarkBookAsBorrowedAndAssignToBorrower()
        {
            var book = new Book("Book A", "Author A", "111");
            var borrower = new Borrower("Jane Doe", "CARD1");

            library.AddBook(book);
            library.RegisterBorrower(borrower);

            library.BorrowBook("111", "CARD1");

            Assert.IsTrue(book.IsBorrowed);
            Assert.AreEqual(1, borrower.BorrowedBooks.Count);
        }

        [Test]
        public void ReturnBook_ShouldMarkBookAsAvailableAndRemoveFromBorrower()
        {
            var book = new Book("Book B", "Author B", "222");
            var borrower = new Borrower("Mark Smith", "CARD2");

            library.AddBook(book);
            library.RegisterBorrower(borrower);
            library.BorrowBook("222", "CARD2");

            library.ReturnBook("222", "CARD2");

            Assert.IsFalse(book.IsBorrowed);
            Assert.AreEqual(0, borrower.BorrowedBooks.Count);
        }

        [Test]
        public void ViewBooks_ShouldReturnFormattedBookList()
        {
            library.AddBook(new Book("Book X", "Author X", "999"));

            var result = library.ViewBooks();

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result[0].Contains("Available"));
        }

        [Test]
        public void ViewBorrowers_ShouldReturnFormattedBorrowerList()
        {
            var borrower = new Borrower("Alice", "CARD9");
            library.RegisterBorrower(borrower);
            library.AddBook(new Book("Book Y", "Author Y", "888"));
            library.BorrowBook("888", "CARD9");

            var result = library.ViewBorrowers();

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result[0].Contains("Alice"));
            Assert.IsTrue(result[0].Contains("Book Y"));
        }
    }
}
