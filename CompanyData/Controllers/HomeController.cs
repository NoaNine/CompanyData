using CompanyData.DAL.DAO.Interface;
using CompanyData.DAL.Models;
using CompanyData.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompanyData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompanyDao _companyDao;
        public HomeController(ICompanyDao companyDao)
        {
            _companyDao = companyDao ?? throw new ArgumentNullException(nameof(companyDao));
        }

        public IActionResult Companies()
        {
            try
            {
                var companies = _companyDao.GetAll<Company>();
                return View(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
