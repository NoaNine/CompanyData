using CompanyData.DAL.Models;

namespace CompanyData.Models.ViewModels;

public class EmployeeViewModel
{
    public IEnumerable<Employee> Employees { get; set; }
    public IEnumerable<Department> Departments { get; set; }
    public IEnumerable<Position> Positions { get; set; }

    public EmployeeViewModel(IEnumerable<Employee> employees, IEnumerable<Department> departments, IEnumerable<Position> positions)
    {
        Employees = employees;
        Departments = departments;
        Positions = positions;
    }
}
