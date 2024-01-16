namespace CompanyData.DAL.Models;

public class Company 
{
    public int CompanyID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public IEnumerable<Employee> Employees { get; set; } = Enumerable.Empty<Employee>();
    public IEnumerable<Department> Departments { get; set; } = Enumerable.Empty<Department>();
}
