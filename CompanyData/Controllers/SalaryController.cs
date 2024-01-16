using CompanyData.DAL.DAO;
using CompanyData.DAL.DAO.Interface;
using CompanyData.DAL.Models;
using CompanyData.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompanyData.Controllers
{
    public class SalaryController : Controller
    {
        private readonly IEmployeeDao _employeeDao;
        private readonly IDepartmentDao _departmentDao;

        public SalaryController(IEmployeeDao employeeDao, IDepartmentDao departmentDao)
        {
            _employeeDao = employeeDao ?? throw new ArgumentNullException(nameof(employeeDao));
            _departmentDao = departmentDao ?? throw new ArgumentNullException(nameof(departmentDao));
        }

        public IActionResult Salaries(int? departmentID)
        {
            try
            {
                var employees = _employeeDao.GetEmployeesAndTheirDepartments();
                var departments = _departmentDao.GetAll<Department>();
                var employeeViewModel = new SalaryViewModel(employees, departments);
                if (departmentID is not null && departmentID > 0)
                {
                    employeeViewModel.Employees = employees.Where(d => d.DepartmentID == departmentID);
                }
                return View(employeeViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
