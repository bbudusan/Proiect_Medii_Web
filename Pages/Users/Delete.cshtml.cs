﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii.Data;
using Proiect_Medii.Models;

namespace Proiect_Medii.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Medii.Data.Proiect_MediiContext _context;

        public DeleteModel(Proiect_Medii.Data.Proiect_MediiContext context)
        {
            _context = context;
        }

        [BindProperty]
      public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FirstOrDefaultAsync(m => m.ID == id);

            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                User = user;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }
            var user = await _context.User.FindAsync(id);

            if (user != null)
            {
                User = user;
                _context.User.Remove(User);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
