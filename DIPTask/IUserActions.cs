using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPTask
{
    public interface IUserActions
    {
        void BorrowBook(string bookTitle);
        void ReturnBook(string bookTitle);

        
        void ReserveBook(string bookTitle) { }
        void AddBook(string bookTitle) { }
        void RemoveBook(string bookTitle) { }
    }


}
