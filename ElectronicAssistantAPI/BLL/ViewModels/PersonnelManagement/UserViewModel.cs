namespace ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Roles { get; set; }
        public byte[]? Image { get; set; }
        public string? Position { get; set; }

        public UserViewModel() { }
        public UserViewModel(string id, string? fullName, string? email, string? roles, byte[]? image, string? position)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Roles = roles;
            Image = image;
            Position = position;
        }
    }
}
