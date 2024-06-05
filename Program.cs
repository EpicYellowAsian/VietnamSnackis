using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VietnamSnackis.Data;
namespace VietnamSnackis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("VietnamSnackisContextConnection") ?? throw new InvalidOperationException("Connection string 'VietnamSnackisContextConnection' not found.");

            builder.Services.AddDbContext<VietnamSnackisContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<Areas.Identity.Data.VietnamSnackisUser>(options => 
            options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>() 
                .AddEntityFrameworkStores<VietnamSnackisContext>();

            builder.Services.AddAuthorization(options =>
            options.AddPolicy("AdminKrav", policy => policy.RequireRole("Admin")));

            // Add services to the container.
            // builder.Services.AddRazorPages(options => options.Conventions.AuthorizeFolder("/RoleAdmin", "AdminKrav"));
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
