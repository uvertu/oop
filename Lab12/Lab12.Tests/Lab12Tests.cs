using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Lab12.Tests
{
    [TestClass]
    public class ItemLinkedListTests
    {
        [TestMethod]
        public void Add_SingleItem_ItemAdded()
        {
            // Arrange
            var list = new ItemLinkedList<int>();

            // Act
            list.Add(42);

            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(42, list[0]);
        }

        [TestMethod]
        public void AddRange_MultipleItems_ItemsAdded()
        {
            // Arrange
            var list = new ItemLinkedList<int>();

            // Act
            list.AddRange(new[] { 1, 2, 3 });

            // Assert
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
        }

        [TestMethod]
        public void Remove_SingleItem_ItemRemoved()
        {
            // Arrange
            var list = new ItemLinkedList<int>();
            list.Add(42);

            // Act
            bool result = list.Remove(42);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void RemoveRange_MultipleItems_ItemsRemoved()
        {
            // Arrange
            var list = new ItemLinkedList<int>();
            list.AddRange(new[] { 1, 2, 3 });

            // Act
            list.RemoveRange(new[] { 1, 3 });

            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(2, list[0]);
        }

        [TestMethod]
        public void RemoveLast_LastItemRemoved_ItemRemoved()
        {
            // Arrange
            var list = new ItemLinkedList<Car>();
            list.Add(new Car(0, 0, "BMW"));
            list.Add(new Car(0, 0, "Ford"));
            list.Add(new Car(0, 0, "Toyota"));

            // Act
            list.RemoveLast("Toyota");

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.IsFalse(list.Contains(new Car(0, 0, "Toyota")));
        }

        [TestMethod]
        public void CopyTo_CopyListToArray_AllElementsMatch()
        {
            // Arrange
            ItemLinkedList<int> list = new ItemLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            int[] array = new int[3];

            // Act
            list.CopyTo(array, 0);

            // Assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, array);
        }

        [TestMethod]
        public void Clear_EmptyList_HeadTailAreNullAndCountIsZero()
        {
            // Arrange
            ItemLinkedList<int> list = new ItemLinkedList<int>();
            list.Add(1);
            list.Add(2);

            // Act
            list.Clear();

            // Assert
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void Contains_ItemPresent_ReturnsTrue()
        {
            // Arrange
            var list = new ItemLinkedList<Car>();
            list.Add(new Car(0, 0, "Toyota"));
            list.Add(new Car(0, 0, "Ford"));

            // Act
            bool result = list.Contains(new Car(0, 0, "Toyota"));

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Contains_ItemNotPresent_ReturnsFalse()
        {
            // Arrange
            var list = new ItemLinkedList<Car>();
            list.Add(new Car(0, 0, "Toyota"));
            list.Add(new Car(0, 0, "Ford"));

            // Act
            bool result = list.Contains(new Car(0, 0, "Honda"));

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Clone_ListClonedWithICloneableItems_ItemsCloned()
        {
            // Arrange
            var list = new ItemLinkedList<Car>();
            list.Add(new Car(0, 0, "Toyota"));
            list.Add(new Car(0, 0, "Ford"));

            // Act
            var clonedList = list.Clone();

            // Assert
            Assert.AreEqual(2, clonedList.Count);
            Assert.AreSame(list[0], clonedList[0]);
            Assert.AreSame(list[1], clonedList[1]);
        }

        [TestMethod]
        public void ShallowCopy_ListShallowCopied_ItemsNotCloned()
        {
            // Arrange
            var list = new ItemLinkedList<Car>();
            list.Add(new Car(0, 0, "Toyota"));
            list.Add(new Car(0, 0, "Ford"));

            // Act
            var copiedList = list.ShallowCopy();

            // Assert
            Assert.AreEqual(2, copiedList.Count);
            Assert.AreSame(list[0], copiedList[0]);
            Assert.AreSame(list[1], copiedList[1]);
        }

        [TestMethod]
        public void GetEnumerator_ListWithItems_EnumeratesItems()
        {
            // Arrange
            var list = new ItemLinkedList<int>();
            list.AddRange(new[] { 1, 2, 3 });

            // Act
            var enumerator = list.GetEnumerator();

            // Assert
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(1, enumerator.Current);

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(2, enumerator.Current);

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(3, enumerator.Current);

            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        public void ToString_ReturnsStringRepresentationOfData()
        {
            // Arrange
            Item<int> item = new Item<int>(42);

            // Act
            string result = item.ToString();

            // Assert
            Assert.AreEqual("42", result);
        }

        [TestMethod]
        public void TestGetValidInput_LowerBound()
        {
            // Arrange
            const int maxValue = 100;
            string prompt = "¬ведите значение: ";
            string validInput = "1";
            StringReader stringReader = new StringReader(validInput);
            Console.SetIn(stringReader);

            // Act
            int resultValidInput = Programm.GetValidInput(prompt, maxValue);

            // Assert
            Assert.AreEqual(1, resultValidInput);
        }

        [TestMethod]
        public void TestGetValidInput_UpperBound()
        {
            // Arrange
            const int maxValue = 100;
            string prompt = "¬ведите значение: ";
            string validInput = "100";
            StringReader stringReader = new StringReader(validInput);
            Console.SetIn(stringReader);

            // Act
            int resultValidInput = Programm.GetValidInput(prompt, maxValue);

            // Assert
            Assert.AreEqual(100, resultValidInput);
        }

        [TestMethod]
        public void TestGetValidInput_InvalidInputThenValidInput()
        {
            // Arrange
            const int maxValue = 100;
            string prompt = "¬ведите значение: ";
            string invalidInput = "invalid";
            string validInput = "50";
            StringReader stringReader = new StringReader($"{invalidInput}{Environment.NewLine}{validInput}");
            Console.SetIn(stringReader);

            // Act
            int resultValidInput = Programm.GetValidInput(prompt, maxValue);

            // Assert
            Assert.AreEqual(50, resultValidInput);
        }

        [TestMethod]
        public void Current_ReturnsCorrectValue()
        {
            // Arrange
            ItemLinkedList<int> list = new ItemLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            MyEnumerator<int> enumerator = new MyEnumerator<int>(list);

            // Act
            enumerator.MoveNext();
            int currentValue = enumerator.Current;

            // Assert
            Assert.AreEqual(1, currentValue);
        }
    }

}
