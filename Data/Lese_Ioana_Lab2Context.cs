using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lese_Ioana_Lab2.Models;

namespace Lese_Ioana_Lab2.Data
{
    public class Lese_Ioana_Lab2Context : DbContext
    {
        public Lese_Ioana_Lab2Context (DbContextOptions<Lese_Ioana_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Lese_Ioana_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Lese_Ioana_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Lese_Ioana_Lab2.Models.Author> Authors { get; set; } = default!;

    }
}
