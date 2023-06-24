using System.Security.Cryptography.X509Certificates;

namespace REST_API_TEST2
{
    public class TableRow:IComparable<TableRow>
    {
        public string time { get; set; }
        public Dictionary<string,string> info { get; set; }
        public TableRow(string time)
        {
            this.time = time;
            this.info = new Dictionary<string, string>();
            info.Add("time", time);
        }
        public void AddInfo(string key, string value)
        {
            if (info.ContainsKey(key))
            {
                info[key] +="\n" + value;
            }
            else 
            {
                info.Add(key, value);
            }
        }

        public int CompareTo(TableRow? other)
        {
            TimeOnly time = TimeOnly.Parse(other.time);
            TimeOnly time1 = TimeOnly.Parse(this.time);
            return time1.CompareTo(time);
        }
    }
}
