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
    public class FilterModel : PageModel
    {
        [BindProperty (SupportsGet =true)]
        [Display(Name = "Filter by")]
        public FilterBy Filter { get; set; } = FilterBy.All;
        [BindProperty]
        public Categories? Category { get; set; } = null;
        [BindProperty]
        public Languages? Language { get; set; } = null;

        [Display(Name = "Enter parameter")]
        [BindProperty (SupportsGet = true)]
        public string Param { get; set; }

        public void OnGet()
        {
            Page();
        }
        public IActionResult OnPost()
        {
            if (Filter == FilterBy.Category)
            {
                if (Category == null)
                    return RedirectToPage("filter", new { Filter = Filter });
                else
                    return RedirectToPage("list", new { Filter = Filter, Param = Category.ToString() });
            }
            if (Filter == FilterBy.Language)
            {
                if (Language == null)
                    return RedirectToPage("filter", new { Filter = Filter });
                else

                    return RedirectToPage("list", new { Filter = Filter, Param = Language.ToString() });
            }
            if (Filter != FilterBy.Taken && Filter != FilterBy.Available && Filter != FilterBy.All)
            {
                if (Param == null)
                    return RedirectToPage("Filter", new { Filter = Filter });
                else
                    return RedirectToPage("list", new { Filter = Filter, Param = Param });
            }
            else
                return RedirectToPage("list", new { Filter = Filter, Param = "" });
        }
    }
}
