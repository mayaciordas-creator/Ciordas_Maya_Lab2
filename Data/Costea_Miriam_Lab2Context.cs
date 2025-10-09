using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Costea_Miriam_Lab2.Models;

namespace Costea_Miriam_Lab2.Data
{
    public class Costea_Miriam_Lab2Context : DbContext
    {
        public Costea_Miriam_Lab2Context (DbContextOptions<Costea_Miriam_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Costea_Miriam_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Costea_Miriam_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Costea_Miriam_Lab2.Models.Author> Author { get; set; } = default!;
    }
}
