using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BooksLibrary.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksLibrary.Pages
{   
    public class UserModel : PageModel
    {
        [Display(Name = "User name")]
        [BindProperty]
        [Required]
        public string UserName { get; set; }
        [BindProperty (SupportsGet = true)]
        public string Msg { get; set; }
        public List<User> Users { get; set; } = new List<User>();

        private readonly Library _library;
        public UserModel(Library library)
        {
            _library = library;
        }
        public void OnGet()
        {
            Users = _library.LibraryModel.Users;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            _library.RegisterUser(UserName);
            LibraryData.Save("library", _library.LibraryModel);
            return RedirectToPage("User", new { Msg=_library.Message});
        }
        public IActionResult OnPostDelete(string UserToDelete)
        {
            Msg=_library.DeleteUser(UserToDelete);
            LibraryData.Save("library", _library.LibraryModel);
            return RedirectToPage("User", new { Msg = Msg });
        }
    }
}
