﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenhicleRental.Engine.Interfaces
{
    public interface IInvoice
    {
        Task Calculate();
    }
}
