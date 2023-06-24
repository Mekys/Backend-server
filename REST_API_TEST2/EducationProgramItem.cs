namespace REST_API_TEST2
{
    public class EducationProgramItem
    {
        public string value { get; set; }
        public string label { get; set; }
        public string acr { get; set; }

        public EducationProgramItem(string value, string label)
        {
            this.value = value;
            this.label = label;
            acr = new string(
      label.Where((c, i) => c != ' ' && (i == 0 || label[i - 1] == ' '))
      .ToArray()
    ).ToUpper();
        }
    }
}
