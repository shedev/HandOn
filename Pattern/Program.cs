namespace Pattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {   
        static void Main(string[] args)
        {
            //Declaration pattern          
            object firstMessage = "Hello amazing people";
            if (firstMessage is string message)
            {
                Console.WriteLine($"Declaration pattern - first message is checked in if block and assigned to message with value as - {message}");
            }

            //Type pattern
            var numbers = new int[] { 10, 20, 30 };
            var letters = new List<char> { 'a', 'b', 'c', 'd' };
            Console.WriteLine($"Type pattern - {GetSourceLabel(numbers)}");
            Console.WriteLine($"Type pattern - {GetSourceLabel(letters)}");
            static string GetSourceLabel<T>(IEnumerable<T> source) => source switch
            {
                Array array => "Given type is array",
                ICollection<T> collection => "Given type is list",
                _ => "neither collection or arry "

            };

            //Constant pattern
            Console.WriteLine($"Constant pattern - {GetGroupTicketPrice(1)}");

            static decimal GetGroupTicketPrice(int visitorCount) => visitorCount switch
            {
                1 => 12.0m,
                2 => 20.0m,
                3 => 27.0m,
                4 => 32.0m,
                0 => 0.0m,
                _ => throw new ArgumentException($"Not supported number of visitors: {visitorCount}", nameof(visitorCount)),
            };

            //Relational pattern
            Console.WriteLine($"Relational pattern - {Classify(1)}");

            static string Classify(double measurement) => measurement switch
            {
                < -4.0 => "Too low",
                > 10.0 => "Too high",
                double.NaN => "Unknown",
                _ => "Acceptable",
            };

            //Logical  pattern
            Console.WriteLine($"Logical pattern - {Logical(1)}");        

            static string Logical(double measurement) => measurement switch
            {
                < -40.0 => "Too low",
                >= -40.0 and < 0 => "Low",
                >= 0 and < 10.0 => "Acceptable",
                >= 10.0 and < 20.0 => "High",
                >= 20.0 => "Too high",
                double.NaN => "Unknown",
            };

            //Property  pattern
            Console.WriteLine($"Property  pattern - {IsConferenceDay(DateTime.Now)}");
            static bool IsConferenceDay(DateTime date) => date is { Year: 2020, Month: 5, Day: 19 or 20 or 21 };

            //Positional  pattern
            Console.WriteLine($"Positional  pattern - {GetGroupTicketPriceDiscount(6, DateTime.Now)}");
            static decimal GetGroupTicketPriceDiscount(int groupSize, DateTime visitDate)
        => (groupSize, visitDate.DayOfWeek) switch
        {
            ( <= 0, _) => throw new ArgumentException("Group size must be positive."),
            (_, DayOfWeek.Saturday or DayOfWeek.Sunday) => 0.0m,
            ( >= 5 and < 10, DayOfWeek.Monday) => 20.0m,
            ( >= 10, DayOfWeek.Monday) => 30.0m,
            ( >= 5 and < 10, _) => 12.0m,
            ( >= 10, _) => 15.0m,
            _ => 0.0m,
        };


            //var  pattern
            Console.WriteLine($"var  pattern - {IsAcceptable(6, 4)}");
            static bool IsAcceptable(int id, int absLimit) =>
    SimulateDataFetch(id) is var results
    && results.Min() >= -absLimit
    && results.Max() <= absLimit;

            static int[] SimulateDataFetch(int id)
            {
                var rand = new Random();
                return Enumerable
                           .Range(start: 0, count: 5)
                           .Select(s => rand.Next(minValue: -10, maxValue: 11))
                           .ToArray();
            }



            //Discard   pattern
            Console.WriteLine($"Discard   pattern - {GetDiscountInPercent(DayOfWeek.Friday)}");
            static decimal GetDiscountInPercent(DayOfWeek? dayOfWeek) => dayOfWeek switch
            {
                DayOfWeek.Monday => 0.5m,
                DayOfWeek.Tuesday => 12.5m,
                DayOfWeek.Wednesday => 7.5m,
                DayOfWeek.Thursday => 12.5m,
                DayOfWeek.Friday => 5.0m,
                DayOfWeek.Saturday => 2.5m,
                DayOfWeek.Sunday => 2.0m,
                _ => 0.0m,
            };

        }

    }
}
