using CompanyData.DAL.Models;

namespace CompanyData.Models.ViewModels;

public class SalaryViewModel
{
    public IEnumerable<Employee> Employees { get; set; }
    public IEnumerable<Department> Departments { get; set; }
    public int SumSalary { get => GetSumSalary(); }

    public SalaryViewModel(IEnumerable<Employee> employees, IEnumerable<Department> departments)
    {
        Employees = employees;
        Departments = departments;
    }

    private int GetSumSalary()
    {
        var sum = 0;
        foreach (var employee in Employees)
        {
            sum += employee.CurrentSalary;
        }
        return sum;
    }
}
