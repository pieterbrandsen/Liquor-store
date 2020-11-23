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
    public class DetailsModel : PageModel
    {
        private readonly IWhisky _db;

        public DetailsModel(IWhisky db)
        {
            _db = db;
        }

        public WhiskyModel WhiskyModel { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WhiskyModel = _db.GetWhiskyById(id);

            if (WhiskyModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
