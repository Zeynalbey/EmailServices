using Employees.Emails.Models;
using Employees.EmployeeModels;
using Employees.Notification.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Employees.Context
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions options)
            :base(options)
        {

        }

        //public DbSet<NotificationModel> Notifications { get; set; }
        public DbSet<Employee> Employees { get; set; } 
        public DbSet<NotificationModel> Notifications { get; set; }

        public DbSet<TargetEmail> TargetEmails { get; set; }
      
    }
}
