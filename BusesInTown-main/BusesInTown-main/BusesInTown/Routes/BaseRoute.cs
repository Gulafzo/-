using BusesInTown.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusesInTown.Routes
{
    abstract class BaseRoute : IRoute//  абстрактный класс реализует интерфейс IRoute
    {
        public abstract int RouteNumber { get; } //   свойство которое будет хранить номер маршрута 

        protected int[] StationToStationTime { get; } // свойство будет хранить время в пути между станциями
        protected Station[] Stations { get; } //   свойство  будет хранить станции маршрута
 
        public BaseRoute()
        {
            StationToStationTime = new[] { 0, 5, 10, 7, 0 };// Инициализируем свойство StationToStationTime массивом int, содержащим время в пути между станциями
            Stations = new Station[] { //   станции маршрута
                null,// start
                new Station("station 1"),
                new Station("station 2"),
                new Station("station 3"),
                new Station("station 4"),
                null,//finish
            };
        }
    }
}

