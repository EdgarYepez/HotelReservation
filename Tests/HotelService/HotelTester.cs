using NUnit.Framework;

using HotelService;
using System;
using System.Collections.Generic;

namespace Tests.HotelService {

	public class HotelTester {

		[Test]
		public void TestHotelConstruction() {
			string Name = "Bridgewood";
			int Rating = 4;
			Rate WeekdayRate = new Rate(160, 110);
			Rate WeekendRate = new Rate(60, 50);

			Hotel Hotel = new Hotel(Name, Rating, WeekdayRate, WeekendRate);

			Assert.IsTrue(
				Hotel.Name.Equals(Name) && 
				Hotel.Rating == Rating &&
				Hotel.WeekdayRate.Equals(WeekdayRate) &&
				Hotel.WeekendRate.Equals(WeekendRate)
			);			
		}

		//[Test]
		//public void ComputePriceShouldReturnWeekdayRateOnMonday() {
		//	Client client = new Client(ClientType.Regular);
		//	Hotel hotel = new Hotel("Quito", 5, new Rate(10, 20), new Rate(30, 40));
		//	DateTime reservationDate = new DateTime(2019, 2, 11);
		//	List<DateTime> reservationDates = new List<DateTime>();
		//	reservationDates.Add(reservationDate);

		//	int price = hotel.ComputePrice(client, reservationDates);

		//	Assert.AreEqual(10, price);
		//}

		//[Test]
		//public void ComputePriceShouldReturnRewardsRateOnSaturday() {
		//	Client client = new Client(ClientType.Rewards);
		//	Hotel hotel = new Hotel("Quito", 5, new Rate(10, 20), new Rate(30, 40));
		//	DateTime reservationDate = new DateTime(2019, 2, 9);
		//	List<DateTime> reservationDates = new List<DateTime>();
		//	reservationDates.Add(reservationDate);

		//	int price = hotel.ComputePrice(client, reservationDates);

		//	Assert.AreEqual(40, price);
		//}

		//[Test]
		//public void ComputePriceShouldReturnRegularRateOnSunday() {
		//	Client client = new Client(ClientType.Regular);
		//	Hotel hotel = new Hotel("Quito", 5, new Rate(10, 20), new Rate(30, 40));
		//	DateTime reservationDate = new DateTime(2019, 2, 10);
		//	List<DateTime> reservationDates = new List<DateTime>();
		//	reservationDates.Add(reservationDate);

		//	int price = hotel.ComputePrice(client, reservationDates);

		//	Assert.AreEqual(30, price);
		//}

	}

}