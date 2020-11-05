using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LiquerStore.DAL.Models;
using LiquerStore.DAL;

namespace LiquerStore.Web.Pages.Liquers
{
    public class DisableModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DisableModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WhiskyModel WhiskyModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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
                WhiskyModel.SoftDeleted = true;
                _context.Whiskies.Update(WhiskyModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
