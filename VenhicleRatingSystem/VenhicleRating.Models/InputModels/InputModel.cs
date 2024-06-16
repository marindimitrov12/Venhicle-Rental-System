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
        public decimal  InsurancePerday { get; set; }

        public decimal InsuranceAdditionPerDay { get; set; }
        public decimal InsuranceDiscountPerDay { get; set; }
        public decimal  RentPerday { get; set; }

        public decimal EarlyDiscountForRent { get; set; }
        public decimal EarlyDiscountForInsurance { get; set; }

        public VenhicleTypes Type { get; set; }

        public DateTime CurrentTime { get; set; }

    }
}
