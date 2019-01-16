using System;
using HotelService.Exceptions;

namespace HotelService {

	public class Rate {

		public int Regular { get; }

		public int Rewards { get; }

		public Rate(int Regular, int Rewards) {
			this.Regular = Regular;
			this.Rewards = Rewards;
		}

		public int GetRateValueAccordingToClientType(Client Client) {
			if (Client == null) throw new ArgumentNullException(nameof(Client));
			return GetRateValueAccordingToClientType(Client.Type);
		}

		public int GetRateValueAccordingToClientType(ClientType ClientType) {
			int Rate = 0;
			switch (ClientType) {
				case ClientType.Regular:
					Rate = Regular;
					break;
				case ClientType.Rewards:
					Rate = Rewards;
					break;
				default:
					throw new RateForClientTypeNotSpecifiedException(ClientType);
			}
			return Rate;
		}

	}

}