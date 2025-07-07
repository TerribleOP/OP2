using Microsoft.VisualStudio.TestTools.UnitTesting;
using L3;
using System;
using System.Collections.Generic;

namespace L3.Tests
{
    [TestClass()]
    public class CustomLinkedListTests
    {
        private CustomLinkedList<int> list;
        private CustomLinkedList<Tourist> list2;
        private CustomLinkedList<Hotel> list3;

        [TestInitialize]
        public void Setup()
        {
            list = new CustomLinkedList<int>();
            list.AddToEnd(1);
            list.AddToEnd(2);
            list.AddToEnd(3);
            list2 = new CustomLinkedList<Tourist>();
            list2.AddToEnd(new Tourist("Alastname", "Afirstname", "Hotel1", "Room1", 5));
            list2.AddToEnd(new Tourist("Blastname", "Bfirstname", "Hotel2", "Room2", 3));
            list2.AddToEnd(new Tourist("Clastname", "Cfirstname", "Hotel3", "Room3", 2));
            list3 = new CustomLinkedList<Hotel>();
            list3.AddToEnd(new Hotel("AHotel", "Room1", 5));
            list3.AddToEnd(new Hotel("BHotel", "Room2", 3));
            list3.AddToEnd(new Hotel("CHotel", "Room3", 2));
        }

        [TestMethod]
        public void AddtoEndTest()
        {
            var enumerator = list.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(1, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(2, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(3, enumerator.Current);
        }

        [TestMethod]
        public void AddtoEndTestTourist()
        {
            var enumerator = list2.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(new Tourist("Alastname", "Afirstname", "Hotel1", "Room1", 5), enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(new Tourist("Blastname", "Bfirstname", "Hotel2", "Room2", 3), enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(new Tourist("Clastname", "Cfirstname", "Hotel3", "Room3", 2), enumerator.Current);
        }

        [TestMethod]
        public void AddtoEndTestHotel()
        {
            var enumerator = list3.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(new Hotel("AHotel", "Room1", 5), enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(new Hotel("BHotel", "Room2", 3), enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(new Hotel("CHotel", "Room3", 2), enumerator.Current);
        }

        [TestMethod]
        public void GetTest()
        {
            list.Start();
            Assert.AreEqual(1, list.Get());
        }

        [TestMethod]
        public void GetTestTourist()
        {
            list2.Start();
            Assert.AreEqual(new Tourist("Alastname", "Afirstname", "Hotel1", "Room1", 5), list2.Get());
        }

        [TestMethod]
        public void GetTestHotel()
        {
            list3.Start();
            Assert.AreEqual(new Hotel("AHotel", "Room1", 5), list3.Get());
        }

        [TestMethod]
        public void NextTest()
        {
            list.Start();
            list.Next();
            Assert.AreEqual(2, list.Get());
        }

        [TestMethod]
        public void NextTestTourist()
        {
            list2.Start();
            list2.Next();
            Assert.AreEqual(new Tourist("Blastname", "Bfirstname", "Hotel2", "Room2", 3), list2.Get());
        }

        [TestMethod]
        public void NextTestHotel()
        {
            list3.Start();
            list3.Next();
            Assert.AreEqual(new Hotel("BHotel", "Room2", 3), list3.Get());
        }

        [TestMethod]
        public void ExistsTest()
        {
            list.Start();
            Assert.IsTrue(list.Exists());
            list.Next();
            Assert.IsTrue(list.Exists());
            list.Next();
            Assert.IsTrue(list.Exists());
            list.Next();
            Assert.IsFalse(list.Exists());
        }

        [TestMethod]
        public void ExistsTestTourist()
        {
            list2.Start();
            Assert.IsTrue(list2.Exists());
            list2.Next();
            Assert.IsTrue(list2.Exists());
            list2.Next();
            Assert.IsTrue(list2.Exists());
            list2.Next();
            Assert.IsFalse(list2.Exists());
        }

        [TestMethod]
        public void ExistsTestHotel()
        {
            list3.Start();
            Assert.IsTrue(list3.Exists());
            list3.Next();
            Assert.IsTrue(list3.Exists());
            list3.Next();
            Assert.IsTrue(list3.Exists());
            list3.Next();
            Assert.IsFalse(list3.Exists());
        }

        [TestMethod]
        public void StartTest()
        {
            list.Start();
            Assert.AreEqual(1, list.Get());
        }

        [TestMethod]
        public void StartTestTourist()
        {
            list2.Start();
            Assert.AreEqual(new Tourist("Alastname", "Afirstname", "Hotel1", "Room1", 5), list2.Get());
        }

        [TestMethod]
        public void StartTestHotel()
        {
            list3.Start();
            Assert.AreEqual(new Hotel("AHotel", "Room1", 5), list3.Get());
        }

        [TestMethod]
        public void EndTest()
        {
            list.End();
            Assert.IsFalse(list.Exists());
        }

        [TestMethod]
        public void EndTestTourist()
        {
            list2.End();
            Assert.IsFalse(list2.Exists());
        }

        [TestMethod]
        public void EndTestHotel()
        {
            list3.End();
            Assert.IsFalse(list3.Exists());
        }

        [TestMethod]
        public void SortTest()
        {
            list.BubbleSort();
            var enumerator = list.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(3, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(2, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(1, enumerator.Current);
        }

        [TestMethod]
        public void SortTestTourist()
        {
            list2.BubbleSort();
            var enumerator = list2.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(new Tourist("Clastname", "Cfirstname", "Hotel3", "Room3", 2), enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(new Tourist("Blastname", "Bfirstname", "Hotel2", "Room2", 3), enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(new Tourist("Alastname", "Afirstname", "Hotel1", "Room1", 5), enumerator.Current);
        }

        [TestMethod]
        public void SortTestHotel()
        {
            list3.BubbleSort();
            var enumerator = list3.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(new Hotel("CHotel", "Room3", 2), enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(new Hotel("BHotel", "Room2", 3), enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(new Hotel("AHotel", "Room1", 5), enumerator.Current);
        }
    }
}
