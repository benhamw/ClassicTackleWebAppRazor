using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FlyrodWebAppRazor.Data;
using FlyrodWebAppRazor.Models;

namespace FlyrodWebAppRazor.Pages.Makers
{
    public class DeleteModel : PageModel
    {
        private readonly FlyrodWebAppRazor.Data.FlyrodWebAppRazorContext _context;

        public DeleteModel(FlyrodWebAppRazor.Data.FlyrodWebAppRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Maker Maker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Maker == null)
            {
                return NotFound();
            }

            var maker = await _context.Maker.FirstOrDefaultAsync(m => m.Id == id);

            if (maker == null)
            {
                return NotFound();
            }
            else 
            {
                Maker = maker;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Maker == null)
            {
                return NotFound();
            }
            var maker = await _context.Maker.FindAsync(id);

            if (maker != null)
            {
                Maker = maker;
                _context.Maker.Remove(Maker);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
