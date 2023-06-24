using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_API_TEST2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Teacher : ControllerBase
    {
        // GET: api/<Teacher>
        [HttpGet]
        public IEnumerable<TeacherItem> Get()
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = "SELECT * FROM teacher ORDER BY `surname`,`name`,`middleName`;";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            List<TeacherItem> list = new List<TeacherItem>();
            while (reader.Read())
            {
                var buff = new TeacherItem(reader.GetString(1),reader.GetString(2),reader.GetString(3), reader.GetString(0));
                list.Add(buff);
            }
            reader.Close();
            BDconnect.Close();
            return list;
        }

        // GET api/<Teacher>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<Teacher>
        [HttpPost]
        public void Post([FromBody] TeacherItem value)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"INSERT INTO `teacher`(`name`,`surname`,`middleName`) VALUES ('{value.Name}','{value.Surname}','{value.MiddleName}')";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }

        // PUT api/<Teacher>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TeacherItem value)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"UPDATE `teacher` SET `name`='{value.Name}', surname = '{value.Surname}', middleName = '{value.MiddleName}' WHERE teacherId = {id}";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }

        // DELETE api/<Teacher>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"DELETE FROM `teacher` WHERE teacherId = {id}";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }
    }
}
