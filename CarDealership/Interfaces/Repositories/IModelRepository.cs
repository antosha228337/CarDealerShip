using CarDealership.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Interfaces.Repositories
{
    internal interface IModelRepository
    {
        List<ModelDTO> GetAll();
        void Update(ModelDTO model);
        bool Delete(int id);
        void AddModel(ModelDTO model);
    }
}
