namespace CompanyData.DAL.DAO.Interface;

public interface ICompanyDao
{
    public IEnumerable<Company> GetAll<Company>() where Company : class;
}
