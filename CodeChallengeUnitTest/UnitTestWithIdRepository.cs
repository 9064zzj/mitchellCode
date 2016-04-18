using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeChallenge;
using System.Collections.Generic;

namespace CodeChallengeUnitTest
{
    [TestClass]
    public class UnitTestWithIdRepository
    {
        [TestMethod]
        public void TestGetAll()
        {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();
            testRepository.Add(ref tmp1);

            //Act
            List<TestClass> results = new List<TestClass>(testRepository.GetAll());

            //Assert
            Assert.AreEqual(1,results.Count);
            Assert.AreEqual(tmp1, results[0]);           
        }

        [TestMethod]
        public void TestAdd()
        {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();

            //Act
            testRepository.Add(ref tmp1);

            //Assert
            List<TestClass> results = new List<TestClass>(testRepository.GetAll());
            Assert.AreEqual(tmp1, results[0]);
            Assert.AreEqual(tmp1,testRepository.GetById(1));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestAdd_WithNull()
        {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = null;

            //Act
            testRepository.Add(ref tmp1);
        }

        [TestMethod]
        public void TestAdd_IdChanges() {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();
            tmp1.Id = -100;

            //Act
            testRepository.Add(ref tmp1);

            //Assser
            List<TestClass> results = new List<TestClass>(testRepository.GetAll());
            Assert.AreEqual(1, results[0].Id);
            Assert.AreEqual(tmp1, testRepository.GetById(1));
        }

        [TestMethod]
        public void TestAdd_IdIncrement() {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();
            TestClass tmp2 = new TestClass();
            tmp1.Id = -100;
            tmp2.Id = -100;

            //Act
            testRepository.Add(ref tmp1);
            testRepository.Add(ref tmp2);

            //Assert
            Assert.AreEqual(2, testRepository.GetById(2).Id);
        }

        [TestMethod]
        public void TestAdd_AddTwice() {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();

            //Act
            testRepository.Add(ref tmp1);
            bool success = testRepository.Add(ref tmp1);

            //Assert
            Assert.AreEqual(false, success);
            Assert.AreEqual(1, tmp1.Id);
        }

        [TestMethod]
        public void TestGetById() {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();
            testRepository.Add(ref tmp1);

            //Act
            TestClass result = testRepository.GetById(tmp1.Id);

            //Assert
            Assert.AreEqual(tmp1, result);
        }

        [TestMethod]
        public void TestGetById_InvalidId() {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();

            //Act
            TestClass result = testRepository.GetById(-100);

            //Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestGetBy() {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();
            TestClass tmp2 = new TestClass();
            tmp1.msg = "message";
            tmp2.msg = "TestMessage";
            testRepository.Add(ref tmp1);
            testRepository.Add(ref tmp2);
            List<Func<TestClass, bool>> predicates = new List<Func<TestClass, bool>>();
            predicates.Add( new Func<TestClass, bool>(x => x.msg.Equals("TestMessage")));

            //Act
            List<TestClass> results = new List<TestClass>(testRepository.GetBy(predicates));

            //Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(tmp2, results[0]);
        }

        [TestMethod]
        public void TestGetBy_EmptyPredicates() {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();
            TestClass tmp2 = new TestClass();
            tmp1.msg = "message";
            tmp2.msg = "TestMessage";
            testRepository.Add(ref tmp1);
            testRepository.Add(ref tmp2);
            List<Func<TestClass, bool>> predicates = new List<Func<TestClass, bool>>();

            //Act
            List<TestClass> results = new List<TestClass>(testRepository.GetBy(predicates));

            //Assert
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(tmp1, results[0]);
            Assert.AreEqual(tmp2, results[1]);
        }

        [TestMethod]
        public void TestGetBy_NullPredicates()
        {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();
            TestClass tmp2 = new TestClass();
            tmp1.msg = "message";
            tmp2.msg = "TestMessage";
            testRepository.Add(ref tmp1);
            testRepository.Add(ref tmp2);

            //Act
            List<TestClass> results = new List<TestClass>(testRepository.GetBy(null));

            //Assert
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(tmp1, results[0]);
            Assert.AreEqual(tmp2, results[1]);
        }

        [TestMethod]
        public void TestDelete() {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();
            TestClass tmp2 = new TestClass();
            testRepository.Add(ref tmp1);
            testRepository.Add(ref tmp2);

            //Act
            testRepository.Delete(tmp1.Id);

            //Assert
            List<TestClass> results = new List<TestClass>(testRepository.GetAll());
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(tmp2, results[0]);
        }

        [TestMethod]
        public void TestDelete_DeleteInvalidId()
        {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();
            TestClass tmp2 = new TestClass();
            testRepository.Add(ref tmp1);
            testRepository.Add(ref tmp2);

            //Act
            testRepository.Delete(3);

            //Assert
            List<TestClass> results = new List<TestClass>(testRepository.GetAll());
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(tmp1, results[0]);
            Assert.AreEqual(tmp2, results[1]);
        }

        [TestMethod]
        public void TestUpdate() {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();
            TestClass tmp2 = new TestClass();
            tmp1.msg = "message";
            tmp2.msg = "changedMessage";
            testRepository.Add(ref tmp1);
            tmp2.Id = tmp1.Id;

            //Act
            testRepository.Update(tmp2);

            //Assert
            List<TestClass> results = new List<TestClass>(testRepository.GetAll());
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(tmp2, results[0]);
            Assert.AreEqual("changedMessage", results[0].msg);
        }

        [TestMethod]
        public void TestUpdate_InvalidId() {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();
            TestClass tmp2 = new TestClass();
            tmp1.msg = "message";
            tmp2.msg = "changedMessage";
            testRepository.Add(ref tmp1);
            tmp2.Id = -100;

            //Act
            testRepository.Update(tmp2);

            //Assert
            List<TestClass> results = new List<TestClass>(testRepository.GetAll());
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(tmp1, results[0]);
            Assert.AreEqual("message", results[0].msg);
        }

        [TestMethod]
        public void TestUpdate_Twice()
        {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();
            TestClass tmp2 = new TestClass();
            tmp1.msg = "message";
            tmp2.msg = "changedMessage";
            testRepository.Add(ref tmp1);
            tmp2.Id = tmp1.Id;

            //Act
            testRepository.Update(tmp2);
            testRepository.Update(tmp2);

            //Assert
            List<TestClass> results = new List<TestClass>(testRepository.GetAll());
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(tmp2, results[0]);
            Assert.AreEqual("changedMessage", results[0].msg);
        }

        [TestMethod]
        public void TestUpdate_Null()
        {
            //Arrange
            WithIdRepository<TestClass> testRepository = new WithIdRepository<TestClass>();
            TestClass tmp1 = new TestClass();
            tmp1.msg = "message";
            testRepository.Add(ref tmp1);

            //Act
            testRepository.Update(null);

            //Assert
            List<TestClass> results = new List<TestClass>(testRepository.GetAll());
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(tmp1, results[0]);
            Assert.AreEqual("message", results[0].msg);
        }
    }
}
