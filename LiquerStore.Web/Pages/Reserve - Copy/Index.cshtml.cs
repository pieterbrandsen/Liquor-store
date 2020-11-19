using System.Collections.Generic;
using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiquerStore.Web.Pages.Reserve
{
    public class IndexModel : PageModel
    {
        // Get the interface
        private readonly IStorage _db;

        public IndexModel(IStorage db)
        {
            // Save the interface to this interface
            _db = db;
        }

        // Create a bindable variable to load on the page itself
        public IList<StorageModel> ProductsActive { get; set; }

        public void OnGet()
        {
            // Get all active products from DB
            ProductsActive = _db.GetAllActiveWhiskies();
        }
    }
}