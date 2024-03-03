using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ToDoAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoAppController : ControllerBase
    {
        private IConfiguration _configuration;
        public TodoAppController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetNotes")]

        public JsonResult GetNotes()
        {
            string query = "select * from Notes";
            DataTable dataTable = new DataTable();
            string sqlDatasources = _configuration.GetConnectionString("todoAppDBCon");
            SqlDataReader reader;
            using(SqlConnection connection = new SqlConnection(sqlDatasources))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    dataTable.Load(reader);
                }
            }
            return new JsonResult("");
        }
    }
}
