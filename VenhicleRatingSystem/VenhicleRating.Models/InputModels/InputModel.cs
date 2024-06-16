using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenhicleRental.Models.Enums;
using VenhicleRental.Models.Models;

namespace VenhicleRental.Models.InputModels
{
    public class InputModel:BaseModel
    {
        public decimal Experiance { get; set; }
        public SafetyRatings Safety { get; set; }

        public decimal Age { get; set; }

        public VenhicleTypes Type { get; set; }

        public DateTime CurrentTime { get; set; }

    }
}
