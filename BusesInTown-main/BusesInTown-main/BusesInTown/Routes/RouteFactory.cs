using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusesInTown.Routes
{
    internal class RouteFactory
    {
        public static BaseRoute CreateRoute(int routeNomber) // статический метод CreateRoute с параметром routeNomber
        {
            switch (routeNomber)//   выбор объекта класса BaseRoute
            {
                case 10:// если 10 возвращается  Route_10
                    return new Route_10();
                case 15:// если 15 возвращается  Route_15
                    return new Route_15();
                case 18:// если 18 возвращается  Route_18
                    return new Route_18();
                default:// если  routeNomber не соответствует ни одному из  случаев выбрасывается исключение
                    throw new ArgumentOutOfRangeException(
                        $"Can not create route with number {routeNomber}");
            }
        }

    }
}
