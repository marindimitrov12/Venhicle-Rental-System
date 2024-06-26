﻿using VenhicleRental.Engine.Interfaces;
using VenhicleRental.Models.Constants;
using VenhicleRental.Models.Enums;
using VenhicleRental.Models.InputModels;

namespace VenhicleRental.Engine.Calculators
{
    public class InsuranceCalculator : IInsuranceCalculator
    {
        public decimal Calculate(int totalDays, InputModel model)
        {
            decimal totalInsurance = 0.0m;
            decimal insuranceWithNoDiscount = totalDays * GetInsuranceCostPerDay(model.Type) * model.Value;
              model.InsurancePerday = GetInsuranceCostPerDay(model.Type) * model.Value;
            

            switch (model.Type)
            {
                case VenhicleTypes.car:
                    totalInsurance = CalculateCarInsurance(insuranceWithNoDiscount, model);
                    break;
                case VenhicleTypes.motorcycle:
                    totalInsurance = CalculateMotorcycleInsurance(insuranceWithNoDiscount, model);
                    break;
                case VenhicleTypes.cargoVan:
                    totalInsurance = CalculateCargoVanInsurance(insuranceWithNoDiscount, model);
                    break;
            }
            model.EarlyDiscountForInsurance = ((GetInsuranceCostPerDay(model.Type) * model.Value) - model.InsuranceDiscountPerDay) * (model.EndDate - model.CurrentTime).Days;

            return totalInsurance;
        }

        private decimal GetInsuranceCostPerDay(VenhicleTypes type)
        {
            return type switch
            {
                VenhicleTypes.car => InsuranceCostPerDay.Car,
                VenhicleTypes.motorcycle => InsuranceCostPerDay.Motor,
                VenhicleTypes.cargoVan => InsuranceCostPerDay.Van,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private decimal CalculateCarInsurance(decimal insuranceWithNoDiscount, InputModel model)
        {
            if ((int)model.Safety >= 4)
            {
                var discount = insuranceWithNoDiscount * InsuranceCostFluctuations.ReduceHighSafetyRatingForCars;
                model.EarlyDiscountForInsurance= discount;
                model.InsuranceDiscountPerDay= GetInsuranceCostPerDay(model.Type) * model.Value * InsuranceCostFluctuations.ReduceHighSafetyRatingForCars;
                return insuranceWithNoDiscount - discount;
            }
            return insuranceWithNoDiscount;
        }

        private decimal CalculateMotorcycleInsurance(decimal insuranceWithNoDiscount, InputModel model)
        {
            if (model.Age < 25)
            {
                var fee = insuranceWithNoDiscount * InsuranceCostFluctuations.IncreaseMotorRiderUnder25;
                model.InsuranceAdditionPerDay = GetInsuranceCostPerDay(model.Type) * model.Value* InsuranceCostFluctuations.IncreaseMotorRiderUnder25;
                return insuranceWithNoDiscount + fee;
            }
            return insuranceWithNoDiscount;
        }

        private decimal CalculateCargoVanInsurance(decimal insuranceWithNoDiscount, InputModel model)
        {
            if (model.Experiance > 5)
            {
                var discount = insuranceWithNoDiscount * InsuranceCostFluctuations.ReduceVanDriverHasMoreThan5Years;
               
                model.InsuranceDiscountPerDay = GetInsuranceCostPerDay(model.Type) * model.Value * InsuranceCostFluctuations.ReduceVanDriverHasMoreThan5Years;
                return insuranceWithNoDiscount - discount;
            }
            return insuranceWithNoDiscount;
        }
    }
}
