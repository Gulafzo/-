﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusesInTown.Routes
{
    internal interface IRoute // интерфейс
    {
        int RouteNumber { get; }//возвращает целочисленное значение.
    }
}
