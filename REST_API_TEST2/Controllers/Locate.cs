using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_API_TEST2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Locate : ControllerBase
    {
        // GET: api/<Locate>
        [HttpGet]
        public IEnumerable<LocateItem> Get()
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = "SELECT * FROM locate ORDER BY `buildNumber`,`auditoriumNumber`;";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            List<LocateItem> list = new List<LocateItem>();
            while (reader.Read())
            {
                list.Add(new LocateItem(reader.GetString(0), reader.GetString(2), reader.GetString(1)));
            }
            reader.Close();
            BDconnect.Close();

            return list;
        }

        // POST api/<Locate>
        [HttpPost]
        public void Post([FromBody] LocateItem value)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"INSERT INTO `locate`(`buildNumber`, `auditoriumNumber`) VALUES ('{value.Building}','{value.Auditorium}')";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }

        // PUT api/<Locate>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] LocateItem value)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"UPDATE `locate` SET `buildNumber`='{value.Building}', `auditoriumNumber`='{value.Auditorium}' WHERE locateId = {id}";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }

        // DELETE api/<Locate>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"DELETE FROM `locate` WHERE locateId = {id}";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }
    }
}
