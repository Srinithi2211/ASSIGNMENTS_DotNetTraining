using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPTask
{
    public class LibrarySystem
    {
        public void PerformBorrowBook(IUserActions user, string bookTitle)
        {
            user.BorrowBook(bookTitle);
        }

        public void PerformReturnBook(IUserActions user, string bookTitle)
        {
            user.ReturnBook(bookTitle);
        }

        public void PerformReserveBook(IUserActions user, string bookTitle)
        {
            user.ReserveBook(bookTitle);
        }

        public void PerformAddBook(IUserActions user, string bookTitle)
        {
            user.AddBook(bookTitle);
        }

        public void PerformRemoveBook(IUserActions user, string bookTitle)
        {
            user.RemoveBook(bookTitle);
        }
    }

}
