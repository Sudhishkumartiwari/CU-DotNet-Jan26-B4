using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DashBoard.Data;
namespace DashBoard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DashBoardContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DashBoardContext") ?? throw new InvalidOperationException("Connection string 'DashBoardContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Company}/{action=Dashboard}/{id?}");

            app.Run();
        }
    }
}
