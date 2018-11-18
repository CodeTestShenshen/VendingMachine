using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VendingMachineApp.Services;
using VendingMachineApp.ViewModels;

namespace VendingMachineApp.Controllers
{
    public class MachineStateController: ApiController
    {
        private readonly IStateMonitor monitor;

        public MachineStateController(IStateMonitor stateMonitor)
        {
            this.monitor = stateMonitor; 
        }
        

        [HttpGet]
        [Route("api/MachineState")]
        public IHttpActionResult GetAllMachineStates()
        {
            return Ok(monitor.GetAll());
        }

        [HttpGet]
        [Route ("api/MachineState/{seriesNumber}")]
        public IHttpActionResult GetMachineState(string seriesNumber)
        {
            var state = monitor.GetStateWithMachineNum(seriesNumber);
            if (state == null)
            {
                NotFound();
            }

            return Ok(state);
        }

        [HttpPost]
        [Route("api/MachineState")]
        public IHttpActionResult UpdateTransaction([FromBody]RunningState value)
        {
            monitor.UpdateStatus(value);
            return CreatedAtRoute("DefaultApi", new {controller = "MachineState", id = value.MachineSeriesNumber}, value);
        }
    }
}
