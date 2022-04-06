using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Models
{
    public class Gyms
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String CityName { get; set; }
        //public Guid IDCity { get; set; }
        //image
    }
}
