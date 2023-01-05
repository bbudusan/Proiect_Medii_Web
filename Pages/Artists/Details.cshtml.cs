using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PROIECT_MEDII.Models;
using Proiect_Medii.Data;

namespace Proiect_Medii.Pages.Artists
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Medii.Data.Proiect_MediiContext _context;

        public DetailsModel(Proiect_Medii.Data.Proiect_MediiContext context)
        {
            _context = context;
        }

      public Artist Artist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Artist == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist.FirstOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }
            else 
            {
                Artist = artist;
            }
            return Page();
        }
    }
}
