using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaboPabRazor.Data;
using LaboPabRazor.Models;

namespace LaboPabRazor.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly LaboPabRazor.Data.LaboPabRazorContext _context;

        public IndexModel(LaboPabRazor.Data.LaboPabRazorContext context)
        {
            _context = context;
        }

        public IList<Admin> Admin { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Admin = await _context.Admin.ToListAsync();
        }
    }
}
