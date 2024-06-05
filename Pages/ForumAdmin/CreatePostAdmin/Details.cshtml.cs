using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VietnamSnackis.Data;
using VietnamSnackis.Models;

namespace VietnamSnackis.Pages.ForumAdmin.CreatePostAdmin
{
    public class DetailsModel : PageModel
    {
        private readonly VietnamSnackis.Data.VietnamSnackisContext _context;

        public DetailsModel(VietnamSnackis.Data.VietnamSnackisContext context)
        {
            _context = context;
        }

        public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.CreatePost.FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            else
            {
                Post = post;
            }
            return Page();
        }
    }
}
