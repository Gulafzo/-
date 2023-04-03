using BusesInTown.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusesInTown.Routes
{
    internal class Route_15 : BaseRoute//  класс Route_15 наследуется от класса BaseRoute  реализует интерфейс IRoute
    {
        public override int RouteNumber => 15; // свойство  будет возвращать номер маршрута

        public Route_15() : base()// конструктор класса Route_15
        {
            StationToStationTime[0] = 5; //  время между станциями 
            StationToStationTime[StationToStationTime.Length - 1] = 20;
            Stations[0] = new Station("Start 15"); //  начальную и конечную станции 
            Stations[Stations.Length - 1] = new Station("End 15");
        }

    }
}
