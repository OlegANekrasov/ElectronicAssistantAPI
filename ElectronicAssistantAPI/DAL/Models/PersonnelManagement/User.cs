using Microsoft.AspNetCore.Identity;

namespace ElectronicAssistantAPI.DAL.Models.PersonnelManagement
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public DateTime? BirthDate { get; set; }

        public byte[]? Image { get; set; }

        public string? About { get; set; }

        public string? PositionId { get; set; }
        public Position? Position { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + MiddleName + " " + LastName;
        }
    }
}
