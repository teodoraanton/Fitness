using Microsoft.AspNetCore.Mvc;
using FitnessBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GymPricesController: ControllerBase
    {
        IGymPricesCollectionService _gymPricesCollectionService;

        public GymPricesController(IGymPricesCollectionService gymPricesCollectionService)
        {
            _gymPricesCollectionService = gymPricesCollectionService;
        }
    }
}
