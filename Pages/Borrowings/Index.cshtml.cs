using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Maya_Ciordas_Lab2.Data;
using Maya_Ciordas_Lab2.Models;

namespace Maya_Ciordas_Lab2.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly Maya_Ciordas_Lab2.Data.Maya_Ciordas_Lab2Context _context;

        public IndexModel(Maya_Ciordas_Lab2.Data.Maya_Ciordas_Lab2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                    .ThenInclude(b => b.Author)
                .Include(b => b.Member).ToListAsync();
        }
    }
}
