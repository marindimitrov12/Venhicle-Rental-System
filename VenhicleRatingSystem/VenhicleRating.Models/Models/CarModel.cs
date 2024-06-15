using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenhicleRental.Models.Enums;

namespace VenhicleRental.Models.Models
{
    public class CarModel:BaseModel
    {
        public SafetyRatings Safety { get; set; }
    }
}
