namespace REST_API_TEST2
{
    public class DateStudyItem
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string Picker { get; set; }
        public DateStudyItem(string id, string date, string _dateForPC)
        {
            Id = id;
            Date = date;
            Picker= _dateForPC;
        }
    }
}
