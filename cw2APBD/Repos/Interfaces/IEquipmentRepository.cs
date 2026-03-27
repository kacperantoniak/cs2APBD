using cw2APBD.Domain.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2APBD.Repos.Interfaces
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        List<Equipment> GetAvailable();
    }
}
