using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class Time
    {
        private int hours;
        private int minutes;

        // Статическая переменная для подсчета созданных объектов
        private static int objectCount = 0;

        // Конструктор класса
        public Time(int hours, int minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
            // Увеличиваем счетчик созданных объектов при каждом вызове конструктора
            objectCount++;
        }

        // Свойства для доступа к закрытым атрибутам
        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                hours = value;
            }
        }

        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                minutes = value;
            }
        }

        // Статическая функция для вычитания минут
        public static Time SubtractMinutesStatic(Time time, int subtractMinutes)
        {
            int totalMinutes = time.hours * 60 + time.minutes - subtractMinutes;

            // Обработка случаев, когда минуты меньше 0 или больше 59
            int resultHours = totalMinutes / 60;
            int resultMinutes = totalMinutes % 60;

            return new Time(resultHours, resultMinutes);
        }

        // Метод класса для вычитания минут
        public Time SubtractMinutes(int subtractMinutes)
        {
            int totalMinutes = this.hours * 60 + this.minutes - subtractMinutes;

            // Обработка случаев, когда минуты меньше 0 или больше 59
            int resultHours = totalMinutes / 60;
            int resultMinutes = totalMinutes % 60;

            return new Time(resultHours, resultMinutes);
        }

        // Метод для вывода информации о времени
        public void DisplayTime()
        {
            Console.WriteLine(hours.ToString("D2") + ":" + minutes.ToString("D2"));
        }


        // Статическая функция для получения количества созданных объектов
        public static int GetObjectCount()
        {
            return objectCount;
        }

        public static Time operator -(Time time)
        {
            // Zero out the existing object's values
            time.hours = 0;
            time.minutes = 0;
            return time;
        }

        public static Time operator --(Time time)
        {
            // Вычитание минут без изменения текущего объекта
            int newMinutes = time.minutes - 1;
            if (newMinutes < 0)
            {
                int newHours = time.hours - 1;
                if (newHours < 0)
                {
                    Console.WriteLine("Ошибка. Нулевое время.");
                    time.minutes = 0;
                    time.hours = 0;
                    return time;
                }
                else
                {
                    newMinutes = 59;
                    return new Time(newHours, newMinutes);
                }
            }
            else
            {
                // Обычное вычитание минут
                time.Minutes = newMinutes;
                return time;
            }
        }


        // Операции приведения типа

        public static implicit operator int(Time time)
        {
            // Приведение к int - возвращаем количество часов
            return time.hours;
        }

        public static explicit operator bool(Time time)
        {
            // Приведение к bool - true, если часы и минуты не равны нулю
            return (time.hours != 0 || time.minutes != 0);
        }

        // Бинарные операции

        public static bool operator ==(Time t1, Time t2)
        {
            return (t1.hours == t2.hours) && (t1.minutes == t2.minutes);
        }

        public static bool operator !=(Time t1, Time t2)
        {
            return !(t1 == t2);
        }
    }
}

