using System.Text.Json.Serialization;

namespace REST_API_TEST2
{
    public class TeacherItem
    {
        public string Id { set; get; }
        [JsonInclude]
        public string Name { set; get; }
        [JsonInclude]
        public string Surname { set; get; }
        [JsonInclude]
        public string MiddleName { set; get; }

        public TeacherItem(string _name, string _surname, string _middleName, string _id)
        {
            Name = _name;
            Surname = _surname;
            MiddleName = _middleName;
            Id = _id;
        }
        public TeacherItem() { }
    }
}
