using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteadtlerHR.Models;
using Microsoft.AspNetCore.Mvc;

namespace SteadtlerHR.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL employeeDAL = new EmployeeDAL();
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            employees = employeeDAL.GetAllEmployee().ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Employee employee)
        {
            if(ModelState.IsValid)
            {
                employeeDAL.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Employee employee = employeeDAL.GetEmployeeByID(id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind] Employee employee)
        {
            if(id == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                employeeDAL.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employeeDAL);
        }
        [HttpGet]
         public IActionResult Details (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeDAL.GetEmployeeByID(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeDAL.GetEmployeeByID(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployees(int? id)
        {
            employeeDAL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }


    }
}