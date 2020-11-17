using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiquerStore.Web.Pages.Products
{
    public class EnableModel : PageModel
    {
        private readonly IStorage _db;

        public EnableModel(IStorage db)
        {
            _db = db;
        }

        [BindProperty] public StorageModel StorageModel { get; set; }

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            StorageModel = _db.GetWhiskyById(id);

            if (StorageModel == null) return NotFound();
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null) return NotFound();

            StorageModel = _db.GetWhiskyById(id);

            if (StorageModel != null)
            {
                StorageModel.SoftDeleted = false;
                _db.UpdateWhiskyByModel(StorageModel);
            }

            return RedirectToPage("./Index");
        }
    }
}