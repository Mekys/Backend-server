using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_API_TEST2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTable : ControllerBase
    {
        // GET: api/<TimeTable>
        [HttpGet]
        public IEnumerable<TimeTableItem> Get()
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var qet = $"SELECT\r\n    `timetable`.`timetableId`,\r\n    CONCAT(\r\n        teacher.surname,\r\n        ' ',\r\n        LEFT(teacher.name, 1),\r\n        '.',\r\n        LEFT(teacher.middleName, 1),\r\n        '.'\r\n    ),\r\n    SUBJECT.subjectName,\r\n    UPPER(\r\n        CONCAT(\r\n            acronym(educationprogram.ProgramName),\r\n            '-',\r\n            RIGHT(studentgroup.year, 2),\r\n            '-',\r\n            studentgroup.number\r\n        )\r\n    ),\r\n    CONCAT(\r\n        employee.Surname,\r\n        '.',\r\n        LEFT(employee.Name, 1),\r\n        '.',\r\n        LEFT(employee.Middlename, 1),\r\n        '.'\r\n    ),\r\n    DATE_FORMAT(`date`.date, '%d/%m/%Y'),\r\n    TIME_FORMAT(`time`.`Studytime`, '%H:%i'),\r\n    CONCAT(\r\n        LOCATE.auditoriumNumber,\r\n        '[',\r\n        LOCATE.buildNumber,\r\n        ']'\r\n    )\r\nFROM\r\n    `timetable`\r\nJOIN employee ON timetable.employeesId = employee.employeeId\r\nJOIN studentgroup ON studentgroup.groupId = timetable.groupId\r\nJOIN `date` ON `date`.`DateId` = timetable.dateId\r\nJOIN `time` ON `time`.`timeId` = timetable.timeId\r\nJOIN LOCATE ON LOCATE.locateId = timetable.locateId\r\nJOIN educationprogram ON timetable.groupId = studentgroup.groupId AND studentgroup.ProgramId = educationprogram.ProgramId\r\nJOIN teacher ON timetable.teacherId = teacher.teacherId\r\nJOIN SUBJECT ON timetable.subjectId = SUBJECT.subjectId\r\nORDER BY\r\n    TIME_FORMAT(`time`.`Studytime`, '%H:%i');";
            MySqlCommand command = new MySqlCommand(qet, BDconnect);
            List<TimeTableItem> items = new List<TimeTableItem>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new TimeTableItem(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)));
            }
            reader.Close();
            BDconnect.Close();
            return items;
        }

        // GET api/<TimeTable>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TimeTable>
        [HttpPost]
        public void Post([FromBody] TimeTableItem value)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"INSERT INTO `timetable`(`teacherId`, `subjectId`, `groupId`, `employeesId`, `dateId`, `timeId`, `locateId`) VALUES ('{value.Teacher}','{value.Subject}','{value.Group}','{value.Employee}','{value.Date}','{value.Time}','{value.Locate}')";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }

        // PUT api/<TimeTable>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TimeTableItem value)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"UPDATE `timetable` SET `teacherId`='{value.Teacher}',`subjectId`='{value.Subject}',`groupId`='{value.Group}',`employeesId`='{value.Employee}',`dateId`='{value.Date}',`timeId`='{value.Time}',`locateId`='{value.Locate}' WHERE timetableID = '{id}'";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }

        // DELETE api/<TimeTable>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var query = $"DELETE FROM `timetable` WHERE timetableId = {id}";
            MySqlCommand comand = new MySqlCommand(query, BDconnect);
            var reader = comand.ExecuteReader();
            reader.Close();
            BDconnect.Close();
        }
    }
}
