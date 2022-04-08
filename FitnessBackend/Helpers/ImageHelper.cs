using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Helpers
{
    public static class ImageHelper
    {
        public static string ConvertImageToBase64String(string imagePath)
        {
            string fullPath = Path.Combine("Images/", imagePath);
            byte[] imageBytes = File.ReadAllBytes(fullPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}
