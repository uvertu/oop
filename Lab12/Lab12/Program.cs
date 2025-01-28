using System;
namespace Lab12
{
    public class Programm
    {
        static ItemLinkedList<Car> itemList;
        public static int GetValidInput(string prompt, int maxValue)
        {
            int userInput;

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out userInput) && userInput >= 1 && userInput <= maxValue)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
            } while (true);

            return userInput;
        }
        static void Main()
        {
            Console.Write("Лабораторная работа 12");
            int choice;
            do
            {
                int quantity;
                choice = GetValidInput("\n1.Создание списка\n2.Вывод списка\n3.Удаление элементов\n4.Добавление элементов\n5.Поиск элементов по значению\n6.Удаление списка\n7.Выход\n", 7);
                var newList = new ItemLinkedList<Car>();
                switch (choice)
                {
                    case 1:
                        int capacity = GetValidInput("\nВведите размер списка: ", int.MaxValue);
                        itemList = new ItemLinkedList<Car>(capacity);
                        while (itemList.Count < capacity)
                        {
                            Car c = new Car(0, 0, "");
                            c.RandomInit();
                            itemList.Add(c);
                        }
                        Console.WriteLine("Список успешно создан!");
                        break;
                    case 2:
                        if (itemList != null && itemList.Tail != null)
                        {
                            int count = 1;
                            foreach (var item in itemList)
                            {
                                Console.Write($"{count}: ");
                                item.Show();
                                count++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте список в пункте 1.");
                        }
                        break;
                    case 3:
                        if (itemList != null && itemList.Tail != null)
                        {
                            List<int> counter = new List<int>();
                            quantity = GetValidInput("\nСколько элементов вы хотите удалить: ", itemList.Count);
                            for (int i = 0; i < quantity; i++)
                            {
                                int number = GetValidInput($"Введите номер {i + 1}-го элемента: ", itemList.Count);
                                if (counter.Contains(number))
                                {
                                    Console.WriteLine("Введите другой элемент");
                                    i--;
                                }
                                else
                                {
                                    newList.Add(itemList[number - 1]);
                                    counter.Add(number);
                                }
                            }
                            itemList.RemoveRange(newList);
                            newList = null;
                            Console.WriteLine("Элементы успешно удалены");
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте список в пункте 1.");
                        }
                        break;
                    case 4:
                        if (itemList != null && itemList.Tail != null)
                        {
                            quantity = GetValidInput("\nСколько элементов вы хотите добавить: ", int.MaxValue);
                            for (int i = 0; i < quantity; i++)
                            {
                                Car c = new Car(0, 0, "");
                                c.RandomInit();
                                newList.Add(c);
                            }
                            itemList.AddRange(newList);
                            newList = null;
                            Console.WriteLine("Элементы успешно добавлены");
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте список в пункте 1.");
                        }
                        break;
                    case 5:
                        if (itemList != null && itemList.Tail != null)
                        {
                            Console.Write("\nВведите марку машины: ");
                            string carmake = Console.ReadLine();
                            Car car = new Car(0, 0, carmake);
                            if (itemList.Contains(car))
                            {
                                Console.WriteLine($"Машины с маркой {carmake}");
                                int count = 0;
                                foreach (var item in itemList)
                                {
                                    count += 1;
                                    if (item is Car temp && temp.CarMake.Equals(carmake))
                                    {
                                        Console.Write($"{count}: ");
                                        item.Show();
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Элемента с маркой машины {carmake} нет в списке");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте список в пункте 1.");
                        }
                        break;
                    case 6:
                        if (itemList != null)
                        {
                            itemList.Clear();
                            itemList = null;
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте список в пункте 1.");
                        }
                        break;

                }
            } while (choice != 7);

            Console.WriteLine();

            var listExtend = new ItemLinkedList<Vehicle>();

            Car c1 = new Car(200, 2010, "BMW");
            Train t2 = new Train(150, 2020, "РЖД");
            Express e3 = new Express(100, 2000, "BMW");

            listExtend.Add(c1);
            listExtend.Add(t2);
            listExtend.Add(e3);

            foreach (var item in listExtend)
            {
                item.Show();
            }


            Console.WriteLine();
            listExtend.SortBySpeed();
            foreach (var item in listExtend)
            {
                item.Show();
            }

            Console.WriteLine();
            listExtend.SortByYear();
            foreach (var item in listExtend)
            {
                item.Show();
            }

            Console.WriteLine();
            var listnewn = new ItemLinkedList<Vehicle>();
            listnewn = listExtend.FilterByField(vehicle => vehicle is Vehicle v && v.Speed > 120);
            foreach (var item in listnewn)
            {
                item.Show();
            }
            /*  

                        var listExample = new ItemLinkedList<Car>();

                        Car ex1 = new Car(130, 2010, "BMW");
                        Car ex2 = new Car(150, 2020, "Toyota");
                        Car ex3 = new Car(100, 2000, "BMW");


                        listExample.Add(ex1);
                        listExample.Add(ex2);
                        listExample.Add(ex3);


                        foreach (var item in listExample)
                        {
                            item.Show();
                        }

                        Console.WriteLine("\nУдаление последнего объекта с маркой машины BMW");
                        listExample.RemoveLast("BMW");

                        foreach (var item in listExample)
                        {
                            item.Show();
                        }

                        Console.WriteLine("\nУдаление последнего объекта с маркой машины BMW");
                        listExample.RemoveLast("BMW");

                        foreach (var item in listExample)
                        {
                            item.Show();
                        }

                        var listNew = new ItemLinkedList<Bicycle>();
                        Bicycle el1 = new Bicycle(0, new Company("FORWARD"));
                        Bicycle el2 = new Bicycle(1, new Company("FORWARD"));

                        listNew.Add(el1);
                        listNew.Add(el2);

                        var clonedListNew = listNew.Clone();
                        var copyListNew = listNew.ShallowCopy();

                        Console.WriteLine("\nОригинал:");

                        foreach (var item in listNew)
                        {
                            item.Show();
                        }

                        Console.WriteLine("\nКлон:");

                        foreach (var item in clonedListNew)
                        {
                            item.Show();
                        }

                        Console.WriteLine("\nКопия:");

                        foreach (var item in copyListNew)
                        {
                            item.Show();
                        }

                        listNew[1].NumberOfWheels = 3;
                        listNew[1].Company.Name = "SCOTT";

                        Console.WriteLine("\nОригинал после изменений:");

                        foreach (var item in listNew)
                        {
                            item.Show();
                        }

                        Console.WriteLine("\nКлон:");

                        foreach (var item in clonedListNew)
                        {
                            item.Show();
                        }

                        Console.WriteLine("\nКопия:");

                        foreach (var item in copyListNew)
                        {
                            item.Show();
                        }*/

            Console.ReadLine();
        }
    }
}