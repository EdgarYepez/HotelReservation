using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using HotelService.Exceptions;

namespace HotelService {

	public class HotelDirectory {

		private Dictionary<string, Hotel> HotelDictionary { get; }

		public HotelDirectory() : this(new List<Hotel>()) { }

		public HotelDirectory(ICollection<Hotel> Hotels) {
			if (Hotels == null) throw new ArgumentNullException(nameof(Hotels));
			HotelDictionary = new Dictionary<string, Hotel>(
				from H in Hotels
				select new KeyValuePair<string, Hotel>(H.Name, H)
			);
		}

		public void AddHotel(Hotel Hotel) {
			if (Hotel == null) throw new ArgumentNullException(nameof(Hotel));
			if (HotelDictionary.ContainsKey(Hotel.Name)) throw new HotelKeyAlreadyAddedException(Hotel.Name);
			HotelDictionary[Hotel.Name] = Hotel;
		}

		public void RemoveHotel(string HotelName) {
			if (HotelName == null) throw new ArgumentNullException(nameof(HotelName));
			if (HotelDictionary.ContainsKey(HotelName)) HotelDictionary.Remove(HotelName);
		}

		public Hotel GetHotel(string HotelName) {
			if (HotelName == null) throw new ArgumentNullException(nameof(HotelName));
			return HotelDictionary.ContainsKey(HotelName) ? HotelDictionary[HotelName] : null;
		}

		public IEnumerable<HotelInvoice> GetAllInvoices(Client Client, ICollection<DateTime> ReservationDates) {
			foreach (Hotel Hotel in HotelDictionary.Values) {
				yield return Hotel.GetInvoice(Client, ReservationDates);
			}
		}

		public HotelInvoice FindCheapestInvoice(Client Client, ICollection<DateTime> ReservationDates) {
			List<HotelInvoice> InvoiceList = GetAllInvoices(Client, ReservationDates).ToList();
			return FindCheapestInvoice(InvoiceList);
		}

		public static HotelInvoice FindCheapestInvoice(ICollection<HotelInvoice> InvoiceList) {
			return InvoiceList.OrderBy(I => I.Price).ThenByDescending(I => I.Hotel.Rating).First();
		}

		public sealed class Factory {

			public static HotelDirectory CreateFromFile(string FilePath) {
				if (FilePath == null) throw new ArgumentNullException(FilePath);
				Regex EmptyLineCollector = new Regex(@"^(?:\s*$|\s*#)"); // Regex for selecting empty lines and lines that begin with a # symbol.
				StreamReader Stream = new StreamReader(FilePath, Encoding.UTF8);

				HotelDirectory Directory = new HotelDirectory();
				string FileLine;
				while ((FileLine = Stream.ReadLine()) != null) {
					if (!EmptyLineCollector.IsMatch(FileLine)) { // Skip lines that either are empty or begin with a # symbol.
						Directory.AddHotel(Hotel.Factory.CreateFromString(FileLine));
					}
				}

				Stream.Close();
				return Directory;
			}

		}

	}

}