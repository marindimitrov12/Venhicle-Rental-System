using VenhicleRental.Engine.Interfaces;
using VenhicleRental.Models.Constants;
using VenhicleRental.Models.Enums;
using VenhicleRental.Models.InputModels;

namespace VenhicleRental.Engine
{
    public class RentCalculator:IRentCalculator
    {
        public decimal Calculate(int totalDays, InputModel model)
        {
            return totalDays < 7
                ? totalDays * GetDailyCost(model.Type, true)
                : totalDays * GetDailyCost(model.Type, false);
        }

        public decimal CalculateHalfPrice(int totalDays, int prevDays, InputModel model)
        {
            return totalDays + prevDays < 7
                ? totalDays * (GetDailyCost(model.Type, true) / 2)
                : totalDays * (GetDailyCost(model.Type, false) / 2);
        }

        private decimal GetDailyCost(VenhicleTypes type, bool isWeekOrLess)
        {
            return type switch
            {
                VenhicleTypes.car => isWeekOrLess ? RentedForWeekOrLessDailyCost.Car : RentedForMoreThanWeekDailyCost.Car,
                VenhicleTypes.motorcycle => isWeekOrLess ? RentedForWeekOrLessDailyCost.Motorcycle : RentedForMoreThanWeekDailyCost.Motorcycle,
                VenhicleTypes.cargoVan => isWeekOrLess ? RentedForWeekOrLessDailyCost.CargoVan : RentedForMoreThanWeekDailyCost.CargoVan,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
