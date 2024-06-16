using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenhicleRental.Models.InputModels;

namespace VenhicleRental.Engine.Interfaces
{
    public interface IInsuranceCalculator
    {
        decimal Calculate(int totalDays, InputModel model);
    }
}
