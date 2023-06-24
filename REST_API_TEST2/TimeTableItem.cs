namespace REST_API_TEST2
{
    public class TimeTableItem
    {
        public string Id { get; set; }
        public string Teacher { get; set; }
        public string Group { get; set; }
        public string Employee { get; set; }
        public string Date { get; set; }
        public string Locate { get; set; }
        public string Subject { get; set; }
        public string Time { get; set; }
        public TimeTableItem(string id, string teacher, string subject, string group, string employee, string date,string time ,string locate)
        {
            Id = id;
            Teacher = teacher;
            Group = group;
            Employee = employee;
            Date = date;
            Locate = locate;
            Subject = subject;
            Time = time;
        }
    }
}
