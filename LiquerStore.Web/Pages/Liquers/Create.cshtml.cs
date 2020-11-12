using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;

namespace LiquerStore.Web.Pages.Liquers
{
    public class CreateModel : PageModel
    {
        private readonly IStorage _db;

        public CreateModel(IStorage db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StorageModel StorageModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            StorageModel.Reserved = 0;

            // Add the whisky to db
            _db.AddWhisky(StorageModel);

            return RedirectToPage("./Index");
        }
    }
}
