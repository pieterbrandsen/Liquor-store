using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LiquerStore.DAL.Models;
using LiquerStore.DAL;

namespace LiquerStore.Web.Pages.Liquers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<WhiskyModel> WhiskyModel { get; set; }

        public async Task OnGetAsync()
        {
            WhiskyModel = await _context.Whiskies.ToListAsync();
        }
    }
}
