using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;

namespace RealEstateClient.Pages.AdminPage.RealEstatepage
{
    public class EditModel : PageModel
    {
        private readonly BusinessObject.BusinessObject.TheRealEstateDBContext _context;

        public EditModel(BusinessObject.BusinessObject.TheRealEstateDBContext context)
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

            var realestate =  await _context.RealEstates.FirstOrDefaultAsync(m => m.RealEstateID == id);
            if (realestate == null)
            {
                return NotFound();
            }
            RealEstate = realestate;
           ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RealEstate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealEstateExists(RealEstate.RealEstateID))
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

        private bool RealEstateExists(int id)
        {
          return (_context.RealEstates?.Any(e => e.RealEstateID == id)).GetValueOrDefault();
        }
    }
}
