using System.Collections.Generic;
using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiquerStore.Web.Pages.Products
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

        // Create a public list to use in the actual page
        public IList<StorageModel> Products { get; set; }

        public void OnGet()
        {
            // Get all products from db
            Products = _db.GetAllWhiskies();
        }
    }
}