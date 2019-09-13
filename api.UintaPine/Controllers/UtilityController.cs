﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using logic.UintaPine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model.Server.UintaPine;
using model.UintaPine.Utility;

namespace api.UintaPine.Controllers
{
    public class UtilityController : ControllerBase
    {
        private UtilityLogic _utilityLogic { get; set; }
        private ApplicationSettings _applicationSettings { get; set; }
        public UtilityController(UtilityLogic utilityLogic, ApplicationSettings applicationSettings)
        {
            _utilityLogic = utilityLogic;
            _applicationSettings = applicationSettings;
        }

        [Route("api/v1/ping")]
        [HttpGet]
        async public Task<IActionResult> Ping()
        {
            var result = await _utilityLogic.PingAsync(_applicationSettings.Name);

            return Ok(result);
        }
    }
}