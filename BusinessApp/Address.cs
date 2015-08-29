using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary
{
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
    
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string State { get; set; }
    }
}
