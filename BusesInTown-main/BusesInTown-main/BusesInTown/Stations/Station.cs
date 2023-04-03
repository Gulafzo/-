using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusesInTown.Stations
{
    internal class Station
    {
        public string StationName { get; }//  свойства StationName

        public Station(string stationName)// конструктор класса Station
        {
            StationName = stationName; // инициализация свойства StationName
        }

        public override string ToString() // переопределение метода ToString()
        {
            return $"Station -> StationName = {StationName}"; //  информация о станции
        }
    }
}
