using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_API_TEST2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee : ControllerBase
    {
        // POST api/<Employee>
        [HttpPost]
        public EmployeeItem Post([FromBody] Data data)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"SELECT * FROM `employee` WHERE Login = '{data.Log}' && Pass = SHA('{data.Pass}');";
            MySqlCommand command = new MySqlCommand(query, BDconnect);
            var reader = command.ExecuteReader();
            EmployeeItem empl = new EmployeeItem();
            while (reader.Read())
                empl = new EmployeeItem(reader.GetString(0),reader.GetString(1), reader.GetString(2), reader.GetString(3));
            reader.Close();
            BDconnect.Close();
            return empl;
        }

    }
}
