using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiquerStore.Web.Pages.Order
{
    public class DetailsModel : PageModel
    {
        // Get the interface
        private readonly IOrder _db;

        public DetailsModel(IOrder db)
        {
            // Save the interface to this interface
            _db = db;
        }

        // Create a bindable variable to load on the page itself
        public OrderModel OrderModel { get; set; }

        public IActionResult OnGet(int? id)
        {
            // If no Id was inserted into the query string, return
            if (id == null) return NotFound();

            // Get a OrderModel based on id
            OrderModel = _db.GetOrderById(id);

            // If no storage model was found, return
            if (OrderModel == null) return NotFound();
            else return Page();
        }
    }
}