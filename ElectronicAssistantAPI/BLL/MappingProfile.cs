using AutoMapper;
using ElectronicAssistantAPI.BLL.Models.CommonData;
using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.EquipmentStatus;
using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.TypeEquipment;
using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.BLL.ViewModels.CommonData;
using ElectronicAssistantAPI.BLL.ViewModels.EquipmentManagement.EquipmentStatus;
using ElectronicAssistantAPI.BLL.ViewModels.EquipmentManagement.TypeEquipment;
using ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;
using System.Xml;

namespace ElectronicAssistantAPI.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddPositionViewModel, AddPosition>();
            CreateMap<DelPositionViewModel, DelPosition>();
            CreateMap<UpdatePositionViewModel, UpdatePosition>();

            CreateMap<User, UserCompleteViewModel>();
            CreateMap<UpdateUserViewModel, UpdateUser>();
            CreateMap<UpdateUserPasswordViewModel, UpdateUserPassword>();
            CreateMap<UpdateUserRoleViewModel, UpdateUserRole>();
            CreateMap<UpdateUser, User>();

            CreateMap<AddRoomViewModel, AddRoom>();
            CreateMap<DelRoomViewModel, DelRoom>();
            CreateMap<UpdateRoomViewModel, UpdateRoom>();

            CreateMap<AddEquipmentStatusViewModel, AddEquipmentStatus>();
            CreateMap<DelEquipmentStatusViewModel, DelEquipmentStatus>();
            CreateMap<UpdateEquipmentStatusViewModel, UpdateEquipmentStatus>();

            CreateMap<AddTypeEquipmentViewModel, AddTypeEquipment>();
            CreateMap<DelTypeEquipmentViewModel, DelTypeEquipment>();
            CreateMap<UpdateTypeEquipmentViewModel, UpdateTypeEquipment>();
        }
    }
}
