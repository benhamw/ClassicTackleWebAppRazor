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
    public class DetailsModel : PageModel
    {
        private readonly FlyrodWebAppRazor.Data.FlyrodWebAppRazorContext _context;

        public DetailsModel(FlyrodWebAppRazor.Data.FlyrodWebAppRazorContext context)
        {
            _context = context;
        }

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
    }
}
