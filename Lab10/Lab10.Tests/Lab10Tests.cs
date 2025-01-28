using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Lab10.Tests
{
    [TestClass]
    public class Lab10Tests
    {
        [TestMethod]
        public void TestRandomInit()
        {
            // Arrange
            Vehicle vehicle = new Vehicle(0, 0);

            // Act
            vehicle.RandomInit();

            // Assert
            Assert.IsTrue(vehicle.Speed > 0 && vehicle.Year >= 1900 && vehicle.Year <= 2023);
        }

        [TestMethod]
        public void TestGetValidInput()
        {
            // Arrange
            const int maxValue = 100;
            string prompt = "Ââåäèòå çíà÷åíèå: ";
            string validInput = "50";
            StringReader stringReader = new StringReader(validInput);
            Console.SetIn(stringReader);

            // Act
            int resultValidInput = Vehicle.GetValidInput(prompt, maxValue);

            // Assert

            Assert.AreEqual(50, resultValidInput);  
        }

        [TestMethod]
        public void TestEquals()
        {
            // Arrange
            Vehicle vehicle1 = new Vehicle(100, 2020);
            Vehicle vehicle2 = new Vehicle(100, 2020);
            Vehicle vehicle3 = new Vehicle(120, 2022);

            // Act & Assert
            Assert.IsTrue(vehicle1.Equals(vehicle2)); 
            Assert.IsFalse(vehicle1.Equals(vehicle3)); 
        }

        [TestMethod]
        public void TestCompareToEqual()
        {
            // Arrange
            Vehicle vehicle1 = new Vehicle(100, 2020);
            Vehicle vehicle2 = new Vehicle(100, 2020);

            // Act
            int result = vehicle1.CompareTo(vehicle2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestCompareToGreater()
        {
            // Arrange
            Vehicle vehicle1 = new Vehicle(120, 2022);
            Vehicle vehicle2 = new Vehicle(100, 2020);

            // Act
            int result = vehicle1.CompareTo(vehicle2);

            // Assert
            Assert.IsTrue(result > 0); 
        }

        [TestMethod]
        public void TestCompareToLower()
        {
            // Arrange
            Vehicle vehicle1 = new Vehicle(100, 2020);
            Vehicle vehicle2 = new Vehicle(120, 2022);

            // Act
            int result = vehicle1.CompareTo(vehicle2);

            // Assert
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void TestInit()
        {
            // Arrange
            Vehicle vehicle = new Vehicle(0, 0);
            string input = "100\n2022"; 
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            vehicle.Init();

            // Assert
            Assert.AreEqual(100, vehicle.Speed);
            Assert.AreEqual(2022, vehicle.Year);
        }

        [TestMethod]
        public void TestInitZeroSpeedAndYear()
        {
            // Arrange
            Vehicle vehicle = new Vehicle(0, 0);
            string input = "0\n0"; 
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            vehicle.Init();

            // Assert
            Assert.AreEqual(1, vehicle.Speed); 
            Assert.AreEqual(1, vehicle.Year); 
        }

        [TestMethod]
        public void TestSpeedComparer()
        {
            // Arrange
            Vehicle vehicle1 = new Vehicle(100, 2020);
            Vehicle vehicle2 = new Vehicle(100, 2022);

            SpeedComparer comparer = new SpeedComparer();

            // Act
            int result = comparer.Compare(vehicle1, vehicle2);

            // Assert
            Assert.AreEqual(result,  0); 
        }

        [TestMethod]
        public void TestSpeedComparerLower()
        {
            // Arrange
            Vehicle vehicle1 = new Vehicle(100, 2020);
            Vehicle vehicle2 = new Vehicle(120, 2022);

            SpeedComparer comparer = new SpeedComparer();

            // Act
            int result = comparer.Compare(vehicle1, vehicle2);

            // Assert
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void TestSpeedComparerGreater()
        {
            // Arrange
            Vehicle vehicle1 = new Vehicle(120, 2020);
            Vehicle vehicle2 = new Vehicle(100, 2022);

            SpeedComparer comparer = new SpeedComparer();

            // Act
            int result = comparer.Compare(vehicle1, vehicle2);

            // Assert
            Assert.IsTrue(result > 0); 
        }

        [TestMethod]
        public void TestFindVehicleBySpeed()
        {
            // Arrange
            Vehicle[] vehicles = new Vehicle[]
            {
                new Vehicle(100, 2020),
                new Vehicle(120, 2022),
                new Vehicle(80, 2018)
            };

            int targetSpeed = 120;

            // Act
            Vehicle resultVehicle = SpeedComparer.FindVehicleBySpeed(vehicles, targetSpeed);

            // Assert
            Assert.AreEqual(targetSpeed, resultVehicle.Speed);
        }

        [TestMethod]
        public void TestFindVehicleBySpeedNotFound()
        {
            // Arrange
            Vehicle[] vehicles = new Vehicle[]
            {
                new Vehicle(100, 2020),
                new Vehicle(80, 2018)
            };

            int targetSpeed = 120;

            // Act
            Vehicle resultVehicle = SpeedComparer.FindVehicleBySpeed(vehicles, targetSpeed);

            // Assert
            Assert.IsNull(resultVehicle); 
        }

        [TestMethod]
        public void TestCarInit()
        {
            // Arrange
            Car car = new Car(0, 0, null);
            string input = "100\n2022\nToyota"; 
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Act
            car.Init();

            // Assert
            Assert.AreEqual(100, car.Speed);
            Assert.AreEqual(2022, car.Year);
            Assert.AreEqual("Toyota", car.CarMake);
        }

        [TestMethod]
        public void TestCarRandomInit()
        {
            // Arrange
            Car car = new Car(0, 0, null);

            // Act
            car.RandomInit();

            // Assert
            Assert.IsTrue(car.Speed > 0 && car.Year >= 1900 && car.Year <= 2023);
            Assert.IsNotNull(car.CarMake); 
        }

        [TestMethod]
        public void TestCarEquals()
        {
            // Arrange
            Car car1 = new Car(100, 2020, "Toyota");
            Car car2 = new Car(100, 2020, "Toyota");
            Car car3 = new Car(120, 2022, "Honda");

            // Act & Assert
            Assert.IsTrue(car1.Equals(car2)); 
            Assert.IsFalse(car1.Equals(car3)); 
        }

        [TestMethod]
        public void TestSearchCarsByMake()
        {
            // Arrange
            Vehicle[] vehicles = new Vehicle[]
            {
                new Car(100, 2020, "Toyota"),
                new Car(120, 2022, "Ford"),
                new Car(80, 2018, "Honda")
            };

            string input = "Ford"; 
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);


            // Act
            Car[] foundCars = Car.SearchCarsByMake(vehicles);

            // Assert
            Assert.AreEqual("Ford", foundCars[0].CarMake);
        }

        [TestMethod]
        public void TestSearchCarsByMakeNotFound()
        {
            // Arrange
            Vehicle[] vehicles = new Vehicle[]
            {
                new Car(100, 2020, "Toyota"),
                new Car(120, 2022, "Ford"),
                new Car(80, 2018, "Honda")
            };

            string input = "Chevrolet"; 
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Car[] foundCars = Car.SearchCarsByMake(vehicles);

            // Assert
            Assert.AreEqual(0, foundCars.Length); 
        }



        [TestMethod]
        public void TestTrainInit()
        {
            // Arrange
            Train train = new Train(0, 0, 0);
            string input = "100\n2022\n5"; 
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Act
            train.Init();

            // Assert
            Assert.AreEqual(100, train.Speed);
            Assert.AreEqual(2022, train.Year);
            Assert.AreEqual(5, train.NumberOfCars);
        }

        [TestMethod]
        public void TestTrainRandomInit()
        {
            // Arrange
            Train train = new Train(0, 0, 0);

            // Act
            train.RandomInit();

            // Assert
            Assert.IsTrue(train.Speed > 0 && train.Year >= 1900 && train.Year <= 2023);
            Assert.IsTrue(train.NumberOfCars >= 1 && train.NumberOfCars <= 20);
        }

        [TestMethod]
        public void TestTrainEquals()
        {
            // Arrange
            Train train1 = new Train(100, 2020, 5);
            Train train2 = new Train(100, 2020, 5);
            Train train3 = new Train(120, 2022, 8);

            // Act & Assert
            Assert.IsTrue(train1.Equals(train2)); 
            Assert.IsFalse(train1.Equals(train3)); 
        }

        [TestMethod]
        public void TestSearchTrainsByNumberOfCars()
        {
            // Arrange
            Vehicle[] vehicles = new Vehicle[]
            {
            new Train(100, 2020, 5),
            new Train(120, 2022, 8),
            new Train(80, 2018, 7)
            };

            string input = "7"; 
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Act
            Train[] foundTrains = Train.SearchTrainsByNumberOfCars(vehicles);

            // Assert
            Assert.AreEqual(8, foundTrains[0].NumberOfCars);
        }

        [TestMethod]
        public void TestSearchTrainsByNumberOfCarsFalse()
        {
            // Arrange
            Vehicle[] vehicles = new Vehicle[]
            {
            new Train(100, 2020, 5),
            new Train(120, 2022, 8),
            new Train(80, 2018, 10)
            };

            string input = "10"; 
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Act
            Train[] foundTrains = Train.SearchTrainsByNumberOfCars(vehicles);

            // Assert
            Assert.AreEqual(0, foundTrains.Length);
        }

        [TestMethod]
        public void TestInitZeroNumberOfCars()
        {
            // Arrange
            Train train = new Train(0, 0, 0);
            string input = "0\n0\n0"; 
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            train.Init();

            // Assert
            Assert.AreEqual(1, train.Speed); 
            Assert.AreEqual(1, train.Year); 
            Assert.AreEqual(1, train.NumberOfCars); 
        }

        [TestMethod]
        public void TestExpressInit()
        {
            // Arrange
            Express express = new Express(0, 0, "");
            string input = "100\n2022\nËÎÍÄÎÍ - ÏÀÐÈÆ"; 
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Act
            express.Init();

            // Assert
            Assert.AreEqual(100, express.Speed);
            Assert.AreEqual(2022, express.Year);
            Assert.AreEqual("ËÎÍÄÎÍ - ÏÀÐÈÆ", express.Route);
        }


        [TestMethod]
        public void TestExpressRandomInit()
        {
            // Arrange
            Express express = new Express(0, 0, null);

            // Act
            express.RandomInit();

            // Assert
            Assert.IsTrue(express.Speed > 0 && express.Year >= 1900 && express.Year <= 2023);
            Assert.IsNotNull(express.Route); 
        }

        [TestMethod]
        public void TestExpressEquals()
        {
            // Arrange
            Express express1 = new Express(100, 2020, "ËÎÍÄÎÍ - ÁÅÐËÈÍ");
            Express express2 = new Express(100, 2020, "ËÎÍÄÎÍ - ÁÅÐËÈÍ");
            Express express3 = new Express(120, 2022, "ËÎÍÄÎÍ - ÏÀÐÈÆ");

            // Act & Assert
            Assert.IsTrue(express1.Equals(express2)); 
            Assert.IsFalse(express1.Equals(express3)); 
        }

        [TestMethod]
        public void TestSearchExpresses()
        {
            // Arrange
            Vehicle[] vehicles = new Vehicle[]
            {
                new Express(100, 2020, "ËÎÍÄÎÍ - ÁÅÐËÈÍ"),
                new Car(120, 2022, "Toyota"), 
                new Express(80, 2018, "ËÎÍÄÎÍ - ÏÀÐÈÆ")
            };

            // Act
            Express[] foundExpresses = Express.SearchExpresses(vehicles);

            // Assert
            Assert.AreEqual("ËÎÍÄÎÍ - ÁÅÐËÈÍ", foundExpresses[0].Route);
            Assert.AreEqual("ËÎÍÄÎÍ - ÏÀÐÈÆ", foundExpresses[1].Route);
        }

        [TestMethod]
        public void TestSearchExpressFalse()
        {
            // Arrange
            Vehicle[] vehicles = new Vehicle[]
            {
                new Train(100, 2020, 5),
                new Train(120, 2022, 8),
                new Train(80, 2018, 10)
            };

            Express[] foundExpresses = Express.SearchExpresses(vehicles);

            // Assert
            Assert.AreEqual(0, foundExpresses.Length);
        }

        [TestMethod]
        public void Clone_ReturnsClonedObject()
        {
            // Arrange
            var originalCompany = new Company("OriginalCompany");
            var originalBicycle = new Bicycle(2, originalCompany);

            // Act
            var clonedBicycle = (Bicycle)originalBicycle.Clone();

            // Assert
            Assert.AreEqual(originalBicycle.NumberOfWheels, clonedBicycle.NumberOfWheels);
            Assert.AreEqual(originalBicycle.Company.Name, clonedBicycle.Company.Name);
        }

        [TestMethod]
        public void Init_SetsNumberOfWheels()
        {
            // Arrange
            Bicycle bicycle = new Bicycle(0, new Company("TestCompany"));
            string input = "2";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            bicycle.Init();

            // Assert
            Assert.AreEqual(2, bicycle.NumberOfWheels);
        }

        [TestMethod]
        public void Init_SetsNumberOfWheelsMore()
        {
            // Arrange
            Bicycle bicycle = new Bicycle(0, new Company("TestCompany"));
            string input = "4";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            bicycle.Init();

            // Assert
            Assert.AreEqual(2, bicycle.NumberOfWheels);
        }

        [TestMethod]
        public void Init_SetsNumberOfWheelsLess()
        {
            // Arrange
            Bicycle bicycle = new Bicycle(0, new Company("TestCompany"));
            string input = "1";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            bicycle.Init();

            // Assert
            Assert.AreEqual(2, bicycle.NumberOfWheels);
        }

        [TestMethod]
        public void RandomInit_SetsNumberOfWheelsInRange()
        {
            // Arrange
            var bicycle = new Bicycle(0, new Company("TestCompany"));

            // Act
            bicycle.RandomInit();

            // Assert
            Assert.IsTrue(bicycle.NumberOfWheels >= 2 && bicycle.NumberOfWheels < 4);
        }

        [TestMethod]
        public void ShallowCopy_ReturnsShallowCopy()
        {
            // Arrange
            var originalCompany = new Company("OriginalCompany");
            var originalBicycle = new Bicycle(2, originalCompany);

            // Act
            var copiedBicycle = (Bicycle)originalBicycle.ShallowCopy();

            // Assert
            Assert.AreEqual(originalBicycle.NumberOfWheels, copiedBicycle.NumberOfWheels);
            Assert.AreEqual(originalBicycle.Company.Name, copiedBicycle.Company.Name);
        }

    }
}