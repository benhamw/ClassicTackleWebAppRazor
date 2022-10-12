using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlyrodWebAppRazor.Data;
using FlyrodWebAppRazor.Models;

namespace FlyrodWebAppRazor.Pages.Flyrods
{
    public class EditModel : PageModel
    {
        private readonly FlyrodWebAppRazor.Data.FlyrodWebAppRazorContext _context;

        public EditModel(FlyrodWebAppRazor.Data.FlyrodWebAppRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Flyrod Flyrod { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Flyrod == null)
            {
                return NotFound();
            }

            var flyrod =  await _context.Flyrod.FirstOrDefaultAsync(m => m.Id == id);
            if (flyrod == null)
            {
                return NotFound();
            }
            Flyrod = flyrod;
           ViewData["MakerId"] = new SelectList(_context.Maker, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Attach(Flyrod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlyrodExists(Flyrod.Id))
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

        private bool FlyrodExists(int id)
        {
          return _context.Flyrod.Any(e => e.Id == id);
        }
    }
}
