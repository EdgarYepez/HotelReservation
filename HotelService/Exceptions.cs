using System;
using System.Text;
using System.Collections.Generic;

namespace HotelService.Exceptions {

	public abstract class HotelReservationException : Exception {

		public HotelReservationException(string Message) :
			base(Message) { }

	}

	public class HotelStringNotWellFormedException : HotelReservationException {

		public HotelStringNotWellFormedException() :
			base("The provided Hotel string is not well formed.") { }

		public HotelStringNotWellFormedException(string HotelString) :
			base($"The provided Hotel string is not well formed: '{HotelString}'") { }

	}

	public class ClientStringNotWellFormedException : HotelReservationException {

		public ClientStringNotWellFormedException() :
			base("The provided Client string is not well formed.") { }

		public ClientStringNotWellFormedException(string ClientString) :
			base($"The provided Client string is not well formed: '{ClientString}'") { }

	}

	public class RateForClientTypeNotSpecifiedException : HotelReservationException {

		public RateForClientTypeNotSpecifiedException(ClientType ClientType):
			base($"A rate for '{ClientType.ToString()}' client has not been specified.") { }

	}

	public class HotelKeyAlreadyAddedException : HotelReservationException {

		public HotelKeyAlreadyAddedException(string HotelName) :
			base($"There is already a Hotel named '{HotelName}' in the collection.") { }

	}

}