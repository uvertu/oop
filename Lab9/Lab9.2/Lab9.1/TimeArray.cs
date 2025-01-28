using System;

namespace Lab9
{
    class TimeArray
    {
        private Time[] timeArray;

        // Количество созданных объектов
        private static int objectCount;

        // Конструктор без параметров
        public TimeArray()
        {
            timeArray = new Time[3];
            timeArray[0] = new Time(12, 0); // Инициализируем элемент по умолчанию
            timeArray[1] = new Time(0, 0);
            timeArray[2] = new Time(23, 15);
            objectCount++;
        }

        // Конструктор с параметрами, заполняющий элементы случайными значениями
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

        // Конструктор с параметрами, позволяющий заполнить массив элементами, заданными пользователем с клавиатуры
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

        // Метод для просмотра элементов массива
        public void DisplayArray()
        {
            foreach (Time time in timeArray)
            {
                time.DisplayTime();
            }
        }

        // Индексатор для доступа к элементам коллекции
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


        // Количество созданных объектов
        public static int GetObjectCount()
        {
            return objectCount;
        }
    }
}
