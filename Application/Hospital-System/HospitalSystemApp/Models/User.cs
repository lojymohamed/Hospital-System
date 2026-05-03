namespace HospitalSystemApp.Models
{
    
    public class User : Person
    {
        
        public string Role { get; set; }

        public User() : base() { }
    }
}