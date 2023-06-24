namespace REST_API_TEST2
{
    public class LocateItem
    {
        public string Id { get; set; }
        public string Auditorium { get; set; }
        public string Building { get; set; }
        public LocateItem(string id, string auditorium, string building)
        {
            Id = id;
            Auditorium = auditorium;
            Building = building;
        }
    }
}
