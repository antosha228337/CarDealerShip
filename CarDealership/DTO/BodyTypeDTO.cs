using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DTO
{
    public class BodyTypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public BodyTypeDTO(BodyType bt)
        {
            Id = bt.Id;
            Name = bt.Name;
        }
    }
}
