using CarDealership.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Interfaces.Repositories
{
    internal interface ICarRepository
    {
        List<CarDTO> GetCarsByModification(int modification_id);
        CarDTO GetAvailableByModification(int mod_id);
        List<CarDTO> GetAll();
        bool Delete(int id);
        void Add(CarDTO car);
        void Update(CarDTO car);
        CarDTO GetById(int id);
    }
}
