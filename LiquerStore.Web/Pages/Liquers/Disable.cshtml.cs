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
    public class DisableModel : PageModel
    {
        private readonly IWhisky _db;

        public DisableModel(IWhisky db)
        {
            _db = db;
        }

        [BindProperty]
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

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WhiskyModel = _db.GetWhiskyById(id);

            if (WhiskyModel != null)
            {
                WhiskyModel.SoftDeleted = true;
                _db.UpdateWhiskyByModel(WhiskyModel);
            }

            return RedirectToPage("./Index");
        }
    }
}
