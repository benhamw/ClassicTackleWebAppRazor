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
    public class IndexModel : PageModel
    {
        private readonly FlyrodWebAppRazor.Data.FlyrodWebAppRazorContext _context;

        public IndexModel(FlyrodWebAppRazor.Data.FlyrodWebAppRazorContext context)
        {
            _context = context;
        }

        public IList<Flyrod> Flyrod { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Flyrod != null)
            {
                Flyrod = await _context.Flyrod
                .Include(f => f.Maker).OrderBy(f => f.Maker.Name).ToListAsync();
            }
        }
    }
}
