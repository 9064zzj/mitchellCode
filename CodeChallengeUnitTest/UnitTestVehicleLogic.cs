using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeChallenge;
using System.Collections.Generic;

namespace CodeChallengeUnitTest
{
    [TestClass]
    public class UnitTestVehicleLogic
    {
        [TestMethod]
        public void TestAdd()
        {
            //Arrange
            VehicleLogic testLogic = new VehicleLogic();
            Vehicle tmp1 = new Vehicle();
            tmp1.Id = -100;
            tmp1.Make = "Toyota";
            tmp1.Model = "Camry";
            tmp1.Year = 2016;

            //Act
            Vehicle result = testLogic.AddNewVehicle(tmp1);

            //Assert
            Assert.AreEqual(tmp1, result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(tmp1, testLogic.GetVehicleById(tmp1.Id));
        }

        [TestMethod]
        public void TestAdd_AddNull()
        {
            //Arrange
            VehicleLogic testLogic = new VehicleLogic();
            Vehicle tmp1 = null;

            //Act
            Vehicle result = testLogic.AddNewVehicle(tmp1);

            //Assert
            Assert.AreEqual(null, result);
            Assert.AreEqual(0, testLogic.GetVehicleList().Count);
        }

        [TestMethod]
        public void TestAdd_NullVehicleMake()
        {
            //Arrange
            VehicleLogic testLogic = new VehicleLogic();
            Vehicle tmp1 = new Vehicle();
            tmp1.Make = null;
            tmp1.Model = "Camry";
            tmp1.Year = 2016;

            //Act
            Vehicle result = testLogic.AddNewVehicle(tmp1);

            //Assert
            Assert.AreEqual(null, result);
            Assert.AreEqual(0, testLogic.GetVehicleList().Count);
        }

        [TestMethod]
        public void TestAdd_InvalidVehicleMake()
        {
            //Arrange
            VehicleLogic testLogic = new VehicleLogic();
            Vehicle tmp1 = new Vehicle();
            tmp1.Make = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";
            tmp1.Model = "Camry";
            tmp1.Year = 2016;

            //Act
            Vehicle result = testLogic.AddNewVehicle(tmp1);

            //Assert
            Assert.IsTrue(tmp1.Make.Length > 100);
            Assert.AreEqual(null, result);
            Assert.AreEqual(0, testLogic.GetVehicleList().Count);
        }

        [TestMethod]
        public void TestAdd_InvalidVehicleYear()
        {
            //Arrange
            VehicleLogic testLogic = new VehicleLogic();
            Vehicle tmp1 = new Vehicle();
            tmp1.Make = "Toyota";
            tmp1.Model = "Camry";
            tmp1.Year = 3030;

            //Act
            Vehicle result = testLogic.AddNewVehicle(tmp1);

            //Assert
            Assert.AreEqual(null, result);
            Assert.AreEqual(0, testLogic.GetVehicleList().Count);
        }

        [TestMethod]
        public void TestAdd_InvalidVehicleModel()
        {
            //Arrange
            VehicleLogic testLogic = new VehicleLogic();
            Vehicle tmp1 = new Vehicle();
            tmp1.Make = "Toyota";
            tmp1.Model = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";
            tmp1.Year = 2016;

            //Act
            Vehicle result = testLogic.AddNewVehicle(tmp1);

            //Assert
            Assert.IsTrue(tmp1.Model.Length > 100);
            Assert.AreEqual(null, result);
            Assert.AreEqual(0, testLogic.GetVehicleList().Count);
        }

        [TestMethod]
        public void TestAdd_NullVehicleModel()
        {
            //Arrange
            VehicleLogic testLogic = new VehicleLogic();
            Vehicle tmp1 = new Vehicle();
            tmp1.Make = "Toyota";
            tmp1.Model = null;
            tmp1.Year = 2016;

            //Act
            Vehicle result = testLogic.AddNewVehicle(tmp1);

            //Assert
            Assert.AreEqual(null, result);
            Assert.AreEqual(0, testLogic.GetVehicleList().Count);
        }

        [TestMethod]
        public void TestGetVehicleListBy() {
            //Arrange
            VehicleLogic testLogic = new VehicleLogic();
            Vehicle tmp1 = new Vehicle();
            tmp1.Make = "Toyota";
            tmp1.Model = "Corolla";
            tmp1.Year = 2016;
            Vehicle tmp2 = new Vehicle();
            tmp2.Make = "Subaru";
            tmp2.Model = "Outback";
            tmp2.Year = 2008;
            testLogic.AddNewVehicle(tmp1);
            testLogic.AddNewVehicle(tmp2);

            //Act
            List<Vehicle> results = testLogic.GetVehicleListBy("Toyota","", 0);

            //Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(tmp1, results[0]);
        }

        public void TestGetVehicleListBy_Year()
        {
            //Arrange
            VehicleLogic testLogic = new VehicleLogic();
            Vehicle tmp1 = new Vehicle();
            tmp1.Make = "Toyota";
            tmp1.Model = "Corolla";
            tmp1.Year = 2016;
            Vehicle tmp2 = new Vehicle();
            tmp2.Make = "Subaru";
            tmp2.Model = "Outback";
            tmp2.Year = 2008;
            testLogic.AddNewVehicle(tmp1);
            testLogic.AddNewVehicle(tmp2);

            //Act
            List<Vehicle> results = testLogic.GetVehicleListBy("", "", 2008);

            //Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(tmp2, results[0]);
        }

        [TestMethod]
        public void TestGetVehicleListBy_NullPredicate()
        {
            //Arrange
            VehicleLogic testLogic = new VehicleLogic();
            Vehicle tmp1 = new Vehicle();
            tmp1.Make = "Toyota";
            tmp1.Model = "Corolla";
            tmp1.Year = 2016;
            Vehicle tmp2 = new Vehicle();
            tmp2.Make = "Subaru";
            tmp2.Model = "Outback";
            tmp2.Year = 2008;
            testLogic.AddNewVehicle(tmp1);
            testLogic.AddNewVehicle(tmp2);

            //Act
            List<Vehicle> results = testLogic.GetVehicleListBy(null, null , 0);

            //Assert
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(tmp1, results[0]);
            Assert.AreEqual(tmp2, results[1]);
        }

        [TestMethod]
        public void TestGetVehicleListBy_PartialKeyword()
        {
            //Arrange
            VehicleLogic testLogic = new VehicleLogic();
            Vehicle tmp1 = new Vehicle();
            tmp1.Make = "Toyota";
            tmp1.Model = "Corolla";
            tmp1.Year = 2016;
            Vehicle tmp2 = new Vehicle();
            tmp2.Make = "Subaru";
            tmp2.Model = "Outback";
            tmp2.Year = 2008;
            testLogic.AddNewVehicle(tmp1);
            testLogic.AddNewVehicle(tmp2);

            //Act
            List<Vehicle> results = testLogic.GetVehicleListBy("", "U", 0);

            //Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(tmp2, results[0]);
        }

        [TestMethod]
        public void TestGetVehicleListBy_NoExistKeyword()
        {
            //Arrange
            VehicleLogic testLogic = new VehicleLogic();
            Vehicle tmp1 = new Vehicle();
            tmp1.Make = "Toyota";
            tmp1.Model = "Corolla";
            tmp1.Year = 2016;
            Vehicle tmp2 = new Vehicle();
            tmp2.Make = "Subaru";
            tmp2.Model = "Outback";
            tmp2.Year = 2008;
            testLogic.AddNewVehicle(tmp1);
            testLogic.AddNewVehicle(tmp2);

            //Act
            List<Vehicle> results = testLogic.GetVehicleListBy("", "X", 0);

            //Assert
            Assert.AreEqual(0, results.Count);
        }
    }
}
