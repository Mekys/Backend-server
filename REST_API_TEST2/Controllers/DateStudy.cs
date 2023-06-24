using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_API_TEST2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateStudy : ControllerBase
    {
        // GET: api/<DateStudy>
        [HttpGet]
        public IEnumerable<DateStudyItem> Get()
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = "SELECT DateId, DATE_FORMAT(Date,'%d/%m/%Y'), DATE_FORMAT(Date,'%Y/%m/%d') FROM date ORDER BY Date;";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            List<DateStudyItem> list = new List<DateStudyItem>();
            while(reader.Read())
            {
                var buff = new DateStudyItem(reader.GetString(0), reader.GetString(1),reader.GetString(2));
                list.Add(buff);
            }
            reader.Close();
            BDconnect.Close();
            return list;
        }

        // POST api/<DateStudy>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"INSERT INTO `date`(`Date`) VALUES ('{DateOnly.Parse(value).ToString("yyyy-MM-dd")}')";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }

        // PUT api/<DateStudy>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"UPDATE `date` SET `Date`='{value}' WHERE DateId = {id}";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }

        // DELETE api/<DateStudy>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"DELETE FROM `date` WHERE DateId = {id}";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }
    }
}
