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
    public class GymTrainersController: ControllerBase
    {
        IGymTrainersCollectionService _gymTrainersCollectionService;

        public GymTrainersController(IGymTrainersCollectionService gymTrainersCollectionService)
        {
            _gymTrainersCollectionService = gymTrainersCollectionService;
        }
    }
}
