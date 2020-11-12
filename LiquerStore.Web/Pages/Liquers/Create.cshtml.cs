using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiquerStore.Web.Pages.Liquers
{
    public class CreateModel : PageModel
    {
        private readonly IStorage _db;

        public CreateModel(IStorage db)
        {
            _db = db;
        }

        [BindProperty] public StorageModel StorageModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            // Add the whisky to db
            _db.AddWhisky(StorageModel);

            return RedirectToPage("./Index");
        }
    }
}