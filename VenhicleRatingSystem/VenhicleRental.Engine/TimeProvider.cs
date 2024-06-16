using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenhicleRental.Engine.Interfaces;

namespace VenhicleRental.Engine
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime UTCNow => DateTime.UtcNow;
    }
}
