using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;

namespace LiquerStore.Web.Pages.Liquers
{
    public class EditModel : PageModel
    {
        private readonly IWhisky _db;

        public EditModel(IWhisky db)
        {
            _db = db;
        }

        [BindProperty]
        public WhiskyModel WhiskyModel { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WhiskyModel = _db.GetWhiskyById(id);

            if (WhiskyModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.UpdateWhiskyByModel(WhiskyModel);

            return RedirectToPage("./Index");
        }
    }
}
