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
    public class UserTests
    {
        private User user = new User { Id = 1, Address = "Hello", City = "Hello", Name = "Hello", Password = "Hello", phoneNumber = "12345678", TrashCanId = 1, UserName = "Hello ", ZipCode = 1234 };
        private User useridnulltest = new User { Id = null, Address = "Hello", City = "Hello", Name = "Hello", Password = "Hello", phoneNumber = "12345678", TrashCanId = 1, UserName = "Hello ", ZipCode = 1234 };
        private User useridrangetest = new User { Id = -1, Address = "Hello", City = "Hello", Name = "Hello", Password = "Hello", phoneNumber = "12345678", TrashCanId = 1, UserName = "Hello ", ZipCode = 1234 };
        private User userNameRangetest = new User { Id = 1, Address = "Hello", City = "Hello", Name = "", Password = "Hello", phoneNumber = "12345678", TrashCanId = 1, UserName = "Hello ", ZipCode = 1234 };
        private User userNamenulltest = new User { Id = 1, Address = "Hello", City = "Hello", Name = null, Password = "Hello", phoneNumber = "12345678", TrashCanId = 1, UserName = "Hello ", ZipCode = 1234 };
        private User userCitynulltest = new User { Id = 1, Address = "Hello", City = null, Name = "Hello", Password = "Hello", phoneNumber = "12345678", TrashCanId = 1, UserName = "Hello ", ZipCode = 1234 };
        private User userCityrangetest = new User { Id = 1, Address = "Hello", City = "", Name = "Hello", Password = "Hello", phoneNumber = "12345678", TrashCanId = 1, UserName = "Hello ", ZipCode = 1234 };
        private User userAddressrangetest = new User { Id = 1, Address = "", City = "", Name = "Hello", Password = "Hello", phoneNumber = "12345678", TrashCanId = 1, UserName = "Hello ", ZipCode = 1234 };
        private User userAddressnulltest = new User { Id = 1, Address = null, City = "", Name = "Hello", Password = "Hello", phoneNumber = "12345678", TrashCanId = 1, UserName = "Hello ", ZipCode = 1234 };
        private User userZipCodenulltest = new User { Id = 1, Address = "Hello", City = "Hello", Name = "Hello", Password = "Hello", phoneNumber = "12345678", TrashCanId = 1, UserName = "Hello ", ZipCode = null };
        private User userZipCoderangetest = new User { Id = 1, Address = "Hello", City = "Hello", Name = "Hello", Password = "Hello", phoneNumber = "12345678", TrashCanId = 1, UserName = "Hello ", ZipCode = 1 };
        private User userTlfNumbernulltest = new User { Id = 1, Address = "Hello", City = "Hello", Name = "Hello", Password = "Hello", phoneNumber = null, TrashCanId = 1, UserName = "Hello ", ZipCode = 1234 };
        private User userTlfNumberrangetest = new User { Id = 1, Address = "Hello", City = "Hello", Name = "Hello", Password = "Hello", phoneNumber = "1", TrashCanId = 1, UserName = "Hello ", ZipCode = 1234 };
        private User userUserNamerangetest = new User { Id = 1, Address = "Hello", City = "Hello", Name = "Hello", Password = "Hello", phoneNumber = "12345678", TrashCanId = 1, UserName = "", ZipCode = 1234 };
        private User userUserNamenulltest = new User { Id = 1, Address = "Hello", City = "Hello", Name = "Hello", Password = "Hello", phoneNumber = "12345678", TrashCanId = 1, UserName = null, ZipCode = 1234 };
        private User userPasswordrangetest = new User { Id = 1, Address = "Hello", City = "Hello", Name = "Hello", Password = "1234", phoneNumber = "12345678", TrashCanId = 1, UserName = "Hello", ZipCode = 1234 };
        private User userPasswordnulltest = new User { Id = 1, Address = "Hello", City = "Hello", Name = "Hello", Password = null, phoneNumber = "12345678", TrashCanId = 1, UserName = "Hello", ZipCode = 1234 };
        private User userTrashIdnulltest = new User { Id = 1, Address = "Hello", City = "Hello", Name = "Hello", Password = "Hello", phoneNumber = "12345678", TrashCanId = null, UserName = "Hello", ZipCode = 1234 };
        private User userThrashIdrangetest = new User { Id = 1, Address = "Hello", City = "Hello", Name = "Hello", Password = "Hello", phoneNumber = "12345678", TrashCanId = -1, UserName = "Hello", ZipCode = 1234 };


        [TestMethod()]
        public void ValidateIdTest()
        {
            user.ValidateId();
            Assert.ThrowsException<ArgumentNullException>((() => useridnulltest.ValidateId()));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => useridrangetest.ValidateId());
        }

        [TestMethod()]
        public void ValidateNameTest()
        {
            user.ValidateName();
            Assert.ThrowsException<ArgumentNullException>(() => userNamenulltest.ValidateName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => userNameRangetest.ValidateName());
        }

        [TestMethod()]
        public void ValidateCityTest()
        {
            user.ValidateCity();
            Assert.ThrowsException<ArgumentNullException>(() => userCitynulltest.ValidateCity());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => userCityrangetest.ValidateCity());
        }

        [TestMethod()]
        public void ValidateAddressTest()
        {
            user.ValidateAddress();
            Assert.ThrowsException<ArgumentNullException>(() => userAddressnulltest.ValidateAddress());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => userAddressrangetest.ValidateAddress());
        }

        [TestMethod()]
        public void ValidateZipCodeTest()
        {
            user.ValidateZipCode();
            Assert.ThrowsException<ArgumentNullException>(() => userZipCodenulltest.ValidateZipCode());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => userZipCoderangetest.ValidateZipCode());
        }

        [TestMethod()]
        public void ValidateTlfNumberTest()
        {
            user.ValidatePhoneNumber();
            Assert.ThrowsException<ArgumentNullException>(() => userTlfNumbernulltest.ValidatePhoneNumber());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => userTlfNumberrangetest.ValidatePhoneNumber());
        }

        [TestMethod()]
        public void ValidateUserNameTest()
        {
            user.ValidateUserName();
            Assert.ThrowsException<ArgumentNullException>(() => userUserNamenulltest.ValidateUserName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => userUserNamerangetest.ValidateUserName());
        }

        [TestMethod()]
        public void ValidatePasswordTest()
        {
            user.ValidatePassword();
            Assert.ThrowsException<ArgumentNullException>(() => userPasswordnulltest.ValidatePassword());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => userPasswordrangetest.ValidatePassword());
        }

        [TestMethod()]
        public void ValidateTrashIdTest()
        {
            user.ValidateTrashId();
            Assert.ThrowsException<ArgumentNullException>(() => userTrashIdnulltest.ValidateTrashId());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => userThrashIdrangetest.ValidateTrashId());
        }
    }
}