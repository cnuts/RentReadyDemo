using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentReadyDemo
{
    public class AddressDetail
    {

        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public string GeoCode { get; set; }
        public string MSA { get; set; }

        public double Lattitude { get; set; }
        public double Longitude { get; set; }
    }
}
