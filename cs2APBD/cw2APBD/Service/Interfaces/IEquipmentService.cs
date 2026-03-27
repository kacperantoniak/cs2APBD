using cw2APBD.Domain.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2APBD.Service.Interfaces
{
    public interface IEquipmentService
    {
        void AddEquipment(Equipment equipment);
        Equipment? GetEquipmentById(string id);
        List<Equipment> GetAllEquipment();
        List<Equipment> GetAvailableEquipment();
        void UpdateEquipmentStatus(Equipment equipment, EquipmentStatus status);
        bool IsEquipmentAvailable(Equipment equipment);
    }
}
