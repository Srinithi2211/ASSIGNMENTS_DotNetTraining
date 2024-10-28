using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPTask
{
    public class Student : IUserActions
    {
        public void BorrowBook(string bookTitle)
        {
            Console.WriteLine($"Student borrowed the book: {bookTitle}");
        }

        public void ReturnBook(string bookTitle)
        {
            Console.WriteLine($"Student returned the book: {bookTitle}");
        }
    }
    public class Teacher : IUserActions
    {
        public void BorrowBook(string bookTitle)
        {
            Console.WriteLine($"Teacher borrowed the book: {bookTitle}");
        }

        public void ReturnBook(string bookTitle)
        {
            Console.WriteLine($"Teacher returned the book: {bookTitle}");
        }

        public void ReserveBook(string bookTitle)
        {
            Console.WriteLine($"Teacher reserved the book: {bookTitle}");
        }
    }
    public class Librarian : IUserActions
    {
        public void BorrowBook(string bookTitle)
        {
            Console.WriteLine($"Librarian borrowed the book: {bookTitle}");
        }

        public void ReturnBook(string bookTitle)
        {
            Console.WriteLine($"Librarian returned the book: {bookTitle}");
        }

        public void AddBook(string bookTitle)
        {
            Console.WriteLine($"Librarian added the book: {bookTitle}");
        }

        public void RemoveBook(string bookTitle)
        {
            Console.WriteLine($"Librarian removed the book: {bookTitle}");
        }
    }

}
