using CompanyData.DAL.DAO.Base;
using CompanyData.DAL.DAO.Interface;
using Dapper;

namespace CompanyData.DAL.DAO;

public class DepartmentDao : BaseDao, IDepartmentDao
{
    public DepartmentDao(CompanyDbContext dbContext) : base(dbContext)
    {
    }

    public override IEnumerable<Department> GetAll<Department>()
    {
        var query = "SELECT * FROM Department";

        using (var connection = _dbContext.CreateConnection())
        {
            var departments = connection.Query<Department>(query);
            return departments;
        }
    }
}
