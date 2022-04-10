using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Models
{
    public class GymPrices
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string SubscriptionType { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public Guid GymID { get; set; }
    }
}
