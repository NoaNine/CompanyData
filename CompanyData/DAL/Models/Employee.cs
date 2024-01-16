namespace CompanyData.DAL.Models;

public class Employee 
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PatronymicName { get; set; }
    public string Position { get; set; }
    public int CurrentSalary { get; set; }

    public int CompanyID { get; set; }
    public int DepartmentID { get; set; }
    public Company Company { get; set; }
    public Department Department { get; set; }
}
