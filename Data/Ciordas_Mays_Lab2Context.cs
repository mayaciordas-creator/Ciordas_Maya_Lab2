using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Maya_Ciordas_Lab2.Models;

namespace Maya_Ciordas_Lab2.Data
{
    public class Maya_Ciordas_Lab2Context : DbContext
    {
        public Maya_Ciordas_Lab2Context (DbContextOptions<Maya_Ciordas_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Maya_Ciordas_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Maya_Ciordas_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Maya_Ciordas_Lab2.Models.Author> Authors { get; set; } = default!;
        public DbSet<Maya_Ciordas_Lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Maya_Ciordas_Lab2.Models.Member> Member { get; set; } = default!;
        public DbSet<Maya_Ciordas_Lab2.Models.Borrowing> Borrowing { get; set; } = default!;

    }
}
