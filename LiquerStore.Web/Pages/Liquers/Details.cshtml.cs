using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiquerStore.Web.Pages.Liquers
{
    public class DetailsModel : PageModel
    {
        private readonly IStorage _db;

        public DetailsModel(IStorage db)
        {
            _db = db;
        }

        public StorageModel StorageModel { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null) return NotFound();

            StorageModel = _db.GetWhiskyById(id);

            if (StorageModel == null) return NotFound();
            return Page();
        }
    }
}