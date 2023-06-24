namespace REST_API_TEST2
{
    public class SubjectItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public SubjectItem(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
