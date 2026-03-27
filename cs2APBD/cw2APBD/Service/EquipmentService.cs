using cw2APBD.Domain.Equipment;
using cw2APBD.Repos.Interfaces;
using cw2APBD.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2APBD.Service
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _repository;

        public EquipmentService(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        public void AddEquipment(Equipment equipment)
        {
            _repository.Add(equipment);
        }

        public Equipment? GetEquipmentById(string id)
        {
            return _repository.GetById(id);
        }

        public List<Equipment> GetAllEquipment()
        {
            return _repository.GetAll();
        }

        public List<Equipment> GetAvailableEquipment()
        {
            return _repository.GetAvailable();
        }

        public void UpdateEquipmentStatus(Equipment equipment, EquipmentStatus status)
        {
            equipment.Status = status;
            _repository.Update(equipment);
        }

        public bool IsEquipmentAvailable(Equipment equipment)
        {
            return equipment != null && equipment.Status == EquipmentStatus.Available;
        }
    }
}
