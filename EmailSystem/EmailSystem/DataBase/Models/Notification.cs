namespace EmailSystem.DataBase.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string FromEmail { get; set; }
        public int TargetEmailId { get; set; }
        public TargetEmail TargetEmail { get; set; }
    }
}
