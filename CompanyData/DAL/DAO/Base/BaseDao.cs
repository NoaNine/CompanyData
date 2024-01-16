namespace CompanyData.DAL.DAO.Base
{
    public abstract class BaseDao
    {
        private protected readonly CompanyDbContext _dbContext;

        public BaseDao(CompanyDbContext dbContext) 
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public abstract IEnumerable<T> GetAll<T>() where T : class;
    }
}
