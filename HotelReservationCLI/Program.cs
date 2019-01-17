using System;
using HotelService;

namespace HotelReservationCLI {

	class Program {

		static void Main(string[] args) {
			string HotelDirectoryFile = @"D:\Projects\C#\HotelReservation_CSharp\HotelReservationCLI\MiamiHotels.txt";
			string InputFile = @"D:\Projects\C#\HotelReservation_CSharp\HotelReservationCLI\Input.txt";

			HotelDirectory Directory = HotelDirectory.Factory.CreateFromFile(HotelDirectoryFile);

			foreach (Input I in Input.Factory.CreateFromFile(InputFile)) {
				HotelInvoice CheapestInvoice = Directory.FindCheapestInvoice(I.Client, I.ReservationDates);
				Console.WriteLine($"{CheapestInvoice.Hotel.Name}");
			}
			Console.ReadKey();
		}

	}

}