using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Models
{
    public class GymDescription
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<string> interiorImagesPath { get; set; }
        [Required]
        public Guid GymID { get; set; }
    }
}
