using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiquerStore.Web.Pages.Products
{
    public class UpdateAmountModel : PageModel
    {
        // Get the interface
        private readonly IStorage _db;

        public UpdateAmountModel(IStorage db)
        {
            // Save the interface to this interface
            _db = db;
        }

        // Create a bindable variable to load on the page itself
        [BindProperty] public StorageModel StorageModel { get; set; }

        public IActionResult OnGet(int? id)
        {
            // If no Id was inserted into the query string, return
            if (id == null) return NotFound();

            // Get a storagemodel based on id
            StorageModel = _db.GetWhiskyById(id);

            // If no storage model was found, return
            if (StorageModel == null) return NotFound();
            else return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            // If model is invalid, return a empty page
            if (!ModelState.IsValid) return Page();

            // Update whisky based on storage model
            _db.UpdateWhiskyByModel(StorageModel);

            // Return to index
            return RedirectToPage("./Index");
        }
    }
}