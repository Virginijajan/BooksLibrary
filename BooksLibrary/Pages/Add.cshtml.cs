using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BooksLibrary.App;
using BooksLibrary.App.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksLibrary.Pages
{
    public class AddModel : PageModel
    {
        private readonly Library _library;
        private readonly Book _book;
        public AddModel(Library library, Book book)
        {
            _library = library;
            _book = book;                     
        }
        
        [BindProperty]
        public InputModel Input { get; set; }
        [BindProperty (SupportsGet =true)]
        public string Msg { get; set; } = "";

        public void OnGet()
        {          
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            _book.Name = Input.Name;
            _book.Author = Input.Author;
            _book.Category = Input.Category;
            _book.Language = Input.Language;
            _book.PublicationDate = Input.PublicationDate;
            _book.ISBN = Input.ISBN;      
            Msg = _library.AddBook(_book);
            LibraryData.Save("library", _library.LibraryModel);           
            return RedirectToPage("add", new { Msg = Msg });
        }
        public class InputModel
        {
            [Required]
            [StringLength(50, ErrorMessage = "Max length is 50 characters")]         
            public string Name { get; set; }
            [Required]
            [StringLength(25, ErrorMessage = "Max length is 25 characters")]           
            public string Author { get; set; }
            [Required]
            public Categories Category { get; set; }
            [Required]
            public Languages Language { get; set; }
            [Required]
            [Display(Name = "Publication date")]           
            [DataType(DataType.Date)]
            public DateTime PublicationDate { get; set; } = DateTime.Now;
            [Required]
            [MinLength(13, ErrorMessage = "Length is 13 characters")]
            [MaxLength(13, ErrorMessage = "Length is 13 characters")]
            public string ISBN { get; set; }
        }
    }
}
