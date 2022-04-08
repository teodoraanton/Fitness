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
    public class GymTrainingsController: ControllerBase
    {
        IGymTrainingsCollectionService _gymTrainingsCollectionService;

        public GymTrainingsController(IGymTrainingsCollectionService gymTrainingsCollectionService)
        {
            _gymTrainingsCollectionService = gymTrainingsCollectionService;
        }
    }
}
