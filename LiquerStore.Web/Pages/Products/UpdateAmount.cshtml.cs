using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiquerStore.Web.Pages.Products
{
    public class UpdateAmountModel : PageModel
    {
        private readonly IStorage _db;

        public UpdateAmountModel(IStorage db)
        {
            _db = db;
        }

        [BindProperty] public StorageModel StorageModel { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null) return NotFound();

            StorageModel = _db.GetWhiskyById(id);

            if (StorageModel == null) return NotFound();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _db.UpdateWhiskyByModel(StorageModel);

            return RedirectToPage("./Index");
        }
    }
}