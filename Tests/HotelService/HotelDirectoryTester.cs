using System;
using System.Collections.Generic;
using NUnit.Framework;

using HotelService;

namespace Tests.HotelService {

	public class HotelDirectoryTester {

		private Hotel LakewoodHotel { get; set; }

		private Hotel BridgewoodHotel { get; set; }

		private Hotel RidgewoodHotel { get; set; }

		private Client RegularClient { get; set; }

		private Client RewardsClient { get; set; }

		private HotelDirectory Directory { get; set; }

		private void LoadLakewoodHotel() {
			string Name = "Lakewood";
			int Rating = 3;
			Rate WeekdayRate = new Rate(110, 80);
			Rate WeekendRate = new Rate(90, 80);
			LakewoodHotel = new Hotel(Name, Rating, WeekdayRate, WeekendRate);
		}

		private void LoadBridgewoodHotel() {
			string Name = "Bridgewood";
			int Rating = 4;
			Rate WeekdayRate = new Rate(160, 110);
			Rate WeekendRate = new Rate(60, 50);
			BridgewoodHotel = new Hotel(Name, Rating, WeekdayRate, WeekendRate);
		}

		private void LoadRidgewoodHotel() {
			string Name = "Ridgewood";
			int Rating = 5;
			Rate WeekdayRate = new Rate(220, 100);
			Rate WeekendRate = new Rate(150, 40);
			RidgewoodHotel = new Hotel(Name, Rating, WeekdayRate, WeekendRate);
		}

		private void LoadRegularClient() {
			RegularClient = new Client(ClientType.Regular);
		}

		private void LoadRewardsClient() {
			RewardsClient = new Client(ClientType.Rewards);
		}

		private void LoadDirectory() {
			Directory = new HotelDirectory(new List<Hotel> {
				LakewoodHotel,
				BridgewoodHotel,
				RidgewoodHotel
			});
		}

		[SetUp]
		public void SetUp() {
			LoadLakewoodHotel();
			LoadBridgewoodHotel();
			LoadRidgewoodHotel();
			LoadRegularClient();
			LoadRewardsClient();
			LoadDirectory();
		}

		[Test]
		public void TestDirectoryCreation() {
			Assert.IsTrue(
				Directory.ContainsHotel(LakewoodHotel.Name) &&
				Directory.ContainsHotel(BridgewoodHotel.Name) &&
				Directory.ContainsHotel(RidgewoodHotel.Name)
			);
		}

		[Test]
		public void TestCheapestInvoice1() {
			List<DateTime> ReservationDates = new List<DateTime> {
				new DateTime(2009, 3, 16), // Monday
				new DateTime(2009, 3, 17), // Tuesday
				new DateTime(2009, 3, 18) // Wednesday
			};
			HotelInvoice Invoice = Directory.FindCheapestInvoice(RegularClient, ReservationDates);
			Assert.AreEqual(LakewoodHotel.Name, Invoice.Hotel.Name);
		}

		[Test]
		public void TestCheapestInvoice2() {
			List<DateTime> ReservationDates = new List<DateTime> {
				new DateTime(2009, 3, 20), // Friday
				new DateTime(2009, 3, 21), // Saturday
				new DateTime(2009, 3, 22) // Sunday
			};
			HotelInvoice Invoice = Directory.FindCheapestInvoice(RegularClient, ReservationDates);
			Assert.AreEqual(BridgewoodHotel.Name, Invoice.Hotel.Name);
		}

		[Test]
		public void TestCheapestInvoice3() {
			List<DateTime> ReservationDates = new List<DateTime> {
				new DateTime(2009, 3, 26), // Thursday
				new DateTime(2009, 3, 27), // Friday
				new DateTime(2009, 3, 28) // Saturday
			};
			HotelInvoice Invoice = Directory.FindCheapestInvoice(RewardsClient, ReservationDates);
			Assert.AreEqual(RidgewoodHotel.Name, Invoice.Hotel.Name);
		}

	}

}