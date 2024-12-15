using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024_Tests.Models
{
    public class Location
    {
        public int LocationID { get; set; }

        public string? LocationName { get; set; }

        public int Distance { get; set; }

        public Location(int locationID, string? locationName)
        {
            LocationID = locationID;
            LocationName = locationName;
        }

    }
}
