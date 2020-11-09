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
        private readonly IStorage _db;

        public EnableModel(IStorage db)
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

            StorageModel = _db.GetWhiskyById(id);

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

            StorageModel = _db.GetWhiskyById(id);
            
            if (StorageModel != null)
            {
                StorageModel.Whisky.SoftDeleted = false;
                _db.UpdateWhiskyByModel(StorageModel);
            }

            return RedirectToPage("./Index");
        }
    }
}
