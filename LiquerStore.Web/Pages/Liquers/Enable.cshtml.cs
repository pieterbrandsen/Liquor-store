using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LiquerStore.DAL.Models;
using LiquerStore.DAL;
using LiquerStore.DAL.Services.DbCommands;

namespace LiquerStore.Web.Pages.Liquers
{
    public class EnableModel : PageModel
    {
        private readonly IWhisky _db;

        public EnableModel(IWhisky db)
        {
            _db = db;
        }

        [BindProperty]
        public WhiskyModel WhiskyModel { get; set; }

        public IActionResult OnGetAsync(int? id)
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
                WhiskyModel.SoftDeleted = false;
                _db.UpdateWhiskyByModel(WhiskyModel);
            }

            return RedirectToPage("./Index");
        }
    }
}
