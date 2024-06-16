using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenhicleRental.Models.Constants
{
    public class InsuranceCostFluctuations
    {
        public const decimal ReduceHighSafetyRatingForCars = 10.00m / 100.00m;

        public const decimal IncreaseMotorRiderUnder25 = 20.00m / 100.00m;

        public const decimal ReduceVanDriverHasMoreThan5Years = 15.00m / 100.00m;

    }
}
