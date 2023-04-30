﻿using AutoMapper;
using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
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
        }
    }
}
