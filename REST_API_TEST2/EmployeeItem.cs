namespace REST_API_TEST2
{
    public class EmployeeItem
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public EmployeeItem(string _id,string _name, string _surname, string _middlename) 
        {
            Id = _id;
            Name = $"{char.ToUpper(_surname[0])}{_surname.Substring(1)} {char.ToUpper(_name[0])}.{char.ToUpper(_middlename[0])}.";
        }
        public EmployeeItem() { }
    }
}
