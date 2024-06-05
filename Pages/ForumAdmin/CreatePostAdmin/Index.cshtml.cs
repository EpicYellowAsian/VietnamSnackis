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
    public class IndexModel : PageModel
    {
        private readonly VietnamSnackis.Data.VietnamSnackisContext _context;

        public IndexModel(VietnamSnackis.Data.VietnamSnackisContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Post = await _context.CreatePost
                .Include(p => p.User).ToListAsync();
        }
    }
}
