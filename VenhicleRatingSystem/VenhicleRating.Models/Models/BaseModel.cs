using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenhicleRental.Models.Models
{
    public abstract class BaseModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TimeSpan TotalDays => EndDate-StartDate;

       
    }
}
