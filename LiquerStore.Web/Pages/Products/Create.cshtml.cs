using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiquerStore.Web.Pages.Products
{
    public class CreateModel : PageModel
    {
        // Get the interface
        private readonly IStorage _db;

        public CreateModel(IStorage db)
        {
            // Save the interface to this interface
            _db = db;
        }

        // Create a bindable variable to save the from return too
        [BindProperty] public StorageModel StorageModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            // If model is invalid, return a empty page
            if (!ModelState.IsValid) return Page();

            // Set reserved amount to zero
            StorageModel.Reserved = 0;

            // Add the whisky to db
            _db.AddWhisky(StorageModel);

            // Return to index
            return RedirectToPage("./Index");
        }
    }
}