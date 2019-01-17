using NUnit.Framework;

using HotelService;

namespace Tests.HotelService {

	public class RateTester {

		[Test]
		public void TestRateConstruction() {
			Rate Rate = new Rate(10, 20);
			Assert.IsTrue(Rate.Regular == 10 && Rate.Rewards == 20);
		}

		[Test]
		public void TestRateValueOfRegularClient() {
			Client Client = new Client(ClientType.Regular);
			Rate Rate = new Rate(10, 20);
			Assert.AreEqual(10, Rate.GetRateValueAccordingToClientType(Client));
		}

		[Test]
		public void TestRateValueOfRewardsClient() {
			Client Client = new Client(ClientType.Rewards);
			Rate Rate = new Rate(10, 20);
			Assert.AreEqual(20, Rate.GetRateValueAccordingToClientType(Client));
		}

	}

}