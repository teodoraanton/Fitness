using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Models
{
    public class GymSchedule
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Day { get; set; }
        [Required]
        public string Hour { get; set; }
        [Required]
        public string Training { get; set; }
        [Required]
        public string Trainer { get; set; }
        [Required]
        public Guid GymID { get; set; }
    }
}
