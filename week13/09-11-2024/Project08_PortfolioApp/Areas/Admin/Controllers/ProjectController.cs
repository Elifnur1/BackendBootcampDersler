using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Project08_PortfolioApp.Models;

namespace Project08_PortfolioApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        // GET: ProjectController
        public async Task<ActionResult> Index()
        {
            //Bağlantıyı hazırlıyoruz
            //sql server bağlantı yapmamız için gerekli olan connection string.
            var connectionString = "Server=localhost,1441;Database=PortfolioDb;User=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=true";
            var connection = new SqlConnection(connectionString);

            //Site ayarlarını çekiyoruz
            var queryProjects = "select * from Projects";
            var projects = await connection.QueryAsync<Project>(queryProjects);

            return View(projects);
        }

    }
}
