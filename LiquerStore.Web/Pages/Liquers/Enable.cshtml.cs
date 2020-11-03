using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LiquerStore.Web.Data;
using LiquerStore.DAL.Models;

namespace LiquerStore.Web.Pages.Liquers
{
    public class EnableModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EnableModel(LiquerStore.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WhiskyModel WhiskyModel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WhiskyModel = await _context.Whiskies.FirstOrDefaultAsync(m => m.Id == id);

            if (WhiskyModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WhiskyModel = await _context.Whiskies.FindAsync(id);

            if (WhiskyModel != null)
            {
                WhiskyModel.SoftDeleted = false;
                _context.Whiskies.Update(WhiskyModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
