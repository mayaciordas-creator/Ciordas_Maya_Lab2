using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Maya_Ciordas_Lab2.Data;
using Maya_Ciordas_Lab2.Models;

namespace Maya_Ciordas_Lab2.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Maya_Ciordas_Lab2.Data.Maya_Ciordas_Lab2Context _context;

        public EditModel(Maya_Ciordas_Lab2.Data.Maya_Ciordas_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Borrowing == null)
            {
                return NotFound();
            }

            
            var bookList = _context.Book
                .Include(b => b.Author)
                .Select(x => new
                {
                    x.ID,
                    BookFullName = x.Title + " - " + x.Author.FirstName + " " + x.Author.LastName
                })
                .ToList();

            ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName", Borrowing.BookID);

            
            ViewData["MemberID"] = new SelectList(
                _context.Member
                    .AsEnumerable()
                    .Select(m => new
                    {
                        m.ID,
                        FullName = m.FirstName + " " + m.LastName
                    }),
                "ID",
                "FullName",
                Borrowing.MemberID
            );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingExists(Borrowing.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BorrowingExists(int id)
        {
            return _context.Borrowing.Any(e => e.ID == id);
        }
    }
}
