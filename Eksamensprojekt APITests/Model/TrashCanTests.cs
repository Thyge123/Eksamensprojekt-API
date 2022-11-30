using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eksamensprojekt_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_API.Model.Tests
{
    [TestClass()]
    public class TrashCanTests
    {
        private TrashCan trashcan = new TrashCan { Id = 1, Address = "Hello", City = "Hello", Estimate = 1, lastEmptied = DateTime.Now, isFull = true, ZipCode = 2222 };
        private TrashCan cityrangetest = new TrashCan { Id = 2, Address = "Hello", City = "", Estimate = 1, lastEmptied = DateTime.Now, isFull = true, ZipCode = 2222 };
        private TrashCan citynulltest = new TrashCan { Id = 3, Address = "Hello", City = null, Estimate = 1, lastEmptied = DateTime.Now, isFull = true, ZipCode = 2222 };
        private TrashCan idrangetest = new TrashCan { Id = -1, Address = "Hello", City = "Hello", Estimate = 1, lastEmptied = DateTime.Now, isFull = true, ZipCode = 2222 };
        private TrashCan idnulltest = new TrashCan { Id = null, Address = "Hello", City = "Hello", Estimate = 1, lastEmptied = DateTime.Now, isFull = true, ZipCode = 2222 };
        private TrashCan addressnulltest = new TrashCan { Id = 6, Address = null, City = "Hello", Estimate = 1, lastEmptied = DateTime.Now, isFull = true, ZipCode = 2222 };
        private TrashCan addressrangetest = new TrashCan { Id = 7, Address = "", City = "Hello", Estimate = 1, lastEmptied = DateTime.Now, isFull = true, ZipCode = 2222 };
        private TrashCan zipcodenulltest = new TrashCan { Id = 8, Address = "Hello", City = "Hello", Estimate = 1, lastEmptied = DateTime.Now, isFull = true, ZipCode = null };
        private TrashCan zipcoderangetest = new TrashCan { Id = 9, Address = "Hello", City = "Hello", Estimate = 1, lastEmptied = DateTime.Now, isFull = true, ZipCode = 2 };
        private TrashCan trashfullnulltest = new TrashCan { Id = 10, Address = "Hello", City = "Hello", Estimate = 1, lastEmptied = DateTime.Now, isFull = null, ZipCode = 2 };
        private TrashCan estimatenulltest = new TrashCan { Id = 11, Address = "Hello", City = "Hello", Estimate = null, lastEmptied = DateTime.Now, isFull = null, ZipCode = 2 };
        private TrashCan estimaterangetoofewtest = new TrashCan { Id = 12, Address = "Hello", City = "Hello", Estimate = 0, lastEmptied = DateTime.Now, isFull = null, ZipCode = 2 };
        private TrashCan estimateragnetoomanytest = new TrashCan { Id = 13, Address = "Hello", City = "Hello", Estimate = 31, lastEmptied = DateTime.Now, isFull = null, ZipCode = 2 };
        private TrashCan lastemptiednulltest = new TrashCan { Id = 13, Address = "Hello", City = "Hello", Estimate = 31, lastEmptied = null, isFull = null, ZipCode = 2 };

        [TestMethod()]
        public void ValidateIdTest()
        {
            trashcan.ValidateId();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => idrangetest.ValidateId());
        }

        [TestMethod()]
        public void ValidateIdNullTest()
        {
            trashcan.ValidateId();
            Assert.ThrowsException<ArgumentNullException>(() => idnulltest.ValidateId());
        }

        [TestMethod()]
        public void ValidateCityTest()
        {
            trashcan.ValidateCity();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cityrangetest.ValidateCity());
        }

        [TestMethod()]
        public void ValidateCityNullTest()
        {
            trashcan.ValidateCity();
            Assert.ThrowsException<ArgumentNullException>(() => citynulltest.ValidateCity());
        }

        [TestMethod()]
        public void ValidateAddressTest()
        {
            trashcan.ValidateAddress();
            Assert.ThrowsException<ArgumentNullException>(() => addressnulltest.ValidateAddress());
            trashcan.ValidateAddress();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => addressrangetest.ValidateAddress());
        }

        [TestMethod()]
        public void ValidateZipCodeTest()
        {
            trashcan.ValidateZipCode();
            Assert.ThrowsException<ArgumentNullException>(() => zipcodenulltest.ValidateZipCode());
            trashcan.ValidateZipCode();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => zipcoderangetest.ValidateZipCode());
        }

        [TestMethod()]
        public void ValidateTrashFullTest()
        {
            trashcan.ValidateTrashFull();
            Assert.ThrowsException<ArgumentNullException>(() => trashfullnulltest.ValidateTrashFull());
        }

        [TestMethod()]
        public void ValidateEstimateTest()
        {
            trashcan.ValidateEstimate();
            Assert.ThrowsException<ArgumentNullException>(() => estimatenulltest.ValidateEstimate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => estimaterangetoofewtest.ValidateEstimate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => estimateragnetoomanytest.ValidateEstimate());
        }

        [TestMethod()]
        public void ValidateLastEmptiedTest()
        {
            trashcan.ValidateLastEmptied();
            Assert.ThrowsException<ArgumentNullException>(() => lastemptiednulltest.ValidateLastEmptied());
        }
    }
}