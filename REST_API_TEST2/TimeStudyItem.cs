using System.Diagnostics.Contracts;

namespace REST_API_TEST2
{
    public class TimeStudyItem
    {

        public string Id { get; set; }

        public string Time { get; set; }

        public TimeStudyItem(string _time, string _id)
        {
            var time = TimeOnly.Parse(_time);
            Time = time.ToString("HH:mm");
            Id = _id;
        }
    }
}
