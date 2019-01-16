using System;
using System.Text;
using System.Collections.Generic;
using HotelService.Exceptions;

namespace HotelService {

	public enum ClientType {
		Regular,
		Rewards
	}

	public class Client {

		public ClientType Type { get; set; }

		public Client(ClientType Type) {
			this.Type = Type;
		}

		public sealed class Factory {

			public static Client CreateFromString(string ClientString) {
				ClientType Type;
				ClientString = ClientString.ToLower().Trim();
				switch (ClientString) {
					case "regular":
						Type = ClientType.Regular;
						break;
					case "rewards":
						Type = ClientType.Rewards;
						break;
					default:
						throw new ClientStringNotWellFormedException(ClientString);
				}
				return new Client(Type);
			}

		}

	}

}