using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Models
{
    public class GymTrainers
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public List<string> trainings { get; set; }
        [Required]
        public Guid GymID { get; set; }
    }
}
