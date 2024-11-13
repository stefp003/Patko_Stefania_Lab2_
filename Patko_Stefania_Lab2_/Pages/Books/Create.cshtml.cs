﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Patko_Stefania_Lab2_.Data;
using Patko_Stefania_Lab2_.Models;


namespace Patko_Stefania_Lab2_.Pages.Books
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : BookCatgoriesPageModel
    {
        private readonly Patko_Stefania_Lab2_.Data.Patko_Stefania_Lab2_Context _context;

        public CreateModel(Patko_Stefania_Lab2_.Data.Patko_Stefania_Lab2_Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
            "PublisherName");
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID",
            "FullName");
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories )
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            Book.BookCategories = newBook.BookCategories;
            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        //if (!ModelState.IsValid)
        //{
        //     return Page();
        //}

        // _context.Book.Add(Book);
        // await _context.SaveChangesAsync();

        // return RedirectToPage("./Index");
    }
    }
