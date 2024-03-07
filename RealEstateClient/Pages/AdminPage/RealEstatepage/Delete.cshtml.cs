using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;

namespace RealEstateClient.Pages.AdminPage.RealEstatepage
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObject.BusinessObject.TheRealEstateDBContext _context;

        public DeleteModel(BusinessObject.BusinessObject.TheRealEstateDBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public RealEstate RealEstate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.RealEstates == null)
            {
                return NotFound();
            }

            var realestate = await _context.RealEstates.FirstOrDefaultAsync(m => m.RealEstateID == id);

            if (realestate == null)
            {
                return NotFound();
            }
            else 
            {
                RealEstate = realestate;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.RealEstates == null)
            {
                return NotFound();
            }
            var realestate = await _context.RealEstates.FindAsync(id);

            if (realestate != null)
            {
                RealEstate = realestate;
                _context.RealEstates.Remove(RealEstate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
