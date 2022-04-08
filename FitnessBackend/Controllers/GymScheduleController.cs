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
    public class GymScheduleController: ControllerBase
    {
        IGymScheduleCollectionService _gymScheduleCollectionService;

        public GymScheduleController(IGymScheduleCollectionService gymScheduleCollectionService)
        {
            _gymScheduleCollectionService = gymScheduleCollectionService;
        }
    }
}
