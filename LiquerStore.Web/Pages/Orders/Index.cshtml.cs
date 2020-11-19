using System.Collections.Generic;
using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiquerStore.Web.Pages.Order
{
    public class IndexModel : PageModel
    {
        // Get the interface
        private readonly IOrder _db;

        public IndexModel(IOrder db)
        {
            // Save the interface to this interface
            _db = db;
        }

        // Create a bindable variable to load on the page itself
        public IList<StorageModel> OrdersActive { get; set; }

        public void OnGet()
        {
            // Get all active orders from DB
            OrdersActive = _db.GetAllActive();
        }
    }
}