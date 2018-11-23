using FInspectAPI.Models;
using FInspectServices;
using System;
using System.Web.Http;

namespace FInspectAPI.Controllers
{
    public class AssemblyDetailsController : ApiController
    {
        private AssemblyDetailsService _AssemblyService = new AssemblyDetailsService();

        [HttpGet()]
        [ActionName("GetAssemblyDetails")]
        public IHttpActionResult GetAssemblyDetails(string id)
        {
            try
            {
                var assemblyDetails = _AssemblyService.GetAssemblyDetails(id);
                if (assemblyDetails != null)
                {
                    var details = new Assembly()
                    {
                        TMSPartNumber = assemblyDetails.TMSPartNumber,
                        CustomerPartNumber = assemblyDetails.CustomerPartNumber,
                        CableMI = assemblyDetails.CableMI,
                        CableDescription = assemblyDetails.CableDescription,
                        Length = assemblyDetails.Length,
                        FWDConnType = assemblyDetails.FWDConnType,
                        FWDConnector = assemblyDetails.FWDConnector,
                        FWDIntermediate = assemblyDetails.FWDIntermediate,
                        AFTIntermediate = assemblyDetails.AFTIntermediate,
                        AFTConnector = assemblyDetails.AFTConnector,
                        AFTConnType = assemblyDetails.AFTConnType
                    };
                    return Ok(details);
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
