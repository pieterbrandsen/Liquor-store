using System.Collections.Generic;
using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiquerStore.Web.Pages.Liquers
{
    public class IndexModel : PageModel
    {
        private readonly IStorage _db;

        public IndexModel(IStorage db)
        {
            _db = db;
        }

        public IList<StorageModel> StorageModels { get; set; }

        public void OnGet()
        {
            StorageModels = _db.GetAllWhiskies();
        }
    }
}