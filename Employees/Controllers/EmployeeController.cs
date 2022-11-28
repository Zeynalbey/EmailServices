
using Employees.Context;
using Employees.EmployeeModels;
using Employees.Service.Abstracts;
using Employees.ViewModels;
using Employees.ViewModels.Update;
using Microsoft.AspNetCore.Mvc;
using Employees.Service.Concrets;
using Notification.ViewModel;
using Employees.Notification.Models;
using Employees.Emails.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Services;

namespace Employees.Controllers
{
    [Route("employee")]
    public class EmployeeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IEmployeService _createCode;
        private readonly IEmailService _emailService;
        private readonly string _emailSender = "zeynaleg@code.edu.az";
        public EmployeeController(DataContext dataContext, IEmployeService createCode, IEmailService emailService)
        {
            _createCode = createCode;
            _dataContext = dataContext;
            _emailService = emailService;

        }
        

        #region Read

        [HttpGet("home", Name = "employee-home")]
        public IActionResult Home()
        {
            var model = _dataContext.Employees.Where(b => b.IsDeleted == false)
                .Select(b => new ListViewModel(b.FirstName, b.LastName, b.FatherName, b.Fincode, b.Email, b.Code, b.IsDeleted))
                .ToList();


            return View(model);
        }


       

        #endregion

        #region Add

        [HttpGet("add", Name = "employee-add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("add", Name = "employee-add")]
        public IActionResult Add(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            _dataContext.Employees.Add(new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                FatherName = model.FatherName,
                Fincode = model.Fincode,
                Email = model.Email,
                Code = _createCode.CreateCode()
            });
            _dataContext.SaveChanges();

            return RedirectToAction(nameof(Home));
        }

        #endregion 

        #region Update

        [HttpGet("update/{node}", Name = "employee-update")]
        public IActionResult Update([FromRoute] string node)
        {

            var employee = _dataContext.Employees.FirstOrDefault(b => b.Code == node);
            if (employee is null)
            {
                return NotFound();
            }

            return View(new UpdateResponseViewModel
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                FatherName = employee.FatherName,
                Fincode = employee.Fincode,
                Email = employee.Email
            });
        }


        [HttpPost("update/{node}", Name = "employee-update")]
        public IActionResult Update([FromRoute] string node, [FromForm] UpdateRequestViewModel model)
        {

            var employee = _dataContext.Employees.FirstOrDefault(b => b.Code == node);
            if (employee is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                UpdateResponseViewModel updateResponseViewModel = new UpdateResponseViewModel();

                return View(updateResponseViewModel);
            }

            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.FatherName = model.FatherName;
            employee.Fincode = model.Fincode;
            employee.Email = model.Email;

            _dataContext.Update(employee);
            _dataContext.SaveChanges();

            return RedirectToAction(nameof(Home));
        }

        #endregion

        #region Delete
        [HttpGet("delete/{node}", Name = "employee-delete-individual")]
        public ActionResult Delete(string node)
        {

            var employee = _dataContext.Employees.FirstOrDefault(b => b.Code == node);
            if (employee is null)
            {
                return NotFound();
            }

            employee.IsDeleted = true;
            _dataContext.SaveChanges();

            return RedirectToAction(nameof(Home));
        }

        #endregion

        [HttpGet("email", Name = "employee-email")]
        public IActionResult Email()
        {
            var model = _dataContext.Notifications.Select(b => new NotificationListViewModel(b.Title, b.FromEmail, b.TargetEmail, b.Content))
                .ToList();

            return View(model);
        }


        [HttpGet("addEmail", Name = "employee-email-add")]
        public IActionResult AddEmail()
        {
            return View();
        }

        [HttpPost("addEmail", Name = "employee-email-add")]
        public IActionResult AddEmail(NotificationAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _dataContext.TargetEmails.Add(new TargetEmail
            {
                Email = model.TargetEmail,
            });

            _dataContext.SaveChanges();

            var email = _dataContext.TargetEmails.FirstOrDefault(x => x.Email == model.TargetEmail);

            _dataContext.Notifications.Add(new NotificationModel
            {
                Title = model.Title,
                Content = model.Content,
                TargetEmailId = email.Id,
                FromEmail = _emailSender
            });

            _dataContext.SaveChanges();

            _emailService.Send(model.TargetEmail, model.Title, model.Content,  _emailSender);

            return RedirectToAction(nameof(email));
        }
    }
}
