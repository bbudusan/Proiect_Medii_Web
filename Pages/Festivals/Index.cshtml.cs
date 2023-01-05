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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii.Data.Proiect_MediiContext _context;

        public IndexModel(Proiect_Medii.Data.Proiect_MediiContext context)
        {
            _context = context;
        }

        public IList<Festival> Festival { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Festival != null)
            {
                Festival = await _context.Festival
                .Include(f => f.Location)
                .Include(f => f.Producer).ToListAsync();
            }
        }
    }
}
