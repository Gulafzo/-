using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BusesInTown.TownWatchUtility
{
    internal class TownWatch : TownWatchSingleProxy, ITownClock<object>//  класс TownWatch который наследует от класса TownWatchSingleProxy
    {
        public DateTime TownTime { get; private set; }// свойство  будет хранить текущее время города
        public TimeSpan TownWatchSleepTime { get; } //  свойство  будет хранить время задержки

        public event EventHandler<TimeEventArgs> TimeEventOccured;// Объявляем событие TimeEventOccured типа EventHandler<TimeEventArgs>, которое будет вызываться при наступлении определенного времени

        private List<TimeEventArgs> _timeEvents;// Объявляем приватное поле _timeEvents типа List<TimeEventArgs>, которое будет хранить события, наступление которых нужно отслеживать
        private Thread _timeThread; // Объявляем приватное поле _timeThread типа Thread, которое будет использоваться для запуска потока, который будет обновлять время города

        private object _timeEventsLockObject = new object();// Объявляем приватное поле _timeEventsLockObject типа object, которое будет использоваться для блокировки доступа к списку событий _timeEvents из р

        public TownWatch(DateTime townTime, TimeSpan townWatchSleepTime)//конструктор принимает текущее время города
        {        
            TownTime = townTime;//  свойство
            TownWatchSleepTime = townWatchSleepTime;//  свойство            
            _timeEvents = new List<TimeEventArgs>(); //  список событий           
             _timeThread = new Thread(TimeThreadWorker); //  поток\
        }
      
        public override void Start()
        {
            base.Start();
            _timeThread.Start();
        }

        public override void Stop()
        {
            base.Stop();
        }

        public void AddTimeEvent(object sender, TimeSpan timeToWait) //  метод будет добавлять новое событие в список событий       
        {
           
            lock (_timeEventsLockObject) // Блокируем доступ к списку событий  из других потоков
            {
                // Добавляем новое событие в список событий  
                _timeEvents.Add(new TimeEventArgs(sender, timeToWait));
                _timeEvents.Sort();//сортировка  по времени
            }

        }
        private void TimeThreadWorker()
        {
            while (_isRunning)//  цикл пока поток не  остановлен
            {
                
                Action startEventAction = () => { };//  переменную будет хранить метод который надо вызвать при наступлении события

                
                lock (_timeEventsLockObject)// Блокируем доступ к списку событий _timeEvents из других потоков
                {
                    
                    if (_timeEvents.Count == 0)//  список  пустой то цикл продолжается
                    {
                        continue;
                    }                   

                    TimeEventArgs timeEvent = _timeEvents.First();//  первое событие из списка событий 

                    foreach (TimeEventArgs timeEventArgs in _timeEvents)// Уменьшение время ожидания для всех событий
                    {
                        timeEventArgs.DecreaseRestTimeToWait(timeEvent.TimeToWait);
                    }

                    TownTime += timeEvent.TimeToWait;// Увеличиваем текущее время города на время ожидания первого события

                    _timeEvents = _timeEvents.Skip(1).ToList(); // Удаляем первое событие из списка событий _timeEvents
                    
                    startEventAction = () => TimeEventOccured?.Invoke(timeEvent.Sender, timeEvent);  // Присваиваем переменной startEventAction метод, который нужно вызвать при наступлении события
                }

                startEventAction(); // Вызов метода  наступлении события

                Thread.CurrentThread.Join(TownWatchSleepTime);// Задерживаем поток на время задержки
            }
        }
    }
}


