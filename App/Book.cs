using BooksLibrary.App.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.App
{
    public class Book
    {
        public int Id { get; set; } =0;
        public  string Name { get; set; }
        public string Author { get; set; }
        public Categories Category { get; set; }
        public Languages Language { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; } = true;
        public DateTime DateBookIsTaken { get; set; }
        
        public bool AddName(string name)
        {
            if (name.Count() > 1&&  name.Count() < 50)
            {
                Name = name;
                return true;
            }
            else 
                return false;  
        }
        public bool AddAuthor(string author)
        {
            if (author.Count() > 1 && author.Count() < 25)
            {
                Author = author;
                return true;
            }
            else
                return false;
        }
        public bool AddCategory(string categoryString)
        {
            if (Enum.TryParse(categoryString, out Categories category))
            {
                Category = category;
                return true;
            }
            else return false;              
        }
        public bool AddLanguage(string languageString)
        {
            if (Enum.TryParse(languageString, out Languages language))
            {
                Language = language;
                return true;
            }
            else return false;
        }
        public bool AddPublicationDate(string publicationDateString)
        {
            
            if (DateTime.TryParse(publicationDateString, out DateTime publicationDate))
            {
                PublicationDate = publicationDate;
                return true;
            }
            else return false;
        }
        public bool AddISBN(string isbn)
        {
            if (isbn.Count() != 13)
                return false;

            if (long.TryParse(isbn, out long number))
            {
                ISBN = isbn;
                return true;
            }               
            else 
                return false;
        }
    }
}
