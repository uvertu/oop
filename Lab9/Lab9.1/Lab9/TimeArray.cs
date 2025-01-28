using System;

namespace Lab9
{
    public class TimeArray
    {
        private Time[] timeArray;

        private static int objectCount;

        public TimeArray()
        {
            timeArray = new Time[3];
            timeArray[0] = new Time(12, 0);
            timeArray[1] = new Time(0, 0);
            timeArray[2] = new Time(23, 15);
            objectCount++;
        }

        public TimeArray(int size)
        {
            timeArray = new Time[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                timeArray[i] = new Time(random.Next(2), random.Next(60));
            }

            objectCount++;
        }

        public TimeArray(int size, bool userInput)
        {
            timeArray = new Time[size];

            for (int i = 0; i < size; i++)
            {
                int number = i + 1;
                Console.WriteLine("Элемент " + number);
                timeArray[i] = Program.CreateObject();
            }

            objectCount++;
        }

        public void DisplayArray()
        {
            foreach (Time time in timeArray)
            {
                time.DisplayTime();
            }
        }

        public Time this[int index]
        {
            get
            {
                if (index >= 0 && index < timeArray.Length)
                {
                    return timeArray[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Индекс за пределами массива");
                }
            }
            set
            {
                if (index >= 0 && index < timeArray.Length)
                {
                    timeArray[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Индекс за пределами массива");
                }
            }
        }

        public int Length
        {
            get 
            { 
                return timeArray.Length; 
            }
        }


        public static int GetObjectCount()
        {
            return objectCount;
        }
    }
}
