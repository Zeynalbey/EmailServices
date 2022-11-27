using Employees.Context;
using Employees.ViewModels;
using System.Reflection.Metadata;
using System;
using Employees.Service.Abstracts;

namespace Employees.Service.Concrets
{
    public class EmployeeService : IEmployeService
    {
        private readonly DataContext _dataContext;
        private const int MIN_VALUE = 10000;
        private const int MAX_VALUE = 100000;
        private const string PREFIXFORCODE = "E";

        public EmployeeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public string CreateCode()
        {
            string employeeCode = null;

            do
            {
                employeeCode = GenerateCode();

            } while (_dataContext.Employees.Any(e => e.Code == employeeCode));

            return employeeCode;
        }

        private string GenerateCode()
        {
            Random random = new Random();

            int num = random.Next(MIN_VALUE, MAX_VALUE);
            var blogCode = PREFIXFORCODE + num;
            return blogCode;
        }
    }
}
