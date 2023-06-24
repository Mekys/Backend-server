namespace REST_API_TEST2
{
    public class UserTableCell
    {
        public string day { get; set; }
        public List<TableRow> data { get; set; }
        public UserTableCell() 
        {
            data = new List<TableRow>();
        }
        public UserTableCell(string day)
        {
            this.day = day;
            this.data = new List<TableRow>();
        }





        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            return (obj as UserTableCell).day.Equals(day);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            return day.GetHashCode();
        }
    }
}
