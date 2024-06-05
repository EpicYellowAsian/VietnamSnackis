using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VietnamSnackis.Pages
{
    [Authorize (Roles = "Admin")]
    public class AdminPageModel : PageModel
    {
        public bool IsAdmin { get; set; }
        public bool IsUser { get; set; } 
        public void OnGet()
        {
        }
    }
}
