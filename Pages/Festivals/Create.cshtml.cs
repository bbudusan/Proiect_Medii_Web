using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PROIECT_MEDII.Models;
using Proiect_Medii.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Proiect_Medii.Pages.Festivals
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Proiect_Medii.Data.Proiect_MediiContext _context;

        public CreateModel(Proiect_Medii.Data.Proiect_MediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Name");
        ViewData["ProducerId"] = new SelectList(_context.Set<Producer>(), "Id", "FullName");
            return Page();
        }

        [BindProperty]
        public Festival Festival { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Festival.Add(Festival);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
