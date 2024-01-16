using CompanyData.DAL.Models;

namespace CompanyData.DAL.DAO.Interface;

public interface IEmployeeDao
{
    public IEnumerable<Employee> GetAll<Employee>() where Employee : class;
    public IEnumerable<Employee> GetEmployeesAndTheirDepartments();
    public IEnumerable<Position> GetAllPositions();
}