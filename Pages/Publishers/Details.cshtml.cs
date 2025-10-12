using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lese_Ioana_Lab2.Data;
using Lese_Ioana_Lab2.Models;

namespace Lese_Ioana_Lab2.Pages.Publishers
{
    public class DetailsModel : PageModel
    {
        private readonly Lese_Ioana_Lab2.Data.Lese_Ioana_Lab2Context _context;

        public DetailsModel(Lese_Ioana_Lab2.Data.Lese_Ioana_Lab2Context context)
        {
            _context = context;
        }

        public Publisher Publisher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);

            if (publisher is not null)
            {
                Publisher = publisher;

                return Page();
            }

            return NotFound();
        }
    }
}
