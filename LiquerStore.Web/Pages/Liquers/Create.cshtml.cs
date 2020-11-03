using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LiquerStore.Web.Data;
using LiquerStore.DAL.Models;

namespace LiquerStore.Web.Pages.Liquers
{
    public class CreateModel : PageModel
    {
        private readonly LiquerStore.Web.Data.ApplicationDbContext _context;

        public CreateModel(LiquerStore.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WhiskyModel WhiskyModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Whiskies.Add(WhiskyModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
