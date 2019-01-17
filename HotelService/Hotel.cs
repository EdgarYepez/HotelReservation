using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HotelService.Exceptions;

namespace HotelService {

	public class Hotel {

		public string Name { get; }

		public int Rating { get; }

		public Rate WeekdayRate { get; }

		public Rate WeekendRate { get; }

		public Hotel(string Name, int Rating, Rate WeekdayRate, Rate WeekendRate) {
			this.Name = Name ?? throw new ArgumentNullException(nameof(Name));
			this.Rating = Rating;
			this.WeekdayRate = WeekdayRate ?? throw new ArgumentNullException(nameof(WeekdayRate));
			this.WeekendRate = WeekendRate ?? throw new ArgumentNullException(nameof(WeekendRate));
		}

		public HotelInvoice GetInvoice(Client Client, ICollection<DateTime> ReservationDates) {
			return new HotelInvoice(this, Client, ReservationDates);
		}

		internal int ComputePrice(Client Client, ICollection<DateTime> ReservationDates) {
			if (Client == null) throw new ArgumentNullException(nameof(Client));
			if (ReservationDates == null) throw new ArgumentNullException(nameof(ReservationDates));

			int Price = 0;
			foreach (DateTime ReservationDate in ReservationDates) {
				switch (ReservationDate.DayOfWeek) {
					case DayOfWeek.Saturday:
					case DayOfWeek.Sunday:
						Price += WeekendRate.GetRateValueAccordingToClientType(Client);
						break;
					default:
						Price += WeekdayRate.GetRateValueAccordingToClientType(Client);
						break;
				}
			}
			return Price;
		}

		public override string ToString() {
			return $"{Name}, {Rating}, {WeekdayRate.ToString()}, {WeekendRate.ToString()}";
		}

		public sealed class Factory {

			public static Hotel CreateFromString(string HotelString) {
				Regex DataCollector = new Regex(@"^\s*([^,]+),\s*(\d+)\s*,\s*(\d+)\s*,\s*(\d+)\s*,\s*(\d+)\s*,\s*(\d+)\s*$");
				Match HotelData = DataCollector.Match(HotelString);
				if (!HotelData.Success) throw new HotelStringNotWellFormedException(HotelString);

				string HotelName = HotelData.Groups[1].Value;
				int Rating = Convert.ToInt32(HotelData.Groups[2].Value);
				int WeekdayRegularRate = Convert.ToInt32(HotelData.Groups[3].Value);
				int WeekdayRewardsRate = Convert.ToInt32(HotelData.Groups[4].Value);
				int WeekendRegularRate = Convert.ToInt32(HotelData.Groups[5].Value);
				int WeekendRewardsRate = Convert.ToInt32(HotelData.Groups[6].Value);

				Rate WeekdayRate = new Rate(WeekdayRegularRate, WeekdayRewardsRate);
				Rate WeekendRate = new Rate(WeekendRegularRate, WeekendRewardsRate);

				return new Hotel(HotelName, Rating, WeekdayRate, WeekendRate);
			}

		}

	}

}