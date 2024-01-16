using Microsoft.Data.SqlClient;

namespace CompanyData.DAL;

public class DataSeeder
{
    private readonly CompanyDbContext _dbContext;
    private readonly SqlCommand _command;

    public DataSeeder(CompanyDbContext dbContext, SqlCommand command)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _command = command ?? throw new ArgumentNullException(nameof(command));
    }

    public void Seed()
    {
        using (SqlConnection connection = _dbContext.CreateConnection())
        {
            connection.Open();
            CommandWorker(GetCommand_InsertData_Company(), connection);
            CommandWorker(GetCommand_InsertData_Department(), connection);
            CommandWorker(GetCommand_InsertData_CompanyDepartment(), connection);
            CommandWorker(GetCommand_InsertData_Employee(), connection);
            CommandWorker(GetCommand_InsertData_SalaryDetails(), connection);
            CommandWorker(GetCommand_InsertData_EmployeeInfo(), connection);
            CommandWorker(GetCommand_InsertData_Address(), connection);
        }
    }

    private void CommandWorker(string commandText, SqlConnection connection)
    {
        _command.CommandText = commandText;
        _command.Connection = connection;
        _command.ExecuteNonQuery();
    }

    private string GetCommand_InsertData_Company() =>
        "INSERT INTO Company([Name], [Description])" +
        "VALUES" +
        "('Apple', 'Some info for Apple')," +
        "('Pixel', 'Some info for Pixel')," +
        "('Samsung', 'Some info for Samsung')," +
        "('Xiaomi', 'Some info for Xiaomi')";

    private string GetCommand_InsertData_Department() =>
        "INSERT INTO Department([Name])" +
        "VALUES" +
        "('Sales')," +
        "('Marketing')," +
        "('Administration')," +
        "('Support')";

    private string GetCommand_InsertData_CompanyDepartment() =>
        "INSERT INTO CompanyDepartment(CompanyID, DepartmentID)" +
        "VALUES" +
        "(1,1)," +
        "(1,2)," +
        "(1,2)," +
        "(1,3)," +
        "(1,4)," +
        "(2,3)," +
        "(3,1)," +
        "(4,4)";

    private string GetCommand_InsertData_Employee() =>
        "INSERT INTO Employee(CompanyID, DepartmentID, FirstName, LastName, PatronymicName, Position, CurrentSalary)" +
        "VALUES" +
        "(1, 2, 'Іван', 'Тіщенко', 'Васильович', 'Маркетолог', 3000)," +
        "(2, 3, 'Леся', 'Марченко', 'Іванівна', 'Директор', 1000)," +
        "(3, 4, 'Жосеф', 'Іванов', 'Олександрович', 'Оператор', 2000)," +
        "(4, 1, 'Ія', 'Терещенко', 'Олеговна', 'Менеджер продажів', 1800)," +
        "(2, 2, 'Петро', 'Петров', 'Петрович', 'Менеджер', 3000)," +
        "(2, 4, 'Іван', 'Іваненко', 'Іванович', 'Опертор техпідтримки', 3000)," +
        "(1, 3, 'Жанна', 'Заєць', 'Григорівна', 'Завідуючий відділу продажів', 3300)," +
        "(1, 4, 'Дмитро', 'Лось', 'Васильович', 'Прибиральниця', 2500)," +
        "(4, 2, 'Віталій', 'Пшук', 'Олегович', 'Дизайнер', 3000)," +
        "(1, 1, 'Олександр', 'Баранов', 'Ігоревич', 'Менеджер', 4500)," +
        "(1, 4, 'Дарина', 'Гудзь', 'Іванівна', 'Технічний інженер', 3000)," +
        "(3, 2, 'Ольга', 'Берегова', 'Олександрівна', 'Розробник', 1500)," +
        "(1, 4, 'Олександр', 'Ольгич', 'Олександрович', 'Інженер', 3000)," +
        "(2, 3, 'Інна', 'Петрунько', 'Іванівна', 'Менеджер', 3000)," +
        "(4, 3, 'Олександр', 'Тощаків', 'Васильович', 'Адмін', 3000)," +
        "(1, 3, 'Анна', 'Черненко', 'Сергіївна', 'Засновник', 3000)," +
        "(4, 2, 'Сергій', 'Березний', 'Ігоревич', 'Менеджер', 1100)," +
        "(2, 1, 'Сергій', 'Трутний', 'Петрович', 'Менеджер', 8000)," +
        "(4, 1, 'Анна', 'Галицька', 'Олегівна', 'Постачальник', 500)," +
        "(1, 3, 'Іван', 'Томний', 'Данилович', 'Старший оператор', 800)," +
        "(4, 2, 'Іван', 'Запорізький', 'Ростиславович', 'Графічний дизайнер', 3000)";

    private string GetCommand_InsertData_SalaryDetails() =>
        "INSERT INTO SalaryDetails (EmployeeID, SalaryAmount, PayDay)" +
        "VALUES" +
        "(1, 2800, '2023-11-15')";

    private string GetCommand_InsertData_EmployeeInfo() =>
        "INSERT INTO EmployeeInfo(EmployeeID, BirthDate, Phone)" +
        "VALUES" +
        "(1, '2023-10-25', '+380977777777')";

    private string GetCommand_InsertData_Address() =>
        "INSERT INTO [Address] (EmployeeInfoID, City, TypeStreet, NameStreet, House, Apartment)" +
        "VALUES" +
        "(1, 'Київ', 'проспект', 'Курбаса Леся', 10, 1005)";
}
