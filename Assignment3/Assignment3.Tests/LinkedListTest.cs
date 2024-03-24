using Assignment3.Utility;
using NUnit.Framework;
using System;

namespace Assignment3.Tests
{
    [TestFixture]
    public class LinkedListTest
    {
        private ILinkedListADT<int> list;

        [SetUp]
        public void Setup()
        {
            list = new SLL<int>();
        }

        [Test]
        public void TestLinkedListIsEmpty()
        {
            Assert.AreEqual(0, list.GetSize());
        }

        [Test]
        public void TestPrepend()
        {
            list.Prepend(5);
            Assert.AreEqual(1, list.GetSize());
            Assert.AreEqual(5, list.GetAtIndex(0));
        }

        [Test]
        public void TestAppend()
        {
            list.Append(10);
            Assert.AreEqual(1, list.GetSize());
            Assert.AreEqual(10, list.GetAtIndex(0));
        }

        [Test]
        public void TestInsertAtIndex()
        {
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.InsertAtIndex(1, 10);
            Assert.AreEqual(4, list.GetSize());
            Assert.AreEqual(10, list.GetAtIndex(1));
        }

        [Test]
        public void TestReplace()
        {
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.Replace(1, 10);
            Assert.AreEqual(3, list.GetSize());
            Assert.AreEqual(10, list.GetAtIndex(1));
        }

        [Test]
        public void TestDeleteFromBeginning()
        {
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.RemoveFirst();
            Assert.AreEqual(2, list.GetSize());
            Assert.AreEqual(2, list.GetAtIndex(0));
        }

        [Test]
        public void TestDeleteFromEnd()
        {
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.RemoveLast();
            Assert.AreEqual(2, list.GetSize());
            Assert.AreEqual(2, list.GetAtIndex(1));
        }

        [Test]
        public void TestDeleteFromMiddle()
        {
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.RemoveAtIndex(1);
            Assert.AreEqual(2, list.GetSize());
            Assert.AreEqual(3, list.GetAtIndex(1));
        }

        [Test]
        public void TestFindAndRetrieve()
        {
            list.Append(1);
            list.Append(2);
            list.Append(3);
            Assert.IsTrue(list.Contains(2));
            Assert.AreEqual(1, list.GetIndex(2));
        }

        [Test]
        public void TestDivideAtIndex()
        {
            // Populate the linked list
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.Append(4);
            list.Append(5);

            // Divide the list at index 2
            DividedLists<int> dividedLists = list.DivideAtIndex(2);

            // Check the first part
            Assert.AreEqual(2, dividedLists.FirstPart.GetSize());
            Assert.AreEqual(1, dividedLists.FirstPart.GetAtIndex(0));
            Assert.AreEqual(2, dividedLists.FirstPart.GetAtIndex(1));

            // Check the second part
            Assert.AreEqual(3, dividedLists.SecondPart.GetSize());
            Assert.AreEqual(3, dividedLists.SecondPart.GetAtIndex(0));
            Assert.AreEqual(4, dividedLists.SecondPart.GetAtIndex(1));
            Assert.AreEqual(5, dividedLists.SecondPart.GetAtIndex(2));
        }


    }
}
