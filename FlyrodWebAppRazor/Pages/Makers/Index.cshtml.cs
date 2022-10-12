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
    public class IndexModel : PageModel
    {
        private readonly FlyrodWebAppRazor.Data.FlyrodWebAppRazorContext _context;

        public IndexModel(FlyrodWebAppRazor.Data.FlyrodWebAppRazorContext context)
        {
            _context = context;
        }

        public IList<Maker> Maker { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Maker != null)
            {
                Maker = await _context.Maker.OrderBy(m => m.Name).ToListAsync();
            }
        }
    }
}
