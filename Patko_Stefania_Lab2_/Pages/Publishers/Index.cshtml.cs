﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Patko_Stefania_Lab2_.Data;
using Patko_Stefania_Lab2_.Models;

namespace Patko_Stefania_Lab2_.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Patko_Stefania_Lab2_.Data.Patko_Stefania_Lab2_Context _context;

        public IndexModel(Patko_Stefania_Lab2_.Data.Patko_Stefania_Lab2_Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}