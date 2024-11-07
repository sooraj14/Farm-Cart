using FarmSquare.Data.dbcontext;
using Microsoft.EntityFrameworkCore;

namespace FarmCart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
<<<<<<< HEAD
            builder.Services.AddSession();
           
=======
>>>>>>> V0-LP

            // Configure database context with SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
                options.UseSqlServer(connectionString);
            });

            // Add session services
            builder.Services.AddDistributedMemoryCache();  // Add in-memory cache for session
            builder.Services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true; // Secure cookie
                options.Cookie.IsEssential = true; // Ensure session cookie is set for non-authenticated users
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. Change this for production if needed.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
<<<<<<< HEAD
=======

            // Enable session middleware
>>>>>>> V0-LP
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
