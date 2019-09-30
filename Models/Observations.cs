using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdFeed.Models
{
    /// <summary>
    /// This class ecapsulates the observation data
    /// </summary>
    public class Observations
    {
        public string speciesCode { get; set; }
        public string comName { get; set; }
        public string sciName { get; set; }
        public string locId { get; set; }
        public string locName { get; set; }
        public string obsDt { get; set; }
        public int howMany { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public bool obsValid { get; set; }
        public bool obsReviewed { get; set; }
        public bool locationPrivate { get; set; }
    }
}