using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9._3
{
    public class TimeArray
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }

        public TimeArray()
        {
            Hours = 0;
            Minutes = 0;
        }

        public TimeArray(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}";
        }
    }

    public class TimeCollection
    {
        private TimeArray[] times;

        public int Count { get; private set; }

        public TimeCollection()
        {
            times = new TimeArray[0];
            Count = 0;
        }

        public TimeCollection(int size)
        {
            times = new TimeArray[size];
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                times[i] = new TimeArray(rand.Next(24), rand.Next(60));
            }

            Count = size;
        }

        public TimeCollection(TimeArray[] inputTimes)
        {
            times = inputTimes;
            Count = inputTimes.Length;
        }

        public void DisplayTimes()
        {
            Console.WriteLine("Times in the collection:");
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(times[i]);
            }
        }

        public TimeArray this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                return times[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                times[index] = value;
            }
        }
    }
}
