using NUnit.Framework;

using HotelService;

namespace Tests.HotelService {

	public class ClientTester {

		[Test]
		public void TestRegularClientConstruction() {
			Client Client = Client.Factory.CreateFromString("regular");
			Assert.IsTrue(Client.Type == ClientType.Regular);
		}

		[Test]
		public void TestRewardsClientConstruction() {
			Client Client = Client.Factory.CreateFromString("rewards");
			Assert.IsTrue(Client.Type == ClientType.Rewards);
		}

	}

}