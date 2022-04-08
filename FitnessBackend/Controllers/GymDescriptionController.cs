using FitnessBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GymDescriptionController: ControllerBase
    {
        IGymDescriptionCollectionService _gymDescriptionCollectionService;

        public GymDescriptionController(IGymDescriptionCollectionService gymDescriptionCollectionService)
        {
            this._gymDescriptionCollectionService = gymDescriptionCollectionService;
        }
    }
}
