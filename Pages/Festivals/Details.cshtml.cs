using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PROIECT_MEDII.Models;
using Proiect_Medii.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proiect_Medii.Pages.Festivals
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Medii.Data.Proiect_MediiContext _context;

        public DetailsModel(Proiect_Medii.Data.Proiect_MediiContext context)
        {
            _context = context;
        }
      

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
    }
}
