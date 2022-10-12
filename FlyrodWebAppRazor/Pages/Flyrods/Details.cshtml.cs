using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FlyrodWebAppRazor.Data;
using FlyrodWebAppRazor.Models;

namespace FlyrodWebAppRazor.Pages.Flyrods
{
    public class DetailsModel : PageModel
    {
        private readonly FlyrodWebAppRazor.Data.FlyrodWebAppRazorContext _context;

        public DetailsModel(FlyrodWebAppRazor.Data.FlyrodWebAppRazorContext context)
        {
            _context = context;
        }

      public Flyrod Flyrod { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Flyrod == null)
            {
                return NotFound();
            }

            var flyrod = await _context.Flyrod.Include(f => f.Maker).FirstOrDefaultAsync(m => m.Id == id);
            if (flyrod == null)
            {
                return NotFound();
            }
            else 
            {
                Flyrod = flyrod;
            }
            return Page();
        }
    }
}
