using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusesInTown.TownWatchUtility
{
    internal class TimeEventArgs : IComparable<TimeEventArgs>//  класс  реализует интерфейс IComparable<TimeEventArgs>
    {
        public object Sender { get; } //  свойство будет хранить отправителя события
        public TimeSpan TimeToWait { get; } //  свойство с возможностью только чтения
        public TimeSpan RestTimeToWait { get; private set; } //  свойство с возможностью только записис

        public bool IsEventShouldHappenedNow => RestTimeToWait <= TimeSpan.Zero; // Объявляем свойтво которое будет возвращать true  если оставшееся время меньше или равно нулю

        public TimeEventArgs(object sender, TimeSpan timeToWait)
        {
            Sender = sender;
            TimeToWait = timeToWait;
            RestTimeToWait = new TimeSpan(timeToWait.Ticks); // Инициализируем свойство RestTimeToWait новым экземпляром TimeSpan
        }

        public void DecreaseRestTimeToWait(TimeSpan decreaseTimeSpan) //  методдля уменьшения оставшегося времени ожидания до наступления события 
        {
            RestTimeToWait -= decreaseTimeSpan;// Уменьшаем значение 
        }

        public int CompareTo(TimeEventArgs other) //  метод  будет использоваться для сравнения двух объектов TimeEventArg
        {
            return this.RestTimeToWait.CompareTo(other.RestTimeToWait);// Сравниваем значения  RestTimeToWait  с  значением другого объекта 
        }
    }
}

