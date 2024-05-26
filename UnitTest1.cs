using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using Microsoft.Analytics.UnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using лаба12;
using ClassLibrary10;

namespace unit_tests_for_12._1_lab
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AddToEnd_IncreasesCount()
        {
            // Arrange
            var myList = new MyList<BankCard>();
            var item = new BankCard();

            // Act
            myList.AddToEnd(item);

            // Assert
            Assert.AreEqual(1, myList.Count);
        }


            [TestMethod]
        public void AddToBegin_IncreasesCount()
        {
            // Arrange
            var myList = new MyList<BankCard>();
            var item = new BankCard();

            // Act
            myList.AddToBegin(item);

            // Assert
            Assert.AreEqual(1, myList.Count);
        }
        //[TestMethod]

        //public void AddToEnd_AddsItemToEnd()
        //{
        //    // Arrange
        //    var myList = new MyList<BankCard>();
        //    var item1 = new BankCard();
        //    var item2 = new BankCard();

        //    // Act
        //    myList.AddToEnd(item1);
        //    myList.AddToEnd(item2);

        //    // Assert
        //    Assert.AreEqual(20, myList.end.Data);
        //}
        [TestMethod]
        public void MakeRandomItem_ReturnsNonNull()
        {
            // Arrange
            var myList = new MyList<BankCard>();

            // Act
            var randomItem = myList.MakeRandomItem();

            // Assert
            Assert.IsNotNull(randomItem);
        }
        [TestMethod]
        public void FindItem_WhenItemExists_ReturnsCorrectNode()
        {
            // Arrange
            var myList = new MyList<BankCard>();
            myList.AddToEnd(new BankCard());
            myList.AddToEnd(new BankCard());
            myList.AddToEnd(new BankCard());

            // Act
            var result = myList.FindItem(2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Data);
        }
        [TestMethod]
        public void FindItem_WhenItemDoesNotExist_ReturnsNull()
        {
            // Arrange
            var myList = new MyList<BankCard>();
            myList.AddToEnd(new BankCard());
            myList.AddToEnd(new BankCard());

            // Act
            var result = myList.FindItem(44556666);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AddAfterPos_AddsItemAfterFoundItem()
        {
            // Arrange
            var myList = new MyList<BankCard>();
            myList.AddToEnd(new BankCard());
            myList.AddToEnd(new BankCard());

            // Act
            var added = myList.AddAfterPos(1, new BankCard());

            // Assert
            Assert.IsTrue(added);
            Assert.AreEqual(3, myList.FindItem(1).Next.Data);
        }

        [TestMethod]
        public void AddAfterPos_WhenItemNotFound_ReturnsFalse()
        {
            // Arrange
            var myList = new MyList<BankCard>();
            myList.AddToEnd(new BankCard());
            myList.AddToEnd(new BankCard());

            // Act
            var added = myList.AddAfterPos(1, new BankCard());

            // Assert
            Assert.IsFalse(added);
            Assert.IsNull(myList.FindItem(1));
        }
        [TestMethod]
        public void RemoveNodesWithEvenIndexes_RemovesCorrectNodes()
        {
            // Arrange
            MyList<BankCard> myList = new MyList<BankCard>();
            myList.AddToEnd(new BankCard());
            myList.AddToEnd(new BankCard());
            myList.AddToEnd(new BankCard());
            myList.AddToEnd(new BankCard());
            myList.AddToEnd(new BankCard());

            // Act
            myList.RemoveNodesWithEvenIndexes();

            // Assert
            Assert.AreEqual(3, myList.Count);
            Assert.AreEqual(1, myList.Count);
            Assert.AreEqual(3, myList.Count);
            Assert.AreEqual(5, myList.Count);
        }

        
        





    }

}

