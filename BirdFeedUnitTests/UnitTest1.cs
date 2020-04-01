using System;
using BirdFeed.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BirdFeedTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //
            // Arrange
            //
            ObservationViewModel observationViewModel = new ObservationViewModel();

            //
            // Act
            //
            observationViewModel.GetLatestObservations();

            //
            // Assert
            //
            Assert.IsTrue(observationViewModel.TheObservations.Count > 0);
        }
    }
}
