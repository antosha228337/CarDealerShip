using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DTO
{
    public class EngineTypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public EngineTypeDTO(EngineType t)
        {
            Id = t.Id;
            Name = t.Name;
        }
    }
}
