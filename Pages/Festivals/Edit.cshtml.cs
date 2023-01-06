using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROIECT_MEDII.Models;
using Proiect_Medii.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Proiect_Medii.Pages.Festivals
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Proiect_Medii.Data.Proiect_MediiContext _context;

        public EditModel(Proiect_Medii.Data.Proiect_MediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Festival Festival { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Festival == null)
            {
                return NotFound();
            }

            var festival =  await _context.Festival.FirstOrDefaultAsync(m => m.Id == id);
            if (festival == null)
            {
                return NotFound();
            }
            Festival = festival;
           ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Name");
           ViewData["ProducerId"] = new SelectList(_context.Set<Producer>(), "Id", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Festival).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FestivalExists(Festival.Id))
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

        private bool FestivalExists(int id)
        {
          return _context.Festival.Any(e => e.Id == id);
        }
    }
}
