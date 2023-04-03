﻿using BusesInTown.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusesInTown.Routes
{
    internal class Route_10 : BaseRoute//  класс Route_10 наследуется от класса BaseRoute  реализует интерфейс IRoute
    {
        public override int RouteNumber => 10;//  свойство будет возвращать номер маршрута

        public Route_10() : base()   //  конструктор класса Route_10
        {
            StationToStationTime[0] = 10;//  время между станциями
            StationToStationTime[StationToStationTime.Length - 1] = 15;
            Stations[0] = new Station("Start 10"); //  начальную и конечную станции
            Stations[Stations.Length - 1] = new Station("End 10");
        }
    }
}

