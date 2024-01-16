namespace CompanyData.DAL.DAO.Interface;

public interface IDepartmentDao
{
    public IEnumerable<Department> GetAll<Department>() where Department : class;
}