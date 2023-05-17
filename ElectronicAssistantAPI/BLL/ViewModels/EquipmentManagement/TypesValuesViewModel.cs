using ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ElectronicAssistantAPI.BLL.ViewModels.EquipmentManagement
{
    public class TypesValuesViewModel
    {
        public List<string> TypesValues { get; set; } = new List<string>();
        public TypesValuesViewModel()
        {
            TypesValues.Add("Да/Нет");
            TypesValues.Add("Целое число");
            TypesValues.Add("Десятичное дробное число");
            TypesValues.Add("Строка");
            TypesValues.Add("Дата/Время");
        }
    }
}
