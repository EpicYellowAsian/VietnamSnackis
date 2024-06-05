using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VietnamSnackis.Data;
using VietnamSnackis.Models;

namespace VietnamSnackis.Pages.SubCategoryAdmin
{
    public class DetailsModel : PageModel
    {
        private readonly VietnamSnackis.Data.VietnamSnackisContext _context;

        public DetailsModel(VietnamSnackis.Data.VietnamSnackisContext context)
        {
            _context = context;
        }

        public SubCategory SubCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategory = await _context.SubCategory.FirstOrDefaultAsync(m => m.Id == id);
            if (subcategory == null)
            {
                return NotFound();
            }
            else
            {
                SubCategory = subcategory;
            }
            return Page();
        }
    }
}
