using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestMeasurementService.Controllers;
using RestMeasurementService.Model;

namespace MeasurementServiceTest
{
    [TestClass]
    public class MeasControllerTest
    {
        private MeasurementsController controller;
        private Measurement getItem;

        [TestInitialize]
        public void TestSetup()
        {
            string date = "2020-01-14T15:40:00";
            controller = new MeasurementsController();
            getItem = new Measurement(2, 105.5, 49.8, 11, DateTime.Parse(date));
        }

        [TestMethod]
        public void GetAllTest()
        {
            int numberOfMeasurements = controller.GetAll().Count();
            int expected = 4;

            Assert.AreEqual(expected, numberOfMeasurements);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            Measurement measurement = controller.GetById(2);
            Measurement expectedMeasurement = getItem;

            Assert.AreEqual(expectedMeasurement, measurement);
        }

        [TestMethod]
        public void AddTest()
        {
            Measurement addMeasurement = new Measurement(5, 55.5, 66.6, 77.7, new DateTime(2020, 01, 14, 10, 10, 10));

            controller.Add(addMeasurement);

            Measurement actualMeasurement = controller.GetById(5);

            Assert.AreEqual(addMeasurement, actualMeasurement);
        }

        [TestMethod]
        public void DeleteTest()
        {
            controller.Delete(5);

            Assert.IsNull(controller.GetById(5));
        }
    }
}
