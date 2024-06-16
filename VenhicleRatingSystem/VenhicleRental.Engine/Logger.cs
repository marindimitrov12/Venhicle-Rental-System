using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenhicleRental.Engine.Interfaces;

namespace VenhicleRental.Engine
{
    public class Logger : ILogger
    {
        public async Task Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
