using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace VietnamSnackis.Pages.RoleAdmin
{
    public class IndexModel : PageModel
    {
        public List<Areas.Identity.Data.VietnamSnackisUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }

        [BindProperty (SupportsGet =true)] 
        public string Rolename { get; set; }

        [BindProperty (SupportsGet = true)]
        public string AddUserId { get; set; }

        [BindProperty (SupportsGet = true)]
        public string RemoveUserId { get; set; }
        public bool IsUser { get; set; }
        public bool IsAdmin { get; set; }

        public readonly UserManager<Areas.Identity.Data.VietnamSnackisUser> _userManager;
        
        private readonly RoleManager<IdentityRole> _roleManager;
        public IndexModel(RoleManager<IdentityRole> roleManager, UserManager<Areas.Identity.Data.VietnamSnackisUser> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task OnGetAsync()
        {
            Roles = await _roleManager.Roles.ToListAsync();
            Users = await _userManager.Users.ToListAsync(); 

            if(AddUserId != null) // Lägga till en roll
            {
                var alterUser = await _userManager.FindByIdAsync(AddUserId);
                await _userManager.AddToRoleAsync(alterUser, Rolename); 
            }
            if(RemoveUserId != null) // Ta bort roll
            {
                var alterUser = await _userManager.FindByIdAsync(RemoveUserId);
                await _userManager.RemoveFromRoleAsync(alterUser, Rolename); 
            }

            var currentUser = await _userManager.GetUserAsync(User);
            
            if(currentUser != null)
            {
                IsUser = await _userManager.IsInRoleAsync(currentUser, "Användare");
                IsAdmin = await _userManager.IsInRoleAsync(currentUser, "Administratör");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(Rolename != null)
            {
                await CreateRole(Rolename);
            }
            return RedirectToPage("./Index"); 
        }
        public async Task CreateRole(string Rolename) // Skapa ny roll
        {
            bool roleExists = await _roleManager.RoleExistsAsync(Rolename);

            if(!roleExists)
            {
                var Role = new IdentityRole
                {
                    Name = Rolename
                };
                await _roleManager.CreateAsync(Role);  
            }
        }
    }
}
