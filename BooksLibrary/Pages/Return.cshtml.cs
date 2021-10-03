using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BooksLibrary.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksLibrary.Pages
{
    public class ReturnModel : PageModel
    {
        [Display(Name = "User name")]
        [BindProperty]
        [Required]
        public string UserName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Msg { get; set; }

        private readonly Library _library;
        public User user { get; set; }
        [Display(Name = "Book name")]
        [BindProperty]
        
        public string Book { get; set; }
        public ReturnModel(Library library)
        {
            _library = library;
        }
        public IEnumerable<SelectListItem> Items { get; set; } = new List<SelectListItem>();       
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            user = _library.FindUser(UserName);
            if (user != null&&Book==null)
            {
                foreach (var book in user.Books)
                    Items = Items.Append(new SelectListItem { Value = $"{book.Name}", Text = $"{book.Name}" });
                return Page();
            }
            else if(user!=null && Book != null)
            {
                Msg = _library.ReturnBook(Book, user.Name);
                LibraryData.Save("library", _library.LibraryModel);
                return RedirectToPage("return", new { Msg });
            }
            else
            {              
                Msg = $"The user {UserName} is not found.";
                return Page();
            }            
        }
    }
}
