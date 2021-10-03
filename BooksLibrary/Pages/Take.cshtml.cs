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
    public class TakeModel : PageModel
    {
        private readonly Library _library;
        public TakeModel(Library library)
        {
            _library = library;
        }       

        [Required]
        [BindProperty]
        [Display (Name ="Users name")]
        public string UserName { get; set; }
        [BindProperty (SupportsGet =true)]
        [Required]
        public string BookToTake { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Msg { get; set; }
        public void OnGet()
        {
            Page();           
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return RedirectToPage("take", new { BookToTake = BookToTake, Msg="Users neme is requared" });               
            _library.TakeBook(BookToTake, UserName);
            LibraryData.Save("library", _library.LibraryModel);
            return RedirectToPage("list", new {Msg= _library.Message});
        }       
    }
}
