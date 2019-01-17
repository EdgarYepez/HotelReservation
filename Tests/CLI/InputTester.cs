using System;
using NUnit.Framework;

using HotelService;
using HotelReservationCLI;

namespace Tests.CLI {

	public class InputTester {

		[Test]
		public void TestInputLoadFromString() {
			string InputString = "Regular: 16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)";
			Input Input = Input.Factory.CreateFromString(InputString);
			Assert.IsTrue(
				Input.Client.Type == ClientType.Regular &&
				Input.ReservationDates.Count == 3 &&
				Input.ReservationDates[0].Equals(new DateTime(2009, 3, 16)) &&
				Input.ReservationDates[1].Equals(new DateTime(2009, 3, 17)) &&
				Input.ReservationDates[2].Equals(new DateTime(2009, 3, 18))
			);
		}

	}

}