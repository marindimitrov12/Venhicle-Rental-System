using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenhicleRental.Engine.Interfaces;

namespace VenhicleRental.Engine
{
    public class Invoice : IInvoice
    {
        private readonly ILogger _logger;
        public Invoice(ILogger logger)
        {
            _logger= logger;
        }
        public Task Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
