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
    public class IndexModel : PageModel
    {
        private readonly LiquerStore.Web.Data.ApplicationDbContext _context;

        public IndexModel(LiquerStore.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<WhiskyModel> WhiskyModel { get;set; }

        public async Task OnGetAsync()
        {
            WhiskyModel = await _context.Whiskies.ToListAsync();
        }
    }
}
