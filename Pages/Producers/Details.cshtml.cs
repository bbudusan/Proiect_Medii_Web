using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PROIECT_MEDII.Models;
using Proiect_Medii.Data;

namespace Proiect_Medii.Pages.Producers
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Medii.Data.Proiect_MediiContext _context;

        public DetailsModel(Proiect_Medii.Data.Proiect_MediiContext context)
        {
            _context = context;
        }

      public Producer Producer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Producer == null)
            {
                return NotFound();
            }

            var producer = await _context.Producer.FirstOrDefaultAsync(m => m.Id == id);
            if (producer == null)
            {
                return NotFound();
            }
            else 
            {
                Producer = producer;
            }
            return Page();
        }
    }
}
