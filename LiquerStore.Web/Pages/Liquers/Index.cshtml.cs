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
    public class IndexModel : PageModel
    {
        private readonly IWhisky _db;

        public IndexModel(IWhisky db)
        {
            _db = db;
        }

        public IList<WhiskyModel> WhiskyModel { get;set; }

        public void OnGet()
        {
            WhiskyModel = _db.GetAllWhiskies();
        }
    }
}
