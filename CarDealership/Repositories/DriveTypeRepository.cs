using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repositories
{
    class DriveTypeRepository : IDriveTypeRepository
    {
        CarDealershipMainContext db = new();


        public List<DriveTypeDTO> GetAll()
        {
            return db.DriveTypes.Select(i => new DriveTypeDTO(i)).ToList();
        }
    }
}
