namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            if (line == null)
            {
                return null;
            }
            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            string[] cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                return null;
            }

            // grab the latitude from your array at index 0
            double latitude = double.Parse(cells[0]);
            // grab the longitude from your array at index 1
            double longitude = double.Parse(cells[1]);
            // grab the name from your array at index 2
            string name = cells[2];

            // You'll need to create a TacoBell class // new TacoBell.cs created 
            // that conforms to ITrackable


            // Then, you'll need an instance of the TacoBell class
            {
                var point = new Point();
                point.Latitude = latitude;
                point.Longitude = longitude;

                var tacoBell = new TacoBell();

                tacoBell.Name = name;
                tacoBell.Location = point;
                //  tacoBell.Location = new Point (latitude, longitude); 
                //Point p = new Point();
                //p.Longitude = longitude;
                //p.Latitude = latitude;
                // With the name and point set correctly


                // Then, return the instance of your TacoBell class
                // Since it conforms to ITrackable
                return tacoBell;
            }



        }
    }

}