using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiquerStore.Web.Pages.Products
{
    public class DisableModel : PageModel
    {
        // Get the interface
        private readonly IStorage _db;

        public DisableModel(IStorage db)
        {
            // Save the interface to this interface
            _db = db;
        }

        // Create a bindable variable to save the from return too
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

        public IActionResult OnPost(int? id)
        {
            // If no Id was inserted into the query string, return
            if (id == null) return NotFound();

            // Get the storage model based on id
            StorageModel = _db.GetWhiskyById(id);

            // If a model was found
            if (StorageModel != null)
            {
                // Set soft deleted to true
                StorageModel.SoftDeleted = true;

                // Update whisky in the DB
                _db.UpdateWhiskyByModel(StorageModel);
            }
            
            // Go back to pages
            return RedirectToPage("./Index");
        }
    }
}