using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ciordas_Maya_Lab2.Models;

namespace Ciordas_Maya_Lab2.Data
{
    public class Ciordas_Maya_Lab2Context : DbContext
    {
        public DbSet<Author> Author { get; set; }

        public Ciordas_Maya_Lab2Context (DbContextOptions<Ciordas_Maya_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Ciordas_Maya_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Ciordas_Maya_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    }
}
