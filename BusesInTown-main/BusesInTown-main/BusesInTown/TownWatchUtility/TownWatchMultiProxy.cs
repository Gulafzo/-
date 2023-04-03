using System;

namespace BusesInTown.TownWatchUtility
{
    
    internal class TownWatchMultiProxy : ITownClock<TownWatchSingleProxy>//  класс  реализует интерфейс ITownClock<TownWatchSingleProxy>
    {
        TownWatch _internalTownWatch; 

        
        public DateTime TownTime => _internalTownWatch.TownTime; // возвращает время города
        public TimeSpan TownWatchSleepTime => _internalTownWatch.TownWatchSleepTime; // Ввзвращает время 

        public event EventHandler<TimeEventArgs> TimeEventOccured; //  событие TimeEventOccured 

      
        public TownWatchMultiProxy(int startHourOnTownClock, TimeSpan townWatchThreadSleepTime)  //  конструктор  класса
        {
            var townWatchStartTime = DateTime.Now; // переменная которя ее значение равным текущему времени

            townWatchStartTime = townWatchStartTime.AddHours(-townWatchStartTime.Hour + 8); //  часы в 8 утра
            townWatchStartTime = townWatchStartTime.AddMinutes(-townWatchStartTime.Minute); //  минуты в 0
            townWatchStartTime = townWatchStartTime.AddSeconds(-townWatchStartTime.Second); //  секунды в 0

            _internalTownWatch = new TownWatch(townWatchStartTime, townWatchThreadSleepTime); // инициализируем поле _internalTownWatch новым экземпляром TownWatch
            _internalTownWatch.TimeEventOccured += _internalTownWatch_TimeEventOccured; // подписываемся на событие TimeEventOccured объекта _internalTownWatch             
        }

        private void _internalTownWatch_TimeEventOccured(object sender, TimeEventArgs e)//  метод-обработчик события  для объекта _internalTownWatch
        {
            ((TownWatchSingleProxy)sender).Invoke(
                () => TimeEventOccured?.Invoke(sender, e)
                );
        }

        public void AddTimeEvent(TownWatchSingleProxy sender, TimeSpan timeToWait)//  метод  для добавления нового события
        {
            _internalTownWatch.Invoke(() => _internalTownWatch.AddTimeEvent(sender, timeToWait));// добавляем новое событие в объект _internalTownWatch
        }

        public void Start()// для запуска 

        {
            _internalTownWatch.Start(); // Запускаем объект _internalTownWatch, вызывая его метод Start
        }

        public void Stop()// для остановки
        {
            _internalTownWatch.Stop();// Останавливаем объект _internalTownWatch, вызывая его метод Stop
        }
    }
}








