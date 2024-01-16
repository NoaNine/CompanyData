using CompanyData.DAL.DAO.Interface;
using CompanyData.DAL.Models;
using CompanyData.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompanyData.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeDao _employeeDao;
        private readonly IDepartmentDao _departmentDao;

        public EmployeeController(IEmployeeDao employeeDao, IDepartmentDao departmentDao) 
        {
            _employeeDao = employeeDao ?? throw new ArgumentNullException(nameof(employeeDao));
            _departmentDao = departmentDao ?? throw new ArgumentNullException(nameof(departmentDao));
        }

        public IActionResult Employees(int? departmentID, string positionName)
        {
            try
            {
                var employees = _employeeDao.GetEmployeesAndTheirDepartments();
                var departments = _departmentDao.GetAll<Department>();
                var positions = _employeeDao.GetAllPositions();
                var employeeViewModel = new EmployeeViewModel(employees, departments, positions);
                if (departmentID is not null && departmentID > 0)
                {
                    employeeViewModel.Employees = employees.Where(d => d.DepartmentID == departmentID);
                }
                if (positionName is not null)
                {
                    employeeViewModel.Positions = positions.Where(p => p.Name == positionName);
                }
                return View(employeeViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public ActionResult Edit(int id)
        {
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            return RedirectToAction("Employees");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Employees");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
