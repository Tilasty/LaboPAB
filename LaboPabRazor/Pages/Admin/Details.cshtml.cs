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
    public class DetailsModel : PageModel
    {
        private readonly LaboPabRazor.Data.LaboPabRazorContext _context;

        public DetailsModel(LaboPabRazor.Data.LaboPabRazorContext context)
        {
            _context = context;
        }

        public Pages_Admin_Edit Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admin.FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }
            else
            {
                Admin = admin;
            }
            return Page();
        }
    }
}
