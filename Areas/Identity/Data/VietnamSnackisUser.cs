using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VietnamSnackis.Areas.Identity.Data;

// Add profile data for application users by adding properties to the VietnamSnackisUser class
public class VietnamSnackisUser : IdentityUser
{
    [PersonalData]
    public string Firstname { get; set; }

    [PersonalData]
    public string Lastname { get; set; }

    [PersonalData]
    public string Nickname { get; set; }
    public bool IsAdmin  { get; set; }
    public string? ProfilePicture { get; set; } 
}

