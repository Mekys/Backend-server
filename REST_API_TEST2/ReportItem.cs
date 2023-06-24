namespace REST_API_TEST2
{
    public class ReportItem
    {
        public string Преподаватель { get; set; }
        public string Количество_занятий { get; set; }
        public ReportItem(string _teacher, string _count)
        {
            Преподаватель = _teacher;
            Количество_занятий = _count;
        }
    }
}
