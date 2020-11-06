using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;

namespace LiquerStore.Web.Pages.Liquers
{
    public class CreateModel : PageModel
    {
        private readonly IWhisky _db;

        public CreateModel(IWhisky db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WhiskyModel WhiskyModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

<<<<<<< HEAD
            _context.Whiskies.Add(WhiskyModel);
            await _context.SaveChangesAsync();
=======
            // Add the whisky to db
            _db.AddWhisky(WhiskyModel);
>>>>>>> 6bc1b819e61852b14cac22341fe29c094497294f

            return RedirectToPage("./Index");
        }
    }
}
