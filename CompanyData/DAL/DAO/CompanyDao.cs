using CompanyData.DAL.DAO.Base;
using CompanyData.DAL.DAO.Interface;
using Dapper;

namespace CompanyData.DAL.DAO;

public class CompanyDao : BaseDao, ICompanyDao
{
    public CompanyDao(CompanyDbContext dbContext) : base(dbContext)
    {

    }

    public override IEnumerable<Company> GetAll<Company>()
    {
        var query = "SELECT * FROM Company";

        using (var connection = _dbContext.CreateConnection())
        {
            var companies = connection.Query<Company>(query);
            return companies;
        }
    }
}
