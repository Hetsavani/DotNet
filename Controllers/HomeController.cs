using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace NiceAdmin.Controllers
{

    [CheckAccess]
    public class HomeController : Controller
    {
        private IConfiguration configuration;

        public HomeController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public IActionResult Index()
        {
            #region User
            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_User_Count";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            foreach (DataRow row in table.Rows) {
                ViewBag.User_count = row["ID"];
            }
            #endregion
            SqlConnection connection1 = new SqlConnection(connectionString);
            connection1.Open();
            SqlCommand command1 = connection1.CreateCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "PR_Customer_Count";
            SqlDataReader reader1 = command1.ExecuteReader();
            DataTable table1 = new DataTable();
            table.Load(reader1);
            foreach (DataRow row in table1.Rows)
            {
                ViewBag.Customer_count = row["ID"];
            }
            return View();
        }
    }
}
