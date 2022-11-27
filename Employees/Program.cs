
using Employees.Context;
using Employees.EmployeeModels;
using Employees.Service.Abstracts;
using Employees.Service.Concrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using WebApi.Services;

namespace Employees
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            

            var builder = WebApplication.CreateBuilder(args);
            builder.Services
                .AddDbContext<DataContext>(o =>
                o.UseSqlServer("Server=DESKTOP-4V8H535;Database=AllEmployees;Trusted_Connection=True;TrustServerCertificate=True;"))
                .AddScoped<IEmployeService, EmployeeService>()
                .AddScoped<IEmailService, EmailService>()
                .AddMvc()
                .AddControllersAsServices();
            


            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}");
            app.Run();


        }
    }
}