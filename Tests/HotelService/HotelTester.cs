using NUnit.Framework;

using HotelService;

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

	}

}