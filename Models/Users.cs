namespace Backend.Models
{
    /// <summary>
    /// User class that will be implemented into database
    /// </summary>
    public class User
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int StreetNumber { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string SSN { get; set; } = string.Empty;
        public string PictureThumbnail { get; set; } = string.Empty;
    }
}