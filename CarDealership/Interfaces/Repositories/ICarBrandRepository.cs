using CarDealership.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Interfaces.Repositories
{
    interface ICarBrandRepository
    {
        List<CarBrandDTO> GetAll();
    }

}
