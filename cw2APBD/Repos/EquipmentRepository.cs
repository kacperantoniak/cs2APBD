using cw2APBD.Domain.Equipment;
using cw2APBD.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2APBD.Repos
{
    public class EquipmentRepository : GenericRepository<Equipment>, IEquipmentRepository
    {
        public List<Equipment> GetAvailable()
        {
            return _storage.Where(e => e.Status == EquipmentStatus.Available).ToList();
        }
    }
}
