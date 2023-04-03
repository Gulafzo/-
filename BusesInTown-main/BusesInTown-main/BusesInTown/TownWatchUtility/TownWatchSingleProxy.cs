using System;
using System.Collections.Generic;
using System.Threading;

namespace BusesInTown.TownWatchUtility
{
    internal class TownWatchSingleProxy
    {
        private Queue<Action> _actionQueue;//  поле с именем _actionQueue
        private Thread _currentThread;//  поле с именем _currentThread
        private Object _actionQueueLockObj;// поле с именем _actionQueueLockObj 

        protected bool _isRunning; //  поле с именем _isRunning типа bool

        public bool IsRunning => _isRunning;//  свойство только для чтения

        public TownWatchSingleProxy()//  конструктор 
        {
            _actionQueue = new Queue<Action>();//  поле _actionQueue новым экземпляром Queue<Action>
            _currentThread = new Thread(ThreadFunction);//  поле _currentThread новым экземпляром Thread
            _isRunning = false; //  значение поля _isRunning в false
            _actionQueueLockObj = new Object(); // Инициализируем поле _actionQueueLockObj новым экземпляром Object

        }

        public void Invoke(Action actionToInvoke)//  метод   принимает делегат Action 
        {
            lock (_actionQueueLockObj)// получаем блокировку на объекте _actionQueueLockObj
            {
                _actionQueue.Enqueue(actionToInvoke);// добавляем делегат  в очередь 
            }
        }

        public virtual void Start()
        {
            _isRunning = true;_isRunning = true; // Устанавливаем значение поля _isRunning в true
            _currentThread.Start();// запуск потока _currentThread
        }

        public virtual void Stop()
        {
            _isRunning = false;//  значение поля _isRunning в false
        }

        private void ThreadFunction()
        {
            while (_isRunning)// Входим в бесконечный цикл, пока значение _isRunning равно true
            {
                if (_actionQueue.Count > 0) // Если в очереди _actionQueue есть элементы
                {
                    lock (_actionQueueLockObj)
                    {
                        _actionQueue.Dequeue()();
                    }
                }

                Thread.Sleep(100);//перед повторением цикла засыпаем на 100 миллисекунд 
            }
        }
    }
}
