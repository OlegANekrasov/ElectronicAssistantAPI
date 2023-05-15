using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;

namespace ElectronicAssistantAPI.DAL.Extentions
{
    public static class UserFromModel
    {
        public static User Convert(this User user, UpdateUser model)
        {
            user.Image = model.Image;
            user.LastName = model.LastName;
            user.MiddleName = model.MiddleName;
            user.FirstName = model.FirstName;
            user.Email = model.Email;
            user.BirthDate = model.BirthDate.ToUniversalTime();
            user.UserName = model.UserName;
            user.About = model.About;
            user.PositionId = model.PositionId;

            return user;
        }
    }
}
