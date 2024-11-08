using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Patko_Stefania_Lab2_.Data;
using Patko_Stefania_Lab2_.Models;

namespace Patko_Stefania_Lab2_.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Patko_Stefania_Lab2_.Data.Patko_Stefania_Lab2_Context _context;

        public EditModel(Patko_Stefania_Lab2_.Data.Patko_Stefania_Lab2_Context context)
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

            var borrowing =  await _context.Borrowing
                .Include(b=>b.Book)
                    .ThenInclude(book => book.Author)
                .Include(b=>b.Member)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            Borrowing = borrowing;
            ViewData["BookID"] = new SelectList(_context.Book.Include(b => b.Author)  .Select(b => new{b.ID,DisplayText = b.Title + " by " + b.Author.FullName}),"ID","DisplayText");
            ViewData["MemberID"] = new SelectList(_context.Member.Select(m => new { m.ID, FullName = m.FirstName + ' ' + m.LastName }), "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
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
