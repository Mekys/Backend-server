using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_API_TEST2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Report : ControllerBase
    {
        // GET: api/<Report>
        [HttpGet]
        public IEnumerable<ReportItem> Get()
        {
            DateTime monday = DateTime.Now;
            while (monday.DayOfWeek != DayOfWeek.Monday)
            {
                monday = monday.AddDays(-1);
            }
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"SELECT" +
                $" CONCAT(teacher.surname,' ',LEFT(teacher.name, 1),'.',LEFT(teacher.middleName , 1),'.') AS 'Преподаватель'," +
                $"COUNT(*) AS 'Количество занятий в неделю' " +
                $"FROM `timetable` " +
                $"JOIN teacher ON `timetable`.`teacherId` = `teacher`.`teacherId` " +
                $"JOIN `date` ON `timetable`.`dateId` = `date`.`DateId` " +
                $"WHERE `date`.date BETWEEN '{monday.ToString("yyyy-MM-dd")}' AND '{monday.AddDays(6).ToString("yyyy-MM-dd")}' GROUP BY  `timetable`.`teacherId`;";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            List<ReportItem> list = new List<ReportItem>();
            while (reader.Read())
            {
                list.Add(new ReportItem(reader.GetString(0), reader.GetString(1)));
            }
            reader.Close();
            BDconnect.Close();

            return list;
        }
    }
}
