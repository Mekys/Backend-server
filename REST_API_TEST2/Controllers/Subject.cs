using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_API_TEST2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Subject : ControllerBase
    {
        // GET: api/<Subject>
        [HttpGet]
        public IEnumerable<SubjectItem> Get()
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = "SELECT * FROM subject ORDER BY `subjectName`;";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            List<SubjectItem> list = new List<SubjectItem>();
            while (reader.Read())
            {
                var buff = new SubjectItem(reader.GetString(0), reader.GetString(1));
                list.Add(buff);
            }
            reader.Close();
            BDconnect.Close();
            return list;
        }

        // GET api/<Subject>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Subject>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"INSERT INTO `subject`(`subjectName`) VALUES ('{value}')";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }

        // PUT api/<Subject>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"UPDATE `subject` SET `subjectName`='{value}' WHERE subjectId = {id}";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }

        // DELETE api/<Subject>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"DELETE FROM `subject` WHERE subjectId = {id}";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }
    }
}
