namespace CompanyData.DAL.Models;

public class Department 
{
    public int DepartmentID { get; set; }
    public string Name { get; set; }

    public IEnumerable<Employee> Employees { get; set; } = Enumerable.Empty<Employee>();
    public IEnumerable<Company> Companies { get; set; } = Enumerable.Empty<Company>();
}
