﻿using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace HotelService {

	public class HotelInvoice {

		public Hotel Hotel { get; }

		public Client Client { get; }

		public List<DateTime> ReservationDates { get; }

		private Lazy<int> _Price { get; set; }

		public int Price {
			get {
				return _Price.Value;
			}
		} 

		internal HotelInvoice(Hotel Hotel, Client Client, ICollection<DateTime> ReservationDates) {
			this.Hotel = Hotel ?? throw new ArgumentNullException(nameof(Hotel));
			this.Client = Client ?? throw new ArgumentNullException(nameof(Client));
			this.ReservationDates = ReservationDates.ToList() ?? throw new ArgumentNullException(nameof(ReservationDates));
			RefreshPrice();
		}

		public void RefreshPrice() {
			_Price = new Lazy<int>(() => Hotel.ComputePrice(Client, ReservationDates));
		}

	}

}