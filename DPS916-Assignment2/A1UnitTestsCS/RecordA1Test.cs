using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1ClassLibraryCS;
using System.Collections.Generic;

namespace A1UnitTestsCS
{
    [TestClass]
    public class RecordA1Test
    {
        private RecordA1 testRecord;

        [TestInitialize]
        public void RecordA1Initialize()
        {
            if (testRecord == null)
            {
                testRecord = new RecordA1();
            }
        }

        [TestCleanup]
        public void RecordA1Cleanup()
        {
            if (testRecord != null)
            {
                testRecord = null;
            }
        }

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(testRecord.UserName, String.Empty);
            Assert.IsTrue(testRecord.EmailAddresses.Count == 0);
            Assert.IsTrue(testRecord.Addresses.Count == 0);
            Assert.IsTrue(testRecord.PhoneNumbers.Count == 0);
            Assert.AreEqual(testRecord.Notes, String.Empty);
        }

        [TestMethod]
        public void TestEmailOrderChange()
        {
            List<string> emails = new List<string>();
            emails.Add("test1@email.com");
            emails.Add("test2@email.com");
            emails.Add("test3@email.com");
            testRecord.EmailAddresses = emails;
            testRecord.changeEmailOrder(0, 1);
            Assert.IsTrue(testRecord.EmailAddresses[1].Equals("test1@email.com"));
        }

        [TestMethod]
        public void TestPhoneNumberOrderChange()
        {
            List<string> numbers = new List<string>();
            numbers.Add("4164465979");
            numbers.Add("6472855979");
            numbers.Add("2280785558");
            numbers.Add("5555555555");
            testRecord.PhoneNumbers = numbers;
            testRecord.changePhoneNumberOrder(3, 1);
            Assert.IsTrue(testRecord.PhoneNumbers[1].Equals("5555555555"));
        }

        [TestMethod]
        public void TestAddressOrderChange()
        {
            List<string> addresses = new List<string>();
            addresses.Add("71 Farmstead Rd");
            addresses.Add("55 Tangmere Av");
            addresses.Add("123 Fake Street");
            testRecord.Addresses = addresses;
            testRecord.changeAddressOrder(2, 1);
            Assert.IsTrue(testRecord.Addresses[2].Equals("55 Tangmere Av"));
        }
    }
}
