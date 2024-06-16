using Microsoft.Extensions.DependencyInjection;
using VenhicleRental.Engine;
using VenhicleRental.Engine.Interfaces;
using VenhicleRental.Models.Enums;
using VenhicleRental.Models.InputModels;

namespace VenhicleRental.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
               .AddSingleton<ILogger, Logger>()
               .AddTransient<IInvoice, Invoice>()
               .AddTransient<IInsuranceCalculator,InsuranceCalculator>()
               .AddTransient<IRentCalculator,RentCalculator>()
               .AddSingleton(new InputModel
               {
                   Type = VenhicleTypes.cargoVan,
                   Value = 20000.00m,
                   Safety = SafetyRatings.three,
                   Age = 20,
                   Experiance = 8,
                   StartDate = DateTime.Parse("2024-06-03"),
                   EndDate = DateTime.Parse("2024-06-18"),
                   CurrentTime = DateTime.Parse("2024-06-13"),
               }) 
               .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger>();
           

           
            var invoice = serviceProvider.GetService<IInvoice>();

             invoice?.GetTotal();

            Console.ReadLine();
        }
    }
}