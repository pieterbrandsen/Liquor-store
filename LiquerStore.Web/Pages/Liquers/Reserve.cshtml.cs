using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LiquerStore.DAL.Models;
using LiquerStore.DAL.Services.DbCommands;

namespace LiquerStore.Web.Pages.Liquers
{
    public class ReserveModel : PageModel
    {
        private readonly IStorage _db;

        public ReserveModel(IStorage db)
        {
            _db = db;
        }

        public StorageModel StorageModel { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StorageModel = _db.GetWhiskyById(id);

            if (StorageModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
