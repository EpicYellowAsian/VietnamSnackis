using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VietnamSnackis.Pages
{
    public class IndexModel : PageModel
    {
        public Areas.Identity.Data.VietnamSnackisUser MyUser { get; set; }
        private UserManager<Areas.Identity.Data.VietnamSnackisUser> _userManager { get; set; }
        public IndexModel(UserManager<Areas.Identity.Data.VietnamSnackisUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            MyUser = await _userManager.GetUserAsync(User); 
        }
    }
}
