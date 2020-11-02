﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiquerStore.Web.Data;
using LiquorStore.DAL.Models;

namespace LiquerStore.Web.Pages.Liquers
{
    public class EditModel : PageModel
    {
        private readonly LiquerStore.Web.Data.ApplicationDbContext _context;

        public EditModel(LiquerStore.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WhiskyModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WhiskyModelExists(WhiskyModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WhiskyModelExists(string id)
        {
            return _context.Whiskies.Any(e => e.Id == id);
        }
    }
}