using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LiquerStore.DAL.Models;
using LiquerStore.DAL;
using LiquerStore.DAL.Services.DbCommands;

namespace LiquerStore.Web.Pages.Liquers
{
    public class EnableModel : PageModel
    {
        private readonly IWhisky _db;

        public EnableModel(IWhisky db)
        {
            _db = db;
        }

        [BindProperty]
        public StorageModel StorageModel { get; set; }

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StorageModel = await _context.Storages.FirstOrDefaultAsync(m => m.Whisky.Id == id);
            WhiskyModel = _db.GetWhiskyById(id);

            if (StorageModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StorageModel = await _context.Storages.FindAsync(id);
            WhiskyModel = _db.GetWhiskyById(id);

            if (StorageModel != null)
            {
                StorageModel.Whisky.SoftDeleted = false;
                _context.Storages.Update(StorageModel);
                await _context.SaveChangesAsync();

                WhiskyModel.SoftDeleted = false;
                _db.UpdateWhiskyByModel(WhiskyModel);
            }

            return RedirectToPage("./Index");
        }
    }
}
