﻿using System;
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
        private readonly IStorage _db;

        public ReserveModel(IStorage db)
        {
            // Save the interface to this interface
            _db = db;
        }

        // Create a bindable variable to load on the page itself
        public StorageModel StorageModel { get; set; }

        public IActionResult OnGet(int? id)
        {
            // If no Id was inserted into the query string, return
            if (id == null) return NotFound();

            // Get a storagemodel based on id
            StorageModel = _db.GetWhiskyById(id);

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

            StorageModel = _db.GetWhiskyById(id);

            if (StorageModel != null)
            {
                if(StorageModel.Available > 0)
                {
                    StorageModel.Available--;
                    StorageModel.Reserved++;
                    _db.UpdateWhiskyByModel(StorageModel);
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
