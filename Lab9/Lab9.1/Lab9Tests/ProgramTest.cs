using System.Drawing;

namespace Lab9.Tests
{

    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void GetValidInput_ValidInput_ReturnsInput()
        {
            string prompt = "Enter a number: ";
            int maxValue = 10;
            string userInput = "5";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);

            int result = Program.GetValidInput(prompt, maxValue);

            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void CreateObject_ValidInput_ReturnsTimeObject()
        {
            string userInput = "3\n30";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);

            Time result = Program.CreateObject();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Hours);
            Assert.AreEqual(30, result.Minutes);
        }

        [TestMethod]
        public void MenuFirst_SubtractMinutes_ReturnsUpdatedTime()
        {
            Time currentTime = new Time(5, 45);
            string userInput = "1\n70\n2";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);

            Time result = Program.MenuFirst(currentTime);

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Hours);
            Assert.AreEqual(35, result.Minutes);
        }

        [TestMethod]
        public void MenuSecond_ResetTime_ReturnsZeroTime()
        {
            Time currentTime = new Time(5, 30);
            string userInput = "1\n3";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);

            Time result = Program.MenuSecond(currentTime);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Hours);
            Assert.AreEqual(0, result.Minutes);
        }

        [TestMethod]
        public void MenuSecond_ResetTime_ReturnsZeroTimeWithOneLessMinute()
        {
            Time currentTime = new Time(5, 30);
            string userInput = "2\n3";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);

            Time result = Program.MenuSecond(currentTime);

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Hours);
            Assert.AreEqual(29, result.Minutes); 
        }


        [TestMethod]
        public void MenuThird_CompareTime_ReturnsTrue()
        {
            Time currentTime = new Time(4, 45);
            string userInput = "1\n4\n45\n2";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);

            bool result = Program.MenuThird(currentTime);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MenuThird_CompareTime_ReturnsFalse()
        {
            Time currentTime = new Time(4, 45);
            string userInput = "1\n4\n30\n2";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);

            bool result = Program.MenuThird(currentTime);

            Assert.IsFalse(result); // Используем Assert.IsFalse вместо Assert.IsTrue
        }

        [TestMethod]
        public void MenuFourth_CreateTimeArrayWithDefaultConstructor_ReturnsValidTimeArray()
        {
            string userInput = "1\n3\n5";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);

            TimeArray result = Program.MenuFourth();

            Assert.AreEqual(3, result.Length);
        }

        [TestMethod]
        public void MenuFourth_CreateTimeArrayWithParameterizedConstructor_ReturnsValidTimeArray()
        {
            string userInput = "2\n5\n3\n5";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);

            TimeArray result = Program.MenuFourth();

            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void uFourth_CreateTimeArrayWithParameterizedConstructorUserInput_ReturnsValidTimeArray()
        {
            string userInput = "3\n2\n1\n5\n2\n10\n3\n5";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);

            TimeArray result = Program.MenuFourth();

            Assert.AreEqual(2, result.Length);
        }

        [TestMethod]
        public void MenuFourth_DisplayObjectCount_ReturnsObjectCount()
        {
            string userInput = "4\n5";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);

            TimeArray result = Program.MenuFourth();

            Assert.IsNull(result); 
        }

        [TestMethod]
        public void MenuFifth_ShouldReturnTrue()
        {
            int size = 3;
            TimeArray timeArray = new TimeArray();
            string userInput = "1\n3";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);
            bool result = Program.MenuFifth(timeArray, size);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MenuFifth_ShouldReturnFalse()
        {
            int size = 0;
            TimeArray timeArray = new TimeArray();
            string userInput = "1\n3";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);
            bool result = Program.MenuFifth(timeArray, size);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MenuFifth_ShouldReturnTrueAgain()
        {
            int size = 3;
            TimeArray timeArray = new TimeArray();
            string userInput = "2\n3";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);
            bool result = Program.MenuFifth(timeArray, size);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MenuFifth_ShouldReturnFalseAgain()
        {
            int size = 0;
            TimeArray timeArray = new TimeArray();
            string userInput = "2\n3";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);
            bool result = Program.MenuFifth(timeArray, size);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MinTime_ReturnsMinimumTime()
        {
            TimeArray timeArray = new TimeArray();
            int size = 3;

            Time expectedMinTime = new Time(0, 0);


            Time result = Program.MinTime(timeArray, size);

            Assert.AreEqual(0, result.Hours);
            Assert.AreEqual(0, result.Minutes);
        }

        [TestMethod]
        public void IsEqual_HoursAndMinutesAreZero_ReturnsFalse()
        {
            Time currentTime = new Time(0, 0);

            bool result = Program.IsEqual(currentTime);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsEqual_HoursAndMinutesAreNonZero_ReturnsTrue()
        {
            Time currentTime = new Time(5, 30);

            bool result = Program.IsEqual(currentTime);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PartFirstTwo_ReturnsHoursOnly()
        {
            Time currentTime = new Time(21, 32);

            int result = Program.GetHours(currentTime);

            Assert.AreEqual(21, result);
        }
    }
}