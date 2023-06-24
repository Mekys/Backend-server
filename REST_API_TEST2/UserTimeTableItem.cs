using System.Globalization;

namespace REST_API_TEST2
{
    public class UserTimeTableItem:IComparable<UserTimeTableItem>
    {
        public string Time { get; set; }
        public string Descrition { get; set; }
        public string Day { get; set; }
        public string Group { get; set; }
        public int DayOfWeek { get; set; }

        public UserTimeTableItem(string time, string day, string teacher, string building, string auditorium, string subject, string group)
        {
            Descrition = subject + "\n" + teacher + $"({auditorium}[{building}])";
            Time = time;
            DateTime dateValue = DateTime.Parse(day);
            DayOfWeek = (int)dateValue.DayOfWeek;
            Day = dateValue.ToString("dddd", new CultureInfo("ru-RU"));
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            Day = ti.ToTitleCase(Day);
            Group = group;
        }



        public int CompareTo(UserTimeTableItem? other)
        {
            if (other.DayOfWeek == this.DayOfWeek) return 0;
            return other.DayOfWeek > this.DayOfWeek ? -1 : 1;
        }
    }
}
