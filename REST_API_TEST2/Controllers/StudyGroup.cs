using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_API_TEST2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyGroup : ControllerBase
    {
        // GET: api/<StudyGroup>
            [HttpGet]
        public IEnumerable<StudyGroupItem> Get()
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var quer = $"SELECT groupId,UPPER( CONCAT( acronym(educationprogram.ProgramName), '-',RIGHT(studentgroup.year, 2) , '-',studentgroup.number)),studentgroup.year,educationprogram.ProgramName,studentgroup.number FROM studentgroup " +
               $"JOIN educationprogram ON studentgroup.ProgramId = educationprogram.ProgramId " +
               $"ORDER BY studentgroup.year, educationprogram.ProgramName, studentgroup.number;";
            MySqlCommand command = new MySqlCommand(quer, BDconnect);
            MySqlDataReader reader = command.ExecuteReader();
            List<StudyGroupItem> list = new List<StudyGroupItem>();
            while (reader.Read())
            {
                list.Add(new StudyGroupItem(reader.GetString(0), reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4)));
            }
            reader.Close();
            BDconnect.Close();
            return list;
        }

        // GET api/<StudyGroup>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudyGroup>
        [HttpPost]
        public void Post([FromBody] StudyGroupItem value)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"INSERT INTO `studentgroup`(`number`, `year`, `ProgramId`) VALUES ('{value.Number}','{value.Year}','{value.EducProg}')";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }

        // PUT api/<StudyGroup>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudyGroupItem value)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"UPDATE `studentgroup` SET `number`='{value.Number}', year = '{value.Year}', ProgramId = '{value.EducProg}' WHERE groupId = {id}";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }

        // DELETE api/<StudyGroup>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"DELETE FROM `studentgroup` WHERE groupId = {id}";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }
    }
}
