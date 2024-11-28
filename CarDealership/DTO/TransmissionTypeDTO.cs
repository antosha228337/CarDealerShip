using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DTO
{
    public class TransmissionTypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public TransmissionTypeDTO(TransmissionType t)
        {
            Id = t.Id;
            Name = t.Name;
        }
    }
}
