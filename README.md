# Hotel Reservation Problem



### Introduction 

A hotel chain operating in Miami wishes to offer room reservation services over the internet. They have three hotels in Miami: Lakewood, Bridgewood and Ridgewood. Each hotel has separate weekday and weekend (Saturday and Sunday) rates. There are special rates for rewards customers as a part of loyalty program. Each hotel has a rating assigned to it.

- **Lakewood:** with a rating of `3` has weekday rates as `$110` for regular customer and `$80` for rewards customer. The weekend rates are $90 for regular customer and $80 for a rewards customer.
- **Bridgewood:** with a rating of `4` has weekday rates as `$160` for regular customer and `$110` for rewards customer. The weekend rates are `$60` for regular customer and `$50` for a rewards customer.
- **Ridgewood:** with a rating of `5` has weekday rates as `$220` for regular customer and `$100` for rewards customer. The weekend rates are `$150` for regular customer and `$40` for a rewards customer.

Write a program to help an online customer find the cheapest hotel.

The input to the program will be a range of dates for a regular or rewards customer. The output should be the cheapest available hotel. In case of a tie, the hotel with highest rating should be returned.



#### Notes

- There must be a way to supply the application with the input data via text file.
- The application must run.
- You should provide sufficient evidence that your solution is complete by, as a minimum, indicating that it works correctly against the supplied test data.



#### IO formats

**Input:** `<customer_type>: <date1>, <date2>, <date3>, ...`

**Output:** `<name_of_the_cheapest_hotel>`



#### Examples and test data

**Input 1:** `Regular: 16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)`

**Output 1:** `Lakewood`

------

**Input 2:** `Regular: 20Mar2009(fri), 21Mar2009(sat), 22Mar2009(sun)`

**Output 2:** `Bridgewood`

------

**Input 3:** `Rewards: 26Mar2009(thur), 27Mar2009(fri), 28Mar2009(sat)`

**Output 3:** `Ridgewood`





### Solution



#### Implementation

**Programming language:** C#

**Runtime environment:** .NET Core v2.1



#### Structure

Solution organized in three projects: `HotelService`, `HotelReservationCLI` and `Tests`. 

1. **`HotelService`:** Actual core logic of the solution.

   Contains the following classes: `Client`, `Rate`, `Hotel`, `HotelInvoice` and `HotelDirectory`. 

   **`Client` class:** It stores (only) the type of a customer (either `Regular` or `Rewards`).

   **`Rate` class:** It holds the corresponding rates for both `Regular` and `Rewards` customers. It is responsible for returning the correct rate according to a customer.

   **`Hotel` class:** It contains the name, rating, weekday rates and weekend rates related to a hotel. These last two members are instances of the `Rate` class. The current class computes the price for a reservation given a customer and a collection of dates, being aware of both the type of customer and whether the dates are weekdays or weekends. The result can be found inside an object of the `HotelInvoice` class.

   **`HotelInvoice` class:** It associates a customer with its reservation dates and hotel, as well as the computed price (returned by the `Hotel` class). 

   **`HotelDirectory` class:** It bunches up `Hotel` objects. The current class finds the cheapest hotel by requesting each hotel's reservation price and sorting them. If two or more hotels return the same price, the hotel with the highest rating has priority.

2. `HotelReservationCLI`: Console project that consumes `HotelService`.

3. `Tests`: NUnit test project for both `HotelService` and `HotelReservationCLI`.



#### Execution

The .NET Core environment is required. Instructions on how to set it up can be found in [https://dotnet.microsoft.com/download]( https://dotnet.microsoft.com/download).

Open a terminal window inside the `HotelReservationCLI` directory and type:

`dotnet run <Hotel_directory_file_path> <Reservation_data_file_path>`

where:

- `<Hotel_directory_file_path>` is the path of a file that contains the hotels' data. A sample of such file is `MiamiHotels.txt` (located inside the `HotelReservationCLI` directory).
- `<Reservation_data_file_path>` is the path of a file that contains the customer's reservation data. A sample of such file is `ReservationInput.txt` (located inside the `HotelReservationCLI` directory).

Therefore, the instruction to run the code with the provided files is:

`dotnet run MiamiHotels.txt ReservationInput.txt`

For every reservation registry found in the `<Reservation_data_file_path>` file, the program will output the corresponding cheapest hotel.

Details of each required file can be found inside the mentioned samples.

There are no restrictions about Operating Systems. The code runs wherever .NET Core does.

##### Results

**Input:**

```
Regular: 16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)
regular: 20Mar2009(fri), 21Mar2009(sat), 22Mar2009(sun)
Rewards: 26Mar2009(thur), 27Mar2009(fri), 28Mar2009(sat)
```

**Output:**

```
Lakewood
Bridgewood
Ridgewood
```

