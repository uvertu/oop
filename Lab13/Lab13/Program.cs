using System;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            MyNewCollection collection1 = new MyNewCollection("Коллекция 1");
            MyNewCollection collection2 = new MyNewCollection("Коллекция 2");


            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            collection1.CollectionCountChanged += new CollectionHandler(journal1.CollectionCountChanged);
            collection1.CollectionReferenceChanged += new CollectionHandler(journal1.CollectionReferenceChanged);
            collection1.CollectionReferenceChanged += new CollectionHandler(journal2.CollectionReferenceChanged);
            collection2.CollectionReferenceChanged += new CollectionHandler(journal2.CollectionReferenceChanged);

            Console.WriteLine("Записи в журнале 1:");
            Console.WriteLine(journal1);

            collection1.AddDefaults();
            collection2.AddDefaults();

            Console.WriteLine("Создание коллекции:");
            foreach (var item in collection1)
            {
                item.Show();
            }

            Console.WriteLine("Записи в журнале 1:");
            Console.WriteLine(journal1);

            collection1.Add(new object[] { new Car(100, 2022, "Tesla") });
            collection2.Add(new object[] { new Car(150, 2023, "BMW") });

            Console.WriteLine("Коллекция после добавления элемента:");
            foreach (var item in collection1)
            {
                item.Show();
            }

            Console.WriteLine("Записи в журнале 1:");
            Console.WriteLine(journal1);

            collection1.Remove(0);
            collection2.Remove(1);

            Console.WriteLine("Коллекция после удаления элемента:");
            foreach (var item in collection1)
            {
                item.Show();
            }

            Console.WriteLine("Записи в журнале 1:");
            Console.WriteLine(journal1);

            collection1[1] = new Car(150, 2024, "Audi");

            Console.WriteLine("Коллекция после изменения элемента 2:");
            foreach (var item in collection1)
            {
                item.Show();
            }

            Console.WriteLine("Записи в журнале 1:");
            Console.WriteLine(journal1);

            Console.WriteLine("Коллекция 2 до изменения");
            foreach (var item in collection2)
            {
                item.Show();
            }
            Console.WriteLine("\nЗаписи в журнале 2:");
            Console.WriteLine(journal2);

            collection2[0] = new Car(140, 2019, "Mercedes");

            Console.WriteLine("Коллекция 2 после изменения");
            foreach (var item in collection2)
            {
                item.Show();
            }

            Console.WriteLine("\nЗаписи в журнале 2:");
            Console.WriteLine(journal2);
        }
    }
}
