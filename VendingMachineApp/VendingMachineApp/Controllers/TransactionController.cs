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
    public class TransactionController : ApiController
    {
        private readonly IRepository repository;

        public TransactionController(IRepository repository)
        {
            this.repository = repository;
        }

       
        [HttpGet]
        [Route ("api/Machine/{seriesNumber}/Transactions")]
        public IHttpActionResult GetTransactions(string seriesNumber)
        {
            var transactions = repository.GetTransactions(seriesNumber);
            if (transactions == null)
            {
                return NotFound();
            } 

            return Ok(transactions.Select(t => TransactionModel.Create(t)));
        }

        [HttpPost]
        [Route("api/Transaction")]
        public IHttpActionResult SaveTransaction([FromBody]TransactionModel value)
        {
            var machine  = repository.GetMachineByseriesNumber(value.MachineSeriesNumber);
            if (machine == null)
            {
                return BadRequest();
            }
            var flavour  = repository.GetFlavourBySeriesNumber(value.FlavourSeriesNumber);
            if (flavour == null)
            {
                return BadRequest();
            }

            var transaction = TransactionModel.Create(value, machine.Id, flavour.Id);
             repository.SaveTransaction(transaction);
            return CreatedAtRoute("DefaultApi", new {controller = "Transaction", id = transaction.Id}, transaction);
        }
    }
}
