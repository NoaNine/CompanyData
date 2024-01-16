using CompanyData.DAL;
using CompanyData.DAL.DAO;
using CompanyData.DAL.DAO.Interface;
using Microsoft.Data.SqlClient;

namespace CompanyData;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<CompanyDbContext>();  
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<ICompanyDao, CompanyDao>();
        builder.Services.AddScoped<IEmployeeDao, EmployeeDao>();
        builder.Services.AddScoped<IDepartmentDao, DepartmentDao>();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

#if Development // Creates tables in DB and inserts test data
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<CompanyDbContext>();
            var command = new SqlCommand();

            var tableCreator = new TablesCreator(context, command);
            tableCreator.Create();
            var dataSeeder = new DataSeeder(context, command);
            dataSeeder.Seed();
        }
#endif

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Companies}/{id?}");

        app.Run();
    }
}
