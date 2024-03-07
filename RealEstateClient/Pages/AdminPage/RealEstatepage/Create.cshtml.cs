using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.BusinessObject;

namespace RealEstateClient.Pages.AdminPage.RealEstatepage
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObject.BusinessObject.TheRealEstateDBContext _context;

        public CreateModel(BusinessObject.BusinessObject.TheRealEstateDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email");
            return Page();
        }

        [BindProperty]
        public RealEstate RealEstate { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.RealEstates == null || RealEstate == null)
            {
                return Page();
            }

            _context.RealEstates.Add(RealEstate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
