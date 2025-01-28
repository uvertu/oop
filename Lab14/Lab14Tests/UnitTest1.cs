using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.ComponentModel;

namespace Lab14.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static CityCollection CreateAndFillCityCollection()
        {
            CityCollection cityCollection = new CityCollection();

            cityCollection.AddTerminal();
            cityCollection.AddTerminal();

            cityCollection.AddExpressToTermianl(0, new Express(150, 2015, "лняйбю-оеплэ"));
            cityCollection.AddExpressToTermianl(0, new Express(175, 2017, "лняйбю-оеплэ"));
            cityCollection.AddExpressToTermianl(0, new Express(200, 2024, "лняйбю-охреп"));
            cityCollection.AddExpressToTermianl(1, new Express(201, 2018, "лняйбю-юмюою"));
            cityCollection.AddExpressToTermianl(1, new Express(200, 2023, "лняйбю-оеплэ"));
            cityCollection.AddExpressToTermianl(1, new Express(202, 2022, "лняйбю-яхлтепнонкэ"));

            return cityCollection;
        }

        [TestMethod]
        public void MoscowPermExpresses_Should_Work_Correctly()
        {
            CityCollection cityCollection = CreateAndFillCityCollection();

            List<Express> list = Program.MoscowPermExpresses(cityCollection, "лняйбю-оеплэ");

            Assert.AreEqual(3, list.Count); 
        }

        [TestMethod]
        public void MoscowPermExpressesMethod_Should_Work_Correctly()
        {
            CityCollection cityCollection = CreateAndFillCityCollection();

            List<Express> list = Program.MoscowPermExpressesMethod(cityCollection, "лняйбю-оеплэ");

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void CountExpresses_Should_Work_Correctly()
        {
            CityCollection cityCollection = CreateAndFillCityCollection();

            int count = Program.ExpressCount(cityCollection, "лняйбю-оеплэ");

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void CountExpressesMethod_Should_Work_Correctly()
        {
            CityCollection cityCollection = CreateAndFillCityCollection();

            int count = Program.ExpressCountMethod(cityCollection, "лняйбю-оеплэ");

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void Routes_Count_Correctly_And_Operation_Work_Correctly()
        {
            CityCollection cityCollection = CreateAndFillCityCollection();

            var routesOnFirstTerminal = (from express in cityCollection.City[0]
                                         select express.Route).Distinct();

            var routesOnSecondTerminal = (from express in cityCollection.City[1]
                                          select express.Route).Distinct();

            IEnumerable<string> routesUnion = Program.RouteUnion(routesOnFirstTerminal, routesOnSecondTerminal);
            IEnumerable<string> routesIntersection = Program.RouteIntersection(routesOnFirstTerminal, routesOnSecondTerminal);
            IEnumerable<string> routesDifference = Program.RouteDifference(routesOnFirstTerminal, routesOnSecondTerminal);

            Assert.AreEqual(2, routesOnFirstTerminal.Count());
            Assert.AreEqual(3, routesOnSecondTerminal.Count());
            Assert.AreEqual(4, routesUnion.Count());
            Assert.AreEqual(1, routesIntersection.Count());
            Assert.AreEqual(2, routesDifference.Count());
        }

        [TestMethod]
        public void RoutesMethod_Count_Correctly()
        {
            CityCollection cityCollection = CreateAndFillCityCollection();

            var routesOnFirstTerminalMethod = cityCollection.City[0]
                                        .Select(express => express.Route)
                                        .Distinct();

            var routesOnSecondTerminaMethod = cityCollection.City[1]
                                         .Select(express => express.Route)
                                         .Distinct();

            Assert.AreEqual(2, routesOnFirstTerminalMethod.Count());
            Assert.AreEqual(3, routesOnSecondTerminaMethod.Count());
        }

        [TestMethod]
        public void Union_Should_Work_Correctly()
        {
            CityCollection cityCollection = CreateAndFillCityCollection();

            int count = Program.ExpressCountMethod(cityCollection, "лняйбю-оеплэ");

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void Intersection_Should_Work_Correctly()
        {
            CityCollection cityCollection = CreateAndFillCityCollection();

            int count = Program.ExpressCountMethod(cityCollection, "лняйбю-оеплэ");

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void Difference_Should_Work_Correctly()
        {
            CityCollection cityCollection = CreateAndFillCityCollection();

            int count = Program.ExpressCountMethod(cityCollection, "лняйбю-оеплэ");

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void AverageSpeed_Count_Correctly()
        {
            CityCollection cityCollection = CreateAndFillCityCollection();

            double averageSpeed = Program.AverageSpeedOnFirstTerminal(cityCollection, 2);

            Assert.AreEqual(201, averageSpeed);
        }

        [TestMethod]
        public void AverageSpeedMethod_Count_Correctly()
        {
            CityCollection cityCollection = CreateAndFillCityCollection();

            double averageSpeed = Program.AverageSpeedOnFirstTerminalMethod(cityCollection, 2);

            Assert.AreEqual(201, averageSpeed);
        }
        
        [TestMethod]
        public void Group_Work_Correctly()
        {
            CityCollection cityCollection = CreateAndFillCityCollection();
            List<List<Express>> result = Program.GroupedByRoute(cityCollection);

            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void GroupMethod_Work_Correctly()
        {
            CityCollection cityCollection = CreateAndFillCityCollection();
            List<List<Express>> result = Program.GroupedByRouteMethod(cityCollection);

            Assert.AreEqual(4, result.Count());
        }
    }
}