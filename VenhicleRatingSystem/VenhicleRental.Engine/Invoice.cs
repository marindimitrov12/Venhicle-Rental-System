using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenhicleRental.Engine.Interfaces;
using VenhicleRental.Models.Constants;
using VenhicleRental.Models.Enums;
using VenhicleRental.Models.InputModels;

namespace VenhicleRental.Engine
{
    public class Invoice : IInvoice
    {
        private readonly ILogger _logger;
        private readonly IInsuranceCalculator _insuranceCalculator;
        private readonly IRentCalculator _rentCalculator;
        private readonly InputModel _model;

        public Invoice(ILogger logger, IInsuranceCalculator insuranceCalculator, IRentCalculator rentCalculator, InputModel model)
        {
            _logger = logger;
            _insuranceCalculator = insuranceCalculator;
            _rentCalculator = rentCalculator;
            _model = model;
        }

        public void GetTotal()
        {
            var currentTime = _model.CurrentTime;
            decimal rentWithoutDiscount = 0.0m;
            decimal rentWithDiscount = 0.0m;
            decimal insurance = 0.0m;

            if (_model.EndDate > currentTime)
            {
                var daysWithoutDiscount = (currentTime - _model.StartDate).Days;
                rentWithoutDiscount = _rentCalculator.Calculate(daysWithoutDiscount, _model);
                insurance = _insuranceCalculator.Calculate(daysWithoutDiscount, _model);

                var daysWithDiscount = (_model.EndDate - currentTime).Days;
                rentWithDiscount = _rentCalculator.CalculateHalfPrice(daysWithDiscount, daysWithoutDiscount, _model);
            }
            else
            {
                rentWithoutDiscount = _rentCalculator.Calculate(_model.TotalDays.Days, _model);
                insurance = _insuranceCalculator.Calculate(_model.TotalDays.Days, _model);
            }

            var totalRent = rentWithoutDiscount + rentWithDiscount;
            var total = totalRent + insurance;

            _logger.Log($"Total: {total} insurance: {insurance} Rent: {totalRent}");
        }
    }
}
