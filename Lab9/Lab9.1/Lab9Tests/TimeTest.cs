namespace Lab9.Tests
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void SubtractMinutes_StaticMethod_ReturnsCorrectResult()
        {
            Time time = new Time(10, 30);
            int subtractMinutes = 15;

            Time result = Time.SubtractMinutesStatic(time, subtractMinutes);

            Assert.AreEqual(10, result.Hours);
            Assert.AreEqual(15, result.Minutes);
        }

        [TestMethod]
        public void SubtractMinutes_InstanceMethod_ReturnsCorrectResult()
        {
            Time time = new Time(10, 30);
            int subtractMinutes = 15;

            time.SubtractMinutes(subtractMinutes);

            Assert.AreEqual(10, time.Hours);
            Assert.AreEqual(15, time.Minutes);
        }

        [TestMethod]
        public void DisplayTime_ConsoleOutput()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            Time time = new Time(8, 45);
            time.DisplayTime();
            string expected = "08:45" + Environment.NewLine;

            Assert.AreEqual(expected, sw.ToString());
        }

        [TestMethod]
        public void GetObjectCount_ReturnsCorrectCount()
        {
            int initialCount = Time.GetObjectCount();

            Time time1 = new Time(1, 30);
            Time time2 = new Time(2, 45);

            Assert.AreEqual(initialCount + 2, Time.GetObjectCount());
        }

        [TestMethod]
        public void Hours_Setter_SetsCorrectValue()
        {
            Time time = new Time(12, 30);

            time.Hours = 5;

            Assert.AreEqual(5, time.Hours);
        }

        [TestMethod]
        public void Minutes_Setter_SetsCorrectValue()
        {
            Time time = new Time(12, 30);

            time.Minutes = 45;

            Assert.AreEqual(45, time.Minutes);
        }

        [TestMethod]
        public void UnaryMinusOperator_ResetsValuesToZero()
        {
            Time time = new Time(10, 15);

            Time result = -time;

            Assert.AreEqual(0, result.Hours);
            Assert.AreEqual(0, result.Minutes);
        }

        [TestMethod]
        public void DecrementOperator_DecreasesMinutesByOne()
        {
            Time time = new Time(10, 15);

            Time result = --time;

            Assert.AreEqual(10, result.Hours);
            Assert.AreEqual(14, result.Minutes);
        }

        [TestMethod]
        public void DecrementOperator_WhenMinutesAreZero_DecreasesHoursByOne()
        {
            Time time = new Time(10, 0);

            Time result = --time;

            Assert.AreEqual(9, result.Hours);
            Assert.AreEqual(59, result.Minutes);
        }

        [TestMethod]
        public void DecrementOperator_WhenTimeIsZero_ReturnsZeroTime()
        {
            Time time = new Time(0, 0);

            Time result = --time;

            Assert.AreEqual(0, result.Hours);
            Assert.AreEqual(0, result.Minutes);
        }

        [TestMethod]
        public void ImplicitConversionToInt_ReturnsHours()
        {
            Time time = new Time(8, 45);

            int result = time;

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void ExplicitConversionToBool_TrueIfNotZeroTime()
        {
            Time time1 = new Time(0, 0);
            Time time2 = new Time(5, 30);

            bool result1 = (bool)time1;
            bool result2 = (bool)time2;

            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void EqualityOperator_ReturnsTrueForEqualTimes()
        {
            Time time1 = new Time(10, 30);
            Time time2 = new Time(10, 30);

            bool result = time1 == time2;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InequalityOperator_ReturnsTrueForDifferentTimes()
        {
            Time time1 = new Time(10, 30);
            Time time2 = new Time(11, 45);

            bool result = time1 != time2;

            Assert.IsTrue(result);
        }
    }
}
