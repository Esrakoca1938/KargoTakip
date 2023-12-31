using System.Text.Json.Serialization;
using KargoTakip.WebUI.Helper;
using KargoTakip.WebUI.WebUI.Middleware;
namespace KargoTakip
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();
            //builder.Services.AddAntiforgery(x=>x.HeaderName ="XSRF-TOKEN");

            var app = builder.Build();
            AppHttpContext.ServiceProvider = app.Services;
            app.UseGlobalExceptionMiddleware();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.UseSessionNullCheckMiddleware();
            app.Run();
        }
    }
}