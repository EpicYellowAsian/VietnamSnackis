using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VietnamSnackis.Data;
using VietnamSnackis.Models;

namespace VietnamSnackis.Pages.ForumAdmin.CreatePostAdmin
{
    public class CreateModel : PageModel
    {
        private readonly VietnamSnackis.Data.VietnamSnackisContext _context;

        public CreateModel(VietnamSnackis.Data.VietnamSnackisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Användarnamn");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; } = default!;
        public List<Models.Post> CreatePost { get; set; }
        public List<Models.Category> Categories { get; set; }  

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CreatePost.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
