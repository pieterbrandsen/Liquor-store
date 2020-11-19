using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;

namespace LiquerStore.Web.Pages.Reserve
{
    public class ReserveModel : PageModel
    {
        // Get the interface
        private readonly IStorage _storage;
        private readonly IOrder _order;
        private readonly IUser _user;

        public ReserveModel(IStorage storage, IOrder order, IUser user)
        {
            // Save the interface to this interface
            _storage = storage;
            _order = order;
            _user = user;
        }

        // Create a bindable variable to load on the page itself
        public StorageModel StorageModel { get; set; }

        public IActionResult OnGet(int? id)
        {
            // If no Id was inserted into the query string, return
            if (id == null) return NotFound();

            // Get a storagemodel based on id
            StorageModel = _storage.GetWhiskyById(id);

            // If no storage model was found, return
            if (StorageModel == null) return NotFound();
            else return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StorageModel = _storage.GetWhiskyById(id);

            if (StorageModel != null)
            {
                if(StorageModel.Available > 0)
                {
                    StorageModel.Available--;
                    StorageModel.Reserved++;
                    _storage.UpdateWhiskyByModel(StorageModel);

                    OrderModel orderModel = new OrderModel();
                    orderModel.Completed = false;
                    orderModel.Customer = _user.GetUserByName(User.Identity.Name);
                    orderModel.Whisky = StorageModel.Whisky;

                    _order.AddOrder(orderModel);
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
