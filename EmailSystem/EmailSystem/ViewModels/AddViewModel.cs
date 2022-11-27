using EmailSystem.DataBase.Models;

namespace EmailSystem.ViewModels
{
    public class AddViewModel
    {
        public string From { get; set; }

        public string Tittle { get; set; }
        public string Message { get; set; }

        public bool Status { get; set; }
        public TargetEmail TargetEmail { get; set; }
    }
}
