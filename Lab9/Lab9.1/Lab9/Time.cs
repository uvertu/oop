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

        private static int objectCount = 0;

        public Time(int hours, int minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
            objectCount++;
        }

        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (value >= 0)
                {
                    hours = value;
                }
                else
                {
                    hours = 0; 
                }
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
                if (value < 60)
                {
                    minutes = value;
                    if (minutes < 0)
                    {
                        int hoursToSubtract = Math.Abs(minutes) / 60 + 1;
                        hours = hours - hoursToSubtract;

                        if (hours < 0)
                        {
                            Console.WriteLine("Ошибка. Нулевое время.");
                            minutes = 0;
                            hours = 0;
                        }
                        else
                        {
                            minutes = 60 - Math.Abs(minutes) % 60;
                        }
                    }
                }
                else
                {
                    minutes = value;
                    int hoursToAdd = minutes / 60;
                    hours = hours + hoursToAdd;
                    minutes = 0 + minutes % 60;
                }
            }
        }


        public static Time SubtractMinutesStatic(Time time, int subtractMinutes)
        {
            Time result = new Time(time.Hours, time.Minutes);

            result.Minutes -= subtractMinutes;

            return result;
        }

        public void SubtractMinutes(int subtractMinutes)
        {
            this.Minutes -= subtractMinutes;
        }


        public void DisplayTime()
        {
            Console.WriteLine(hours.ToString("D2") + ":" + minutes.ToString("D2"));
        }


        public static int GetObjectCount()
        {
            return objectCount;
        }

        public static Time operator -(Time time)
        {
            time.hours = 0;
            time.minutes = 0;
            return time;
        }

        public static Time operator --(Time time)
        {
            time.Minutes--;
            return time;
        }



        public static implicit operator int(Time time)
        {
            return time.hours;
        }

        public static explicit operator bool(Time time)
        {
            return (time.hours != 0 || time.minutes != 0);
        }


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