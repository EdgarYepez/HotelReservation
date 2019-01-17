using System;
using HotelService;

namespace HotelReservationCLI {

	class Program {

		static void Main(string[] args) {
			if (args.Length != 2) {
				Console.WriteLine("Expected arguments: <Hotel_directory_file_path> <Reservation_data_file_path>");
			}
			else {
				string HotelDirectoryFile = args[0] ?? throw new ArgumentNullException(nameof(HotelDirectoryFile));
				string ReservationDataFile = args[1] ?? throw new ArgumentNullException(nameof(ReservationDataFile));

				HotelDirectory Directory = HotelDirectory.Factory.CreateFromFile(HotelDirectoryFile);

				foreach (Input I in Input.Factory.CreateFromFile(ReservationDataFile)) {
					HotelInvoice CheapestInvoice = Directory.FindCheapestInvoice(I.Client, I.ReservationDates);
					Console.WriteLine($"{CheapestInvoice.Hotel.Name}");
				}
			}

			Console.ReadKey();
		}

	}

}