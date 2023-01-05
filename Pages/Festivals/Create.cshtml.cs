using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PROIECT_MEDII.Models;
using Proiect_Medii.Data;

namespace Proiect_Medii.Pages.Festivals
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Medii.Data.Proiect_MediiContext _context;

        public CreateModel(Proiect_Medii.Data.Proiect_MediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Description");
        ViewData["ProducerId"] = new SelectList(_context.Set<Producer>(), "Id", "Bio");
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
