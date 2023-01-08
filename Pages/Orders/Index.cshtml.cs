using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii.Data;
using Proiect_Medii.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Proiect_Medii.Pages.Users;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Proiect_Medii.Pages.Orders
{
    
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii.Data.Proiect_MediiContext _context;

        public IndexModel(Proiect_Medii.Data.Proiect_MediiContext context)
        {
            _context = context;

        }


        private readonly IHttpContextAccessor _httpContextAccessor;


        public IList<Order> Order { get;set; } = default!;


        public async Task OnGetAsync()
        { 


            if (_context.Order != null)
            {
                Order = await _context.Order
                .Include(o => o.Festival)
                .Include(o => o.User).ToListAsync();
            }
            
        }
    }
}
