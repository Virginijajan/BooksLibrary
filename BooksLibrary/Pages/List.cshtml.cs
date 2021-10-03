using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BooksLibrary.App;
using BooksLibrary.App.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksLibrary.Pages
{
    public class ListModel : PageModel
    {
        private readonly Library _library;
        public ListModel(Library library)
        {
            _library = library;           
        }

        [BindProperty(SupportsGet = true)]
        [Display(Name = "Filter by")]
        public FilterBy Filter { get; set; } = FilterBy.All;
        [Display(Name = "Enter parameter")]
        [BindProperty(SupportsGet = true)]
        public string Param { get; set; }
       
        [BindProperty (SupportsGet =true)]
        public string Msg { get; set; }
        public List<Book> books = new List<Book>();
        public ActionResult OnGet()
        {
            books = _library.GetList($"{Filter.ToString()} {Param}");
            return Page();            
        }
        public IActionResult OnPost(string BookToDelete)
        {
            if (!ModelState.IsValid)
                Page();
            Msg= _library.DeleteBook(BookToDelete);
            LibraryData.Save("library", _library.LibraryModel);
            return RedirectToAction("List", new { Msg=Msg});
        }
    }
}
