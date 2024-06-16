using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenhicleRental.Engine.Interfaces;
using VenhicleRental.Models.InputModels;

namespace VenhicleRental.Engine
{
    public class Logger : ILogger
    {
     
        public async Task Log(InputModel model, decimal total, decimal incurance, decimal totalRent)
        {
            Console.WriteLine(GenerateInvoice(model,total,incurance,totalRent));
        }
        private string GenerateInvoice(InputModel model, decimal total, decimal incurance, decimal totalRent)
        {
            var message = new StringBuilder();
            message.AppendLine("XXXXXXXXXXX");
            message.AppendLine($"Date:{model.CurrentTime:yyyy-MM-dd}");
            message.AppendLine($"Customer Name:{model.CustomerName}");
            message.AppendLine($"Rented Vehicle:{model.Brand} {model.Model}");
            message.AppendLine();
            message.AppendLine($"Reservation start date:{model.StartDate:yyyy-MM-dd}");
            message.AppendLine($"Reservation end date:{model.EndDate:yyyy-MM-dd}");
            message.AppendLine($"Reserved rental days:{(model.EndDate-model.StartDate).Days}");
            message.AppendLine();
            message.AppendLine($"Actual return date:{model.CurrentTime:yyyy-MM-dd}");
            message.AppendLine($"Actual rental days:{(model.CurrentTime-model.StartDate).Days}");
            message.AppendLine();
            
            message.AppendLine($"Rent cost per day:{model.RentPerday:F2}");
            if (model.InsuranceAdditionPerDay != 0.0m)
            {
                message.AppendLine($"Initial insurance per day:{model.InsurancePerday:F2}");
                message.AppendLine($"Insurance addition per day:{model.InsuranceAdditionPerDay:F2}");
                message.AppendLine($"Insurance per day:{model.InsurancePerday + model.InsuranceAdditionPerDay:F2}");
            }
            else if(model.InsuranceDiscountPerDay!=0.0m)
            {
                message.AppendLine($"Initial insurance per day:{model.InsurancePerday:F2}");
                message.AppendLine($"Insurance discount per day:{model.InsuranceDiscountPerDay:F2}");
                message.AppendLine($"Insurance per day:{model.InsurancePerday - model.InsuranceDiscountPerDay:F2}");
            }
            else if (model.InsuranceAdditionPerDay == 0&& model.InsuranceDiscountPerDay == 0.0m)
            {
                message.AppendLine($"Insurance per day:{model.InsurancePerday:F2}");
            }
            message.AppendLine();


            if (model.EarlyDiscountForRent!=0.0m&&model.EarlyDiscountForInsurance!=0.0m)
            {
                message.AppendLine($"Early return discount for rent:{model.EarlyDiscountForRent:F2}");
                message.AppendLine($"Early return discount for insurance:{model.EarlyDiscountForInsurance:F2}");
            }
           

            message.AppendLine();
            message.AppendLine($"Total rent:{totalRent:F2}");
            message.AppendLine($"Total insurance:{incurance:F2}");
            message.AppendLine($"Total:{total:F2}");
            message.AppendLine("XXXXXXXXXXX");

            return message.ToString();
        }
    }
}
