using CompanyData.DAL.DAO.Base;
using CompanyData.DAL.DAO.Interface;
using CompanyData.DAL.Models;
using Dapper;
using Microsoft.IdentityModel.Tokens;

namespace CompanyData.DAL.DAO;

public class EmployeeDao : BaseDao, IEmployeeDao
{
    public EmployeeDao(CompanyDbContext dbContext) : base(dbContext)
    {

    }

    public override IEnumerable<Employee> GetAll<Employee>()
    {
        var query = "SELECT * FROM Employee";

        using (var connection = _dbContext.CreateConnection())
        {
            var employees = connection.Query<Employee>(query);
            return employees;
        }
    }

    public IEnumerable<Employee> GetEmployeesAndTheirDepartments()
    {
        var query =
            "SELECT * " +
            "FROM Employee " +
            "JOIN Department ON Employee.DepartmentID = Department.DepartmentID";

        using (var connection = _dbContext.CreateConnection())
        {
            var employees = connection.Query<Employee, Department, Employee>(
                query,
                map: (employee, department) =>
                {
                    employee.Department = department;
                    return employee;
                },
                splitOn: "DepartmentID");
            return employees;
        }
    }

    public IEnumerable<Position> GetAllPositions()
    {
        var query = 
            "SELECT DISTINCT Position " +
            "FROM Employee";

        using (var connection = _dbContext.CreateConnection())
        {
            var positions = connection.Query<Position>(query);
            return positions;
        }
    }
}

