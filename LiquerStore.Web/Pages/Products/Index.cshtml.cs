using System.Collections.Generic;
using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiquerStore.Web.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IStorage _db;

        public IndexModel(IStorage db)
        {
            _db = db;
        }

        public IList<StorageModel> Products { get; set; }

        public void OnGet()
        {
            Products = _db.GetAllWhiskies();
        }
    }
}