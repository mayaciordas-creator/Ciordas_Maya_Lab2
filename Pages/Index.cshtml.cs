using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciordas_Maya_Lab2.Data;
using Ciordas_Maya_Lab2.Models;

namespace Ciordas_Maya_Lab2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Ciordas_Maya_Lab2.Data.Ciordas_Maya_Lab2Context _context;

        public IndexModel(Ciordas_Maya_Lab2.Data.Ciordas_Maya_Lab2Context context)
        {
            _context = context;
        }

        public IList<Authors> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Author.ToListAsync();
        }
    }
}
