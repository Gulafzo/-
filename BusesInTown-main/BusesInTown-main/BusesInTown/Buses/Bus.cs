using BusesInTown.Routes;
using BusesInTown.TownWatchUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusesInTown.Buses
{
    internal class Bus : TownWatchSingleProxy
    {
        public event EventHandler BusOnStartStation;//  событие  будет вызываться при прибытии автобуса на начальную станцию
        public event EventHandler BusOnEndStation; //   на конечную станцию

        private static int _lastBusId = 0; //  переменную  будет хранить последний использованный идентификатор автобуса
        private readonly IRoute _route;// _route   будет хранить маршрут автобуса

        public int BusId { get; }//  свойство которое будет хранить идентификатор автобуса

        public int BusNumber => _route.RouteNumber; //  свойство  будет возвращать номер маршрута 

        public Bus(IRoute route)//  конструктор который принимает в качестве параметра маршрут автобуса
        {
            BusId = ++_lastBusId; // Инициализируем свойство BusId последним использованным идентификатором автобуса и увеличиваем 
            _route = route; // Инициализируем член _route переданным в конструкторе маршрутом автобуса
        }
        public override void Start() // Переопределяем метод Start класса TownWatchSingleProxy
        {
            base.Start(); //  метод Start базового класса
            Invoke(() => BusOnStartStation?.Invoke(this, EventArgs.Empty)); // Вызываем событие BusOnStartStation
        }
        public override void Stop() // Переопределяем метод Stop класса TownWatchSingleProxy
        {
             base.Stop(); //  метод Stop базового класса
        }
    }
}
