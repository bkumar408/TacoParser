using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);
            var parser = new TacoParser();
            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            //var parser = new TacoParser(); ---- no need this line 

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            ITrackable location1 = null;
            ITrackable location2 = null;
            // Create a `double` variable to store the distance
            Double distance = 0;
            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            for (int i = 0; i < locations.Length; i++)
            {
                ITrackable locA = locations[i];

                // Create a new corA Coordinate with your locA's lat and long
                GeoCoordinate corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
                for (int j = 0; j < locations.Length; j++)
                {
                    ITrackable locB = locations[j];

                    // Create a new Coordinate with your locB's lat and long
                    GeoCoordinate destination = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                    // Now, compare the two using `.GetDistanceTo()`, which returns a double
                    double length = corA.GetDistanceTo(destination);
                    // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
                    if (length > distance)
                    {
                        distance = length;
                        location1 = locA;
                        location2 = locB;
                    }
                }
            }
            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            Console.WriteLine(location1.Name);
            Console.WriteLine(location2.Name);
            Console.WriteLine(distance * .000621371192); // converting to mile 
        }
    }
}
