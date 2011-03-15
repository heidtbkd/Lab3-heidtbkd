using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime startDate = new DateTime(2011, 3, 1);
        private readonly DateTime endDate = new DateTime(2011, 3, 15);
        private readonly int milesOfFlight = 100;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(startDate, endDate, milesOfFlight);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePrice()
        {
            var target = new Flight(startDate, startDate, milesOfFlight);
            Assert.AreEqual(200, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDay()
        {
            var target = new Flight(startDate, new DateTime(2011, 3, 2), 100);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDay()
        {
            var target = new Flight(startDate, new DateTime(2011, 3, 11), 100);
            Assert.AreEqual((200+(20*10)), target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnEndBeforeStart()
        {
            new Flight(endDate, startDate, 100);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(startDate, startDate, -1);
        }

        [Test()]
        public void TestFlightEqualOnTrue()
        {
            var target = new Flight(startDate, new DateTime(2011, 3, 11), 100);
            Assert.True(target.Equals(new Flight(startDate, new DateTime(2011, 3, 11), 100)));
        }

        [Test()]
        public void TestFlightEqualOnFalse()
        {
            var target = new Flight(startDate, new DateTime(2011, 3, 11), 100);
            Assert.False(target.Equals(new Flight(startDate, startDate, 10)));
        }

	}
}