using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Day4_Tasks
{
    public class TransportSchedule
    {
        public string? TransportType { get; set; } 
        public string? Route { get; set; } 
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public int SeatsAvailable { get; set; }
    }
    public class TransportManager
    {
        private List<TransportSchedule> schedules = new List<TransportSchedule>();

        // Add a schedule to the list
        public void AddSchedule(TransportSchedule schedule)
        {
            schedules.Add(schedule);
        }

        // Search by transport type, route, or departure time
        public IEnumerable<TransportSchedule> Search(string? transportType = null, string? route = null, DateTime? time = null)
        {
            var result = schedules.AsEnumerable();

            if (!string.IsNullOrEmpty(transportType))
                result = result.Where(s => string.Equals(s.TransportType, transportType, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(route))
                result = result.Where(s => string.Equals(s.Route, route, StringComparison.OrdinalIgnoreCase));

            if (time.HasValue)
                result = result.Where(s => s.DepartureTime.Date == time.Value.Date);

            return result;
        }

        // Group schedules by transport type
        public IEnumerable<IGrouping<string, TransportSchedule>> GroupByTransportType()
        {
            return schedules.GroupBy(s => s.TransportType ?? "Unknown");
        }


        // Order schedules by departure time, price, or seats available
        public IEnumerable<TransportSchedule> OrderBy(string orderBy = "DepartureTime")
        {
            return orderBy switch
            {
                "Price" => schedules.OrderBy(s => s.Price),
                "SeatsAvailable" => schedules.OrderBy(s => s.SeatsAvailable),
                _ => schedules.OrderBy(s => s.DepartureTime) // Default to DepartureTime
            };
        }

        // Filter schedules based on seat availability and route within a time range
        public IEnumerable<TransportSchedule> Filter(int minimumSeatsAvailable = 1, DateTime? startTime = null, DateTime? endTime = null)
        {
            var result = schedules.Where(s => s.SeatsAvailable >= minimumSeatsAvailable);

            if (startTime.HasValue)
                result = result.Where(s => s.DepartureTime >= startTime.Value);

            if (endTime.HasValue)
                result = result.Where(s => s.ArrivalTime <= endTime.Value);

            return result;
        }

        // Calculate the total number of available seats and the average price
        public (int totalSeats, decimal averagePrice) CalculateAggregateData()
        {
            int totalSeats = schedules.Sum(s => s.SeatsAvailable);
            decimal averagePrice = schedules.Average(s => s.Price);

            return (totalSeats, averagePrice);
        }

        // Project a list of routes and their departure times
        public IEnumerable<(string Route, DateTime DepartureTime)> GetRoutesWithDepartureTimes()
        {
            return schedules.Select(s => (s.Route ?? "Unknown Route", s.DepartureTime));
        }

    }
    public class Program
    {
        public static void Main()
        {
            TransportManager manager = new TransportManager();

            // Adding sample data
            manager.AddSchedule(new TransportSchedule { TransportType = "Bus", Route = "CityA to CityB", DepartureTime = DateTime.Now.AddHours(1), ArrivalTime = DateTime.Now.AddHours(3), Price = 25.50m, SeatsAvailable = 30 });
            manager.AddSchedule(new TransportSchedule { TransportType = "Flight", Route = "CityA to CityC", DepartureTime = DateTime.Now.AddHours(2), ArrivalTime = DateTime.Now.AddHours(5), Price = 150.75m, SeatsAvailable = 100 });
            manager.AddSchedule(new TransportSchedule { TransportType = "Bus", Route = "CityB to CityD", DepartureTime = DateTime.Now.AddHours(4), ArrivalTime = DateTime.Now.AddHours(6), Price = 20.00m, SeatsAvailable = 15 });
            manager.AddSchedule(new TransportSchedule { TransportType = "Flight", Route = "CityC to CityA", DepartureTime = DateTime.Now.AddHours(1), ArrivalTime = DateTime.Now.AddHours(4), Price = 200.00m, SeatsAvailable = 80 });
            manager.AddSchedule(new TransportSchedule { TransportType = "Bus", Route = "CityD to CityB", DepartureTime = DateTime.Now.AddHours(3), ArrivalTime = DateTime.Now.AddHours(5), Price = 30.00m, SeatsAvailable = 10 });

            //Search by Transport Type
            var busSchedules = manager.Search(transportType: "Bus");
            Console.WriteLine("Search - Bus Schedules:");
            foreach (var schedule in busSchedules)
                Console.WriteLine($"{schedule.Route} - {schedule.DepartureTime}");

            //Group by Transport Type
            var groupedSchedules = manager.GroupByTransportType();
            Console.WriteLine("\nGroup By - Transport Type:");
            foreach (var group in groupedSchedules)
            {
                Console.WriteLine($"\n{group.Key}:");
                foreach (var schedule in group)
                    Console.WriteLine($"{schedule.Route} - {schedule.DepartureTime}");
            }

            //Order By Price
            var orderedByPrice = manager.OrderBy("Price");
            Console.WriteLine("\nOrder By - Price:");
            foreach (var schedule in orderedByPrice)
                Console.WriteLine($"{schedule.Route} - ${schedule.Price}");

            //Filter by Seats and Time Range
            var filteredSchedules = manager.Filter(minimumSeatsAvailable: 20, startTime: DateTime.Now, endTime: DateTime.Now.AddHours(4));
            Console.WriteLine("\nFilter - Seats and Time Range:");
            foreach (var schedule in filteredSchedules)
                Console.WriteLine($"{schedule.Route} - Seats: {schedule.SeatsAvailable} - Departure: {schedule.DepartureTime}");

            //Aggregate - Total Seats and Average Price
            var (totalSeats, averagePrice) = manager.CalculateAggregateData();
            Console.WriteLine($"\nAggregate - Total Seats: {totalSeats}, Average Price: {averagePrice:C}");

            //Select - Routes and Departure Times
            var routeDepartureTimes = manager.GetRoutesWithDepartureTimes();
            Console.WriteLine("\nSelect - Routes and Departure Times:");
            foreach (var item in routeDepartureTimes)
                Console.WriteLine($"Route: {item.Route}, Departure: {item.DepartureTime}");
        }
    }

}
