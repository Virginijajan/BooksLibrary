using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.App
{
    public class User
    {
        public  string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        public string Message { get; set; }
        public User(string name)
        {
            Name = name;
           
        }
        public bool AddTheBookToList(Book book)
        {
            if (Books.Count < 5)
            {
                Books.Add(book);
                Message= $"{Name} have borrowed the book {book.Name}.";
                return true;
            }
            else
            {
                Message = "It is not allowed to borrow more than 5 books.";
                return false;
            }            
        }
        public bool ReturnBook(string name)
        {
            Book book = Books.Where(b => b.Name == name).Select(b => b).FirstOrDefault();                     
            return Books.Remove(book);
        }
    }
}
