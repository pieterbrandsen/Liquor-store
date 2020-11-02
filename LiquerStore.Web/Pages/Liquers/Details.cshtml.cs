using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LiquerStore.Web.Data;
using LiquorStore.DAL.Models;

namespace LiquerStore.Web.Pages.Liquers
{
    public class DetailsModel : PageModel
    {
        private readonly LiquerStore.Web.Data.ApplicationDbContext _context;

        public DetailsModel(LiquerStore.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public WhiskyModel WhiskyModel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WhiskyModel = await _context.Whiskies.FirstOrDefaultAsync(m => m.Id == id);

            if (WhiskyModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
