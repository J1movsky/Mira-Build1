using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Mira.Service;


namespace Mira
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // подключение конфигурацию из appseting.json
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();
            var section = config.GetSection(nameof(Project));
            var project= section.Get<Project>();


            app.UseHttpsRedirection();

            // Подключение статичных файлов (css,js и т.д.)
            app.UseStaticFiles();

            
            app.UseRouting();

            // Подключение авторизации
            app.UseAuthorization();

            // Регистрация нужных маршрутов (ендпоинты)
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}