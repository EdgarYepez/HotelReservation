using System;
using System.Linq;
using System.Collections.Generic;

using HotelService;

namespace HotelReservation_CSharp {

	class Program {

		static void Main(string[] args) {
			string HotelDirectoryFile = @"D:\Projects\C#\HotelReservation_CSharp\HotelReservation_CSharp\MiamiHotels.txt";
			string InputFile = @"D:\Projects\C#\HotelReservation_CSharp\HotelReservation_CSharp\Input.txt";

			HotelDirectory Directory = HotelDirectory.Factory.CreateFromFile(HotelDirectoryFile);

			foreach (Input I in Input.Factory.CreateFromFile(InputFile)) {
				HotelInvoice CheapestInvoice = Directory.FindCheapestInvoice(I.Client, I.ReservationDates);
				Console.WriteLine($"{CheapestInvoice.Hotel.Name}");
			}
			Console.ReadKey();
		}

	}

}
