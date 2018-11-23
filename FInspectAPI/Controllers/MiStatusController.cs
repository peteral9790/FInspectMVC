using FInspectAPI.Models;
using FInspectServices;
using System;
using System.Web.Http;

namespace FInspectAPI.Controllers
{
    public class MiStatusController : ApiController
    {
        private MiStatusService miStatusService = new MiStatusService();

        [HttpGet()]
        [ActionName("GetMiStatusData")]
        public IHttpActionResult GetMiStatusData(int id)
        {
            //System.Threading.Thread.Sleep(2000);
            try
            {
                var MiStatusLookup = miStatusService.GetMIStatusTransaction(id);
                if (MiStatusLookup != null)
                {
                    var transaction = new MIStatusTransaction()
                    {
                        Id = MiStatusLookup.Id,
                        SalesOrder = MiStatusLookup.SalesOrder,
                        MINumber = MiStatusLookup.MINumber,
                        MIRev = MiStatusLookup.MIRev,
                        Location = MiStatusLookup.Location,
                        CustomerName = MiStatusLookup.CustomerName,
                    };
                    return Ok(transaction);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}