using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LaboPabRazor.Models;

namespace LaboPabRazor.Data
{
    public class LaboPabRazorContext : DbContext
    {
        public LaboPabRazorContext (DbContextOptions<LaboPabRazorContext> options)
            : base(options)
        {
        }

        public DbSet<LaboPabRazor.Models.Admin> Admin { get; set; } = default!;
    }
}
