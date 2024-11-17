namespace LoginApp.Models
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string? Username { get; set; }
        public virtual string? Password { get; set; }
    }
}
