using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            string databaseTimeZoneId = "India Standard Time"; // from database
            var databaseTime = DateTime.Now; // from database


            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(databaseTimeZoneId);
            DateTime current = DateTime.SpecifyKind(databaseTime, DateTimeKind.Unspecified);
            Console.WriteLine("Current time in IST: " + current);

            DateTime sourceUtcTime = TimeZoneInfo.ConvertTimeToUtc(current, timeZoneInfo);
            Console.WriteLine("Current IST time in UTC: " + sourceUtcTime);

            string destinationTimeZoneId = "Eastern Standard Time"; // you generally read user locals or ask them to configure they timezone of choice
            TimeZoneInfo destinationTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(destinationTimeZoneId);
            DateTime detinationTime = TimeZoneInfo.ConvertTimeFromUtc(sourceUtcTime, destinationTimeZoneInfo);
            Console.WriteLine("Current time in EST: " + detinationTime);

            DateTime destinationUtcTime = TimeZoneInfo.ConvertTimeToUtc(detinationTime, destinationTimeZoneInfo);
            Console.WriteLine("Current EST time in UTC: " + destinationUtcTime);


            // Get timezone list, always store Id in database
            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
            {
                Console.WriteLine(z.DisplayName + " i.e. " + z.Id + "(" + z.BaseUtcOffset + ")");
            }

            Console.ReadKey();
        }
    }
}