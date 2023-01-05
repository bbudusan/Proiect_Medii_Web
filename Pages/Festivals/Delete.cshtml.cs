using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PROIECT_MEDII.Models;
using Proiect_Medii.Data;

namespace Proiect_Medii.Pages.Festivals
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Medii.Data.Proiect_MediiContext _context;

        public DeleteModel(Proiect_Medii.Data.Proiect_MediiContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Festival Festival { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Festival == null)
            {
                return NotFound();
            }

            var festival = await _context.Festival.FirstOrDefaultAsync(m => m.Id == id);

            if (festival == null)
            {
                return NotFound();
            }
            else 
            {
                Festival = festival;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Festival == null)
            {
                return NotFound();
            }
            var festival = await _context.Festival.FindAsync(id);

            if (festival != null)
            {
                Festival = festival;
                _context.Festival.Remove(Festival);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
