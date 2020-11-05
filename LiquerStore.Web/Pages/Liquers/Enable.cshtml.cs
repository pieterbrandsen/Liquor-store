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
    public class EnableModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EnableModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StorageModel StorageModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StorageModel = await _context.Storages.FirstOrDefaultAsync(m => m.Whisky.Id == id);

            if (StorageModel == null)
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

            StorageModel = await _context.Storages.FindAsync(id);

            if (StorageModel != null)
            {
                StorageModel.Whisky.SoftDeleted = false;
                _context.Storages.Update(StorageModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
