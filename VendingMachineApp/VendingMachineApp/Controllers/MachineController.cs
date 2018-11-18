using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VendingMachineApp.Database;
using VendingMachineApp.Services;
using VendingMachineApp.ViewModels;

namespace VendingMachineApp.Controllers
{
    public class MachineController : ApiController
    {
        private readonly IRepository repository;

        public MachineController(IRepository repository )
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("api/Machine")]
        public IHttpActionResult Get()
        {
            var machines = repository.GetMachines();

            if (machines == null)
            {
                return NotFound();
            }
            return Ok(machines.Select(m => MachineModel.Create(m)));
            }
        }
  
}
