using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using HotelService;

namespace HotelReservation_CSharp {

	public class Input {

		public Client Client { get; }

		public List<DateTime> ReservationDates { get; }

		public Input(Client Client, ICollection<DateTime> ReservationDates) {
			this.Client = Client ?? throw new ArgumentNullException(nameof(Client));
			this.ReservationDates = ReservationDates.ToList() ?? throw new ArgumentNullException(nameof(ReservationDates));
		}

		public sealed class Factory {

			public static IEnumerable<Input> CreateFromFile(string FilePath) {
				if (FilePath == null) throw new ArgumentNullException(FilePath);
				Regex EmptyLineCollector = new Regex(@"^(?:\s*$|\s*#)"); // Regex for selecting empty lines and lines that begin with a # symbol.
				StreamReader Stream = new StreamReader(FilePath, Encoding.UTF8);

				string FileLine;
				while ((FileLine = Stream.ReadLine()) != null) {
					if (!EmptyLineCollector.IsMatch(FileLine)) { // Skip lines that either are empty or begin with a # symbol.
						yield return CreateFromString(FileLine);
					}
				}

				Stream.Close();
			}

			public static Input CreateFromString(string InputString) {
				if (InputString == null) throw new ArgumentNullException(nameof(InputString));
				Regex RegistryGrabber = new Regex(@"^\s*([^:]+):\s*(.+)");

				Match InputRegistry = RegistryGrabber.Match(InputString);
				if (!InputRegistry.Success) throw new Exception($"The provided Input string is not well formed: '{InputString}'");

				string ClientString = InputRegistry.Groups[1].Value;
				string DateString = InputRegistry.Groups[2].Value;

				Client Client = Client.Factory.CreateFromString(ClientString);
				List<DateTime> ReservationDates = BuildDateTimeFromString(DateString);

				return new Input(Client, ReservationDates);
			}

			private static List<DateTime> BuildDateTimeFromString(string DateStrings) {
				List<DateTime> DateList = new List<DateTime>();
				CultureInfo Provider = CultureInfo.InvariantCulture;
				foreach (string DateString in DateStrings.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
					string CurrentDateString = DateString.Trim();
					CurrentDateString = Regex.Replace(CurrentDateString, @"(\(.{3}).*?(\))", "$1$2"); // Standardize weekday name to only three characters.
					DateTime Date = DateTime.ParseExact(CurrentDateString, "ddMMMyyyy(ddd)", Provider);
					DateList.Add(Date);
				}
				return DateList;
			}

		}

	}

}