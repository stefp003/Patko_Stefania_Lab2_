using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Patko_Stefania_Lab2_.Data;
using Patko_Stefania_Lab2_.Models;

namespace Patko_Stefania_Lab2_.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly Patko_Stefania_Lab2_.Data.Patko_Stefania_Lab2_Context _context;

        public IndexModel(Patko_Stefania_Lab2_.Data.Patko_Stefania_Lab2_Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                    .ThenInclude(b =>b.Author)
                .Include(b => b.Member).ToListAsync();
        }
    }
}
