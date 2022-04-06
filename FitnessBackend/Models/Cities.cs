using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Models
{
    public class Cities
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public String Name { get; set; }
    }
}
