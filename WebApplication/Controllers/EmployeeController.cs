using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;
        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View("EmployeeCreate");
        }
        
        public ActionResult Display(Employee model)
        {
            var emp = _context.Employee.ToList();
            if (emp != null)
            {
                Console.WriteLine(emp);
            }
            return View("Listof_Employees",emp);
        }
        [HttpPost]
        public ActionResult SaveRecord(Employee model)
        {
            try
            {
                Employee emp = new Employee();
                emp.EmailId = model.EmailId;
                emp.FirstName = model.FirstName;
                emp.Lastname = model.Lastname;
                emp.city = model.city;
                emp.country = model.country;
                emp.telephone = model.telephone;
                emp.role = model.role;
                emp.address_location = model.address_location;
                emp.password = model.password;
                _context.Add(emp);
                _context.SaveChanges();
            }catch(Exception e)
            {
                Console.WriteLine("Duplicate Data was found");

            }
                return RedirectToAction("Index");
        }
    }
}
