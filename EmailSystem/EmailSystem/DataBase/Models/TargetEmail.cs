namespace EmailSystem.DataBase.Models
{
    public class TargetEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public List<Notification> Notifications { get; set; }
    }
}
