using System;
using System.Collections.Generic;
using NUnit.Framework;

using HotelService;

namespace Tests.HotelService {

	public class HotelInvoiceTester {

		private Hotel BridgewoodHotel { get; set; }

		private List<DateTime> WeekdayDates { get; set; }

		private List<DateTime> WeekendDates { get; set; }

		private List<DateTime> MixedDates { get; set; }

		private Client RegularClient { get; set; }

		private Client RewardsClient { get; set; }

		private void LoadBridgewoodHotel() {
			string Name = "Bridgewood";
			int Rating = 4;
			Rate WeekdayRate = new Rate(160, 110);
			Rate WeekendRate = new Rate(60, 50);
			BridgewoodHotel = new Hotel(Name, Rating, WeekdayRate, WeekendRate);
		}

		private void LoadWeekdayDates() {
			WeekdayDates = new List<DateTime> {
				new DateTime(2009, 3, 16), // Monday
				new DateTime(2009, 3, 17), // Tuesday
				new DateTime(2009, 3, 18) // Wednesday
			};
		}

		private void LoadWeekendDates() {
			WeekendDates = new List<DateTime> {
				new DateTime(2009, 3, 21), // Saturday
				new DateTime(2009, 3, 22) // Sunday
			};
		}

		private void LoadMixedDates() {
			MixedDates = new List<DateTime> {
				new DateTime(2009, 3, 26), // Thursday
				new DateTime(2009, 3, 27), // Friday
				new DateTime(2009, 3, 28), // Saturday
				new DateTime(2009, 3, 29) // Sunday
			};
		}

		private void LoadRegularClient() {
			RegularClient = new Client(ClientType.Regular);
		}

		private void LoadRewardsClient() {
			RewardsClient = new Client(ClientType.Rewards);
		}

		[SetUp]
		public void SetUp() {
			LoadBridgewoodHotel();
			LoadWeekdayDates();
			LoadWeekendDates();
			LoadMixedDates();
			LoadRegularClient();
			LoadRewardsClient();
		}

		[Test]
		public void TestRegularClientWeekdayPrice() {
			HotelInvoice Invoice = BridgewoodHotel.GetInvoice(RegularClient, WeekdayDates);
			Assert.AreEqual(480, Invoice.Price);
		}

		[Test]
		public void TestRegularClientWeekendPrice() {
			HotelInvoice Invoice = BridgewoodHotel.GetInvoice(RegularClient, WeekendDates);
			Assert.AreEqual(120, Invoice.Price);
		}

		[Test]
		public void TestRegularClientMixedDatePrice() {
			HotelInvoice Invoice = BridgewoodHotel.GetInvoice(RegularClient, MixedDates);
			Assert.AreEqual(440, Invoice.Price);
		}

		[Test]
		public void TestRewardsClientWeekdayPrice() {
			HotelInvoice Invoice = BridgewoodHotel.GetInvoice(RewardsClient, WeekdayDates);
			Assert.AreEqual(330, Invoice.Price);
		}

		[Test]
		public void TestRewardsClientWeekendPrice() {
			HotelInvoice Invoice = BridgewoodHotel.GetInvoice(RewardsClient, WeekendDates);
			Assert.AreEqual(100, Invoice.Price);
		}

		[Test]
		public void TestRewardsClientMixedDatePrice() {
			HotelInvoice Invoice = BridgewoodHotel.GetInvoice(RewardsClient, MixedDates);
			Assert.AreEqual(320, Invoice.Price);
		}

	}

}
