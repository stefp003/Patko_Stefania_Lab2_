using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Patko_Stefania_Lab2_.Models;

namespace Patko_Stefania_Lab2_.Data
{
    public class Patko_Stefania_Lab2_Context : DbContext
    {
        public Patko_Stefania_Lab2_Context (DbContextOptions<Patko_Stefania_Lab2_Context> options)
            : base(options)
        {
        }

        public DbSet<Patko_Stefania_Lab2_.Models.Book> Book { get; set; } = default!;
        public DbSet<Patko_Stefania_Lab2_.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Patko_Stefania_Lab2_.Models.Author> Author { get; set; } = default!;
    }
}
