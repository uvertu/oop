using System;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab14
{
    public class Program
    {
        static void Main(string[] args)
        {
            CityCollection cityCollection = new CityCollection();

            cityCollection.AddTerminal();
            cityCollection.AddTerminal();

            cityCollection.AddExpressToTermianl(0, new Express(150, 2015, "МОСКВА-ПЕРМЬ"));
            cityCollection.AddExpressToTermianl(0, new Express(175, 2017, "МОСКВА-ПЕРМЬ"));
            cityCollection.AddExpressToTermianl(0, new Express(200, 2024, "МОСКВА-ПИТЕР"));
            cityCollection.AddExpressToTermianl(1, new Express(201, 2018, "МОСКВА-АНАПА"));
            cityCollection.AddExpressToTermianl(1, new Express(200, 2023, "МОСКВА-ПЕРМЬ"));
            cityCollection.AddExpressToTermianl(1, new Express(202, 2022, "МОСКВА-СИМФЕРОПОЛЬ"));

            var routesOnFirstTerminal = (from express in cityCollection.City[0]
                                         select express.Route).Distinct();

            var routesOnSecondTerminal = (from express in cityCollection.City[1]
                                          select express.Route).Distinct();

            var routesOnFirstTerminalMethod = cityCollection.City[0]
                                        .Select(express => express.Route)
                                        .Distinct();

            var routesOnSecondTerminaMethod = cityCollection.City[1]
                                         .Select(express => express.Route)
                                         .Distinct();

            cityCollection.DisplayCityTrains();

            Console.WriteLine();

            string route = "МОСКВА-ПЕРМЬ";
            List<Express> expresses = MoscowPermExpresses(cityCollection, route);
            Console.WriteLine("\n2.СЧЁТЧИК");
            int count = ExpressCount(cityCollection, route);
            Console.WriteLine($"Количество экспрессов с маршрутом '{route}': {count}");
            IEnumerable<string> routesUnion = RouteUnion(routesOnFirstTerminal, routesOnSecondTerminal);
            PrintInfo("3.1 ОБЪЕДИНЕНИЕ", routesUnion);
            IEnumerable<string> routesIntersection = RouteIntersection(routesOnFirstTerminal, routesOnSecondTerminal);
            PrintInfo("3.2 ПЕРЕСЕЧЕНИЕ", routesIntersection);
            IEnumerable<string> routesDifference = RouteDifference(routesOnFirstTerminal, routesOnSecondTerminal);
            PrintInfo("3.3 РАЗНОСТЬ", routesDifference);
            Console.WriteLine("\n4.АГРЕГИРОВАНИЕ");
            double averageSpeed = AverageSpeedOnFirstTerminal(cityCollection, 2);
            Console.WriteLine($"Средняя скорость экспрессов с вокзала {2}: {averageSpeed}");
            List<List<Express>> result = GroupedByRoute(cityCollection);
/*            foreach (var resultItem in result)
            {
                Console.WriteLine($"\nМаршрут: {resultItem[0].Route}");
                foreach (var item in resultItem)
                {
                    item.Show();
                }
            }*/

        }

        public static List<Express> MoscowPermExpresses(CityCollection cityCollection, string route)
        {
            List<Express> expresses = new List<Express>();
            Console.WriteLine("1.ВЫБОРКА");
            var result = from stackIndex in Enumerable.Range(0, cityCollection.City.Count)
                         from express in cityCollection.City[stackIndex]
                         where express.Route == route
                         select new { Terminal = stackIndex + 1, Express = express };

            Console.WriteLine($"Экспрессы с маршрутом '{route}':");
            foreach (var item in result)
            {
                Console.WriteLine($"\nВокзал {item.Terminal}:");
                item.Express.Show();
                expresses.Add(item.Express);
            }
            return expresses;
        }

        public static List<Express> MoscowPermExpressesMethod(CityCollection cityCollection, string route)
        {
            List<Express> expresses = new List<Express>();

            var resultMethod = Enumerable.Range(0, cityCollection.City.Count)
             .SelectMany(stackIndex => cityCollection.City[stackIndex]
             .Where(express => express.Route == route)
             .Select(express => new { Terminal = stackIndex + 1, Express = express }));


            foreach (var item in resultMethod)
            {
                expresses.Add(item.Express);
            }
            return expresses;
        }

        public static int ExpressCount(CityCollection cityCollection, string route)
        {
            var countExpress = (from stack in cityCollection.City
                                from express in stack
                                where express.Route == route
                                select express).Count();

            return countExpress;
        }

        public static int ExpressCountMethod(CityCollection cityCollection, string route)
        {
            var countExpressMethod = cityCollection.City
                    .SelectMany(stack => stack)
                    .Count(express => express.Route == route);

            return countExpressMethod;
        }


        public static void PrintInfo(string info, IEnumerable<string> routesOperation)
        {
            Console.WriteLine($"\n{info}");
            foreach (var route in routesOperation)
            {
                Console.WriteLine(route);
            }
        }

        public static IEnumerable<string> RouteUnion(IEnumerable<string> routesOnFirstTerminal, IEnumerable<string> routesOnSecondTerminal)
        {
            var routesUnion = routesOnFirstTerminal.Union(routesOnSecondTerminal);

            return routesUnion;
        }

        public static IEnumerable<string> RouteIntersection(IEnumerable<string> routesOnFirstTerminal, IEnumerable<string> routesOnSecondTerminal)
        {
            var routesIntersect = routesOnFirstTerminal.Intersect(routesOnSecondTerminal);

            return routesIntersect;
        }

        public static IEnumerable<string> RouteDifference(IEnumerable<string> routesOnFirstTerminal, IEnumerable<string> routesOnSecondTerminal)
        {
            var routesDifference = routesOnSecondTerminal.Except(routesOnFirstTerminal);

            return routesDifference;
        }

        public static double AverageSpeedOnFirstTerminal(CityCollection cityCollection, int number)
        {
            var expressSpeedsOnTerminal = from express in cityCollection.City[number-1]
                                               select express.Speed;
            double averageSpeedOnFirstTerminal = expressSpeedsOnTerminal.Average();

            return averageSpeedOnFirstTerminal;
        }

        public static double AverageSpeedOnFirstTerminalMethod(CityCollection cityCollection, int number)
        {

            var expressSpeedsOnTerminalMethod = cityCollection.City[number - 1]
                                        .Select(express => express.Speed);
            double averageSpeedOnFirstTerminalMethod = expressSpeedsOnTerminalMethod.Aggregate(
                                                    (sum, speed) => sum + speed) /
                                                    expressSpeedsOnTerminalMethod.Count();

            return averageSpeedOnFirstTerminalMethod;;
        }

        public static List<List<Express>> GroupedByRoute(CityCollection cityCollection)
        {
            List<List<Express>> groupList = new List<List<Express>>();
            Console.WriteLine("\n5.ГРУППИРОВКА");
            var groupedByRoute = from stackIndex in Enumerable.Range(0, cityCollection.City.Count)
                                 from express in cityCollection.City[stackIndex]
                                 group new { Express = express, Terminal = stackIndex + 1 } by express.Route into routeGroup
                                 select new { Route = routeGroup.Key, Expresses = routeGroup };


            Console.WriteLine("Группировка данных по маршруту:");
            foreach (var routeGroup in groupedByRoute)
            {
                List<Express> temp = new List<Express>();
                Console.WriteLine($"\nМаршрут: {routeGroup.Route}");
                foreach (var expressInfo in routeGroup.Expresses)
                {
                    Console.WriteLine($"\nВокзал: {expressInfo.Terminal}");
                    expressInfo.Express.Show();
                    temp.Add(expressInfo.Express);
                }
                groupList.Add(temp);
            }
            return groupList;
        }

        public static List<List<Express>> GroupedByRouteMethod(CityCollection cityCollection)
        {
            List<List<Express>> groupList = new List<List<Express>>();
            var groupedByRouteMethod = Enumerable.Range(0, cityCollection.City.Count)
                     .SelectMany(stackIndex => cityCollection.City[stackIndex]
                     .Select(express => new { Express = express, Terminal = stackIndex + 1 }))
                     .GroupBy(item => item.Express.Route)
                     .Select(routeGroup => new { Route = routeGroup.Key, Expresses = routeGroup });

            Console.WriteLine("Группировка данных по маршруту:");
            foreach (var routeGroup in groupedByRouteMethod)
            {
                List<Express> temp = new List<Express>();
                Console.WriteLine($"\nМаршрут: {routeGroup.Route}");
                foreach (var expressInfo in routeGroup.Expresses)
                {
                    Console.WriteLine($"\nВокзал: {expressInfo.Terminal}");
                    expressInfo.Express.Show();
                    temp.Add(expressInfo.Express);
                }
                groupList.Add(temp);
            }
            return groupList;
        }
    }
}
