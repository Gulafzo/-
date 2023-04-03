using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusesInTown.TownWatchUtility
{
    internal interface ITownClock<T>// интерфейс ITownClock с параметром типа T
    {
        DateTime TownTime { get; }//  свойства TownTime тип DateTime
        TimeSpan TownWatchSleepTime { get; }//  свойства TownWatchSleepTime тип TimeSpan

        event EventHandler<TimeEventArgs> TimeEventOccured; //  события TimeEventOccured тип EventHandler<TimeEventArgs>

        void Start();
        void Stop();

        void AddTimeEvent(T sender, TimeSpan timeToWait);//  метод AddTimeEvent 
    }
}
