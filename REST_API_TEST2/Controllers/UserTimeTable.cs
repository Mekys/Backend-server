using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Crmf;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_API_TEST2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTimeTable : ControllerBase
    {
        // GET: api/<UserTimeTable>
        [HttpGet]
        public List<UserTableCell> Get()
        {
            DateTime monday= DateTime.Now;
            while (monday.DayOfWeek != DayOfWeek.Monday)
            {
                monday = monday.AddDays(-1);
            }
            
            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=lub;";
            MySqlConnection BDconnect = new MySqlConnection(connect);
            BDconnect.Open();
            var qet = $"SELECT `timetable`.`groupId`, DATE_FORMAT(`date`.date, '%d-%m-%y'), TIME_FORMAT(`time`.`Studytime`,'%H:%i'), locate.buildNumber, locate.auditoriumNumber, CONCAT(teacher.surname,' ',left(teacher.name,1),'.',left(teacher.middleName,1),'.'), subject.subjectName FROM `timetable` " +
                $"JOIN studentgroup ON studentgroup.groupId = timetable.groupId " +
                $"JOIN `date` ON `date`.`DateId` = timetable.dateId " +
                $"JOIN `time` ON `time`.`timeId` = timetable.timeId " +
                $"JOIN locate ON locate.locateId = timetable.locateId " +
                $"JOIN educationprogram ON timetable.groupId = studentgroup.groupId AND studentgroup.ProgramId = educationprogram.ProgramId " +
                $"JOIN teacher ON timetable.teacherId = teacher.teacherId " +
                $"JOIN subject ON timetable.subjectId = subject.subjectId" +
                $"   " +
                $" ORDER BY TIME_FORMAT(`time`.`Studytime`,'%H:%i');";
            MySqlCommand command = new MySqlCommand(qet, BDconnect);
            List<UserTimeTableItem> items = new List<UserTimeTableItem>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new UserTimeTableItem(reader.GetString(2), reader.GetString(1), reader.GetString(5), reader.GetString(3), reader.GetString(4), reader.GetString(6), reader.GetString(0)));
            }
            items.Sort();
            var a = from item in items
                    group item by new { item.Day, item.Time};
            string currentDay = "";
            UserTableCell current = new UserTableCell();
            List<UserTableCell> ans = new List<UserTableCell>(); 
            foreach(var c in a)
            {
                if (c.Key.Day.Equals(currentDay))
                {
                    TableRow row = new TableRow(c.Key.Time);
                    foreach (var item in c)
                    {
                        row.AddInfo(item.Group, item.Descrition);
                    }
                    current.data.Add(row);
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentDay))
                    {
                        current.data.Sort();
                        ans.Add(current);
                    }
                    currentDay = c.Key.Day;
                    current = new UserTableCell(currentDay);
                    TableRow row = new TableRow(c.Key.Time);
                    foreach (var item in c)
                    {
                        row.AddInfo(item.Group, item.Descrition);
                    }
                    current.data.Add(row);
                }
            }
            if (!string.IsNullOrEmpty(currentDay))
            {
                current.data.Sort();
                ans.Add(current);
            }
            reader.Close();
            BDconnect.Close();
            return ans;
        }

    }
}
