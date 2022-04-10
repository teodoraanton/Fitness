using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Models
{
    public class GymOpenHours
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Day { get; set; }
        [Required]
        public string HoursInterval { get; set; }
        [Required]
        public Guid GymID { get; set; }
    }
}
