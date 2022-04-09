using FitnessBackend.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Models
{
    public class Gym
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string GymImagePath { get; set; }
        public string Image
        {
            get
            {
                return ImageHelper.ConvertImageToBase64String(string.Join(string.Empty, this.GymImagePath));
            }
        }
        [Required]
        public Guid CityID { get; set; }
    }
}
