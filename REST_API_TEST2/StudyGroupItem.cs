using System.Text.Json.Serialization;

namespace REST_API_TEST2
{


    public class StudyGroupItem
    {
        public string accessor { get; set; }

        public string Header { get; set; }
        public string Course { get; set; }
        public string EducProg { get; set; }
        public string Year { get; set; }
        public string Number { get; set; }

        public StudyGroupItem(string _id,string _name, string _year, string _educProg, string _number) 
        {
            Header= _name;
            accessor = _id;
            EducProg= _educProg;
            DateTime date = new DateTime(int.Parse(_year),9,1);
            DateTime dateNow = DateTime.Now;
            var diff = dateNow.Subtract(date);
            Course = ((diff.Days)/365 + 1).ToString();
            Year = _year;
            Number = _number;
        }
        public StudyGroupItem() { }
    }
}
