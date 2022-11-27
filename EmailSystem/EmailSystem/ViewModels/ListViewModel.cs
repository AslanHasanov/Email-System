namespace EmailSystem.ViewModels
{
    public class ListViewModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Tittle { get; set; }
        public string Message { get; set; }


        public ListViewModel(string from, string to, string tittle, string message)
        {
            From = from;
            To = to;
            Tittle = tittle;
            Message = message;

        }
    }
}
