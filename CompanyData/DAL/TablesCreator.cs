using Microsoft.Data.SqlClient;

namespace CompanyData.DAL;

public class TablesCreator
{
    private readonly CompanyDbContext _dbContext;
    private readonly SqlCommand _command;

    public TablesCreator(CompanyDbContext dbContext, SqlCommand command) 
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _command = command ?? throw new ArgumentNullException(nameof(command));
    }

    public void Create()
    {
        using(SqlConnection connection = _dbContext.CreateConnection())
        {
            connection.Open();
            var command = new SqlCommand();
            CommandWorker(GetCommand_CreateTable_Company(), connection);
            CommandWorker(GetCommand_CreateTable_Department(), connection);
            CommandWorker(GetCommand_CreateTable_CompanyDepartment(), connection);
            CommandWorker(GetCommand_CreateTable_Employee(), connection);
            CommandWorker(GetCommand_CreateTable_SalaryDetails(), connection);
            CommandWorker(GetCommand_CreateTable_EmployeeInfo(), connection);
            CommandWorker(GetCommand_CreateTable_Address(), connection);
        }
    }

    private void CommandWorker(string commandText, SqlConnection connection)
    {
        _command.CommandText = commandText;
        _command.Connection = connection;
        _command.ExecuteNonQuery();
    }

    private string GetCommand_CreateTable_Company() =>
        "CREATE TABLE Company" +
        "(" +
        "CompanyID INT NOT NULL PRIMARY KEY IDENTITY, " +
        "[Name] VARCHAR(50) NOT NULL," +
        "[Description] VARCHAR(2000)" +
        ")";

    private string GetCommand_CreateTable_Department() =>
        "CREATE TABLE Department" +
        "(" +
        "DepartmentID INT NOT NULL PRIMARY KEY IDENTITY," +
        "[Name] VARCHAR(50) NOT NULL" +
        ")";

    private string GetCommand_CreateTable_CompanyDepartment() =>
        "CREATE TABLE CompanyDepartment" +
        "(" +
        "CompanyDepartmentID INT NOT NULL PRIMARY KEY IDENTITY," +
        "CompanyID INT NOT NULL FOREIGN KEY REFERENCES Company(CompanyID)," +
        "DepartmentID INT NOT NULL FOREIGN KEY REFERENCES Department(DepartmentID)" +
        ")";

    private string GetCommand_CreateTable_Employee() =>
        "CREATE TABLE Employee" +
        "(" +
        "EmployeeID INT NOT NULL PRIMARY KEY IDENTITY," +
        "CompanyID INT NOT NULL FOREIGN KEY REFERENCES Company(CompanyID)," +
        "DepartmentID INT NOT NULL FOREIGN KEY REFERENCES Department(DepartmentID)," +
        "FirstName VARCHAR(50) NOT NULL," +
        "LastName VARCHAR(50) NOT NULL," +
        "PatronymicName VARCHAR(50) NOT NULL," +
        "Position VARCHAR(50) NOT NULL," +
        "CurrentSalary INT" +
        ")";

    private string GetCommand_CreateTable_SalaryDetails() =>
        "CREATE TABLE SalaryDetails" +
        "(" +
        "SalaryDetailsID INT NOT NULL PRIMARY KEY IDENTITY," +
        "EmployeeID INT NOT NULL FOREIGN KEY REFERENCES Employee(EmployeeID) ON DELETE CASCADE," +
        "SalaryAmount INT," +
        "PayDay DATE" +
        ")";

    private string GetCommand_CreateTable_EmployeeInfo() =>
        "CREATE TABLE EmployeeInfo" +
        "(" +
        "EmployeeInfoID INT NOT NULL PRIMARY KEY IDENTITY," +
        "EmployeeID INT UNIQUE NOT NULL FOREIGN KEY REFERENCES Employee(EmployeeID) ON DELETE CASCADE," +
        "BirthDate DATE NOT NULL," +
        "Phone CHAR(15)" +
        ")";

    private string GetCommand_CreateTable_Address() =>
        "CREATE TABLE [Address]" +
        "(" +
        "AddressID INT NOT NULL PRIMARY KEY IDENTITY," +
        "EmployeeInfoID INT UNIQUE NOT NULL FOREIGN KEY REFERENCES EmployeeInfo(EmployeeInfoID) ON DELETE CASCADE," +
        "City VARCHAR(30) NOT NULL," +
        "TypeStreet VARCHAR(20) NOT NULL," +
        "NameStreet VARCHAR(100) NOT NULL," +
        "House INT," +
        "Apartment INT" +
        ")";
}
