using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Diagnostics;

namespace Lab9.Tests
{
    [TestClass]
    public class TimeArrayTests
    {
        [TestMethod]
        public void TestDefaultConstructor()
        {
            TimeArray timeArray = new TimeArray();

            int objectCount = TimeArray.GetObjectCount();

            Assert.AreEqual(3, timeArray.Length);
        }

        [TestMethod]
        public void TestParametrizedConstructor()
        {
            int size = 5;

            Console.WriteLine("Before creating TimeArray. Object count: " + TimeArray.GetObjectCount());

            TimeArray timeArray = new TimeArray(size);

            Console.WriteLine("After creating TimeArray. Object count: " + TimeArray.GetObjectCount());

            Assert.AreEqual(size, timeArray.Length);
        }

        [TestMethod]
        public void Constructor_UserInput_ShouldCreateTimeArrayWithExpectedValues()
        {
            var userInput = "12\n5\n13\n10\n8\n15\n"; 
            var stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);

            TimeArray timeArray = new TimeArray(3, userInput: true);

            Assert.AreEqual(12, timeArray[0].Hours);
            Assert.AreEqual(5, timeArray[0].Minutes);

            Assert.AreEqual(13, timeArray[1].Hours);
            Assert.AreEqual(10, timeArray[1].Minutes);

            Assert.AreEqual(8, timeArray[2].Hours);
            Assert.AreEqual(15, timeArray[2].Minutes);
        }

        [TestMethod]
        public void DisplayArray_ShouldPrintDefaultTimeArrayToConsole()
        {
            TimeArray timeArray = new TimeArray();
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            timeArray.DisplayArray();

            string expectedOutput = "12:00\r\n00:00\r\n23:15\r\n";
            Assert.AreEqual(expectedOutput, sw.ToString());
        }

        [TestMethod]
        public void TestGetObjectCount()
        {
            int initialObjectCount = TimeArray.GetObjectCount();

            TimeArray timeArray = new TimeArray();

            Assert.AreEqual(initialObjectCount + 1, TimeArray.GetObjectCount());
        }

        [TestMethod]
        public void TestIndexer()
        {
            TimeArray timeArray = new TimeArray();

            Time time = new Time(5, 30);
            timeArray[1] = time;

            Assert.AreEqual(time, timeArray[1]);
        }

        [TestMethod]
        public void Indexer_GetOutOfRangeIndex_ShouldThrowIndexOutOfRangeException()
        {
            TimeArray timeArray = new TimeArray(3);

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                var time = timeArray[-1];
            });

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                var time = timeArray[3];
            });
        }

        [TestMethod]
        public void Indexer_SetOutOfRangeIndex_ShouldThrowIndexOutOfRangeException()
        {
            TimeArray timeArray = new TimeArray(3);

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                timeArray[-1] = new Time(1, 1);
            });

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                timeArray[3] = new Time(2, 2);
            });
        }
    }
}
