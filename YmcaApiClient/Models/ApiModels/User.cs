namespace YMCA3.YmcaApiClient.Models.ApiModels
{
    public class User
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public string? Username { get; set; }

        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }

        public string? City { get; set; }

        public string? Password { get; set; }

        public MembershipType Member { get; set; }

        public bool Volunteer { get; set; }
    }
}