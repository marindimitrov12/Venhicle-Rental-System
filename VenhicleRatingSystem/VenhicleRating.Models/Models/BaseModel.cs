using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenhicleRental.Models.Models
{
    public class BaseModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Value { get; set; }
        public DateTime RentalPeriod { get; set; }
    }
}
