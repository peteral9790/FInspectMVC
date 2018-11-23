using FInspectAPI.Models;
using FInspectServices;
using System;
using System.Linq;
using System.Web.Http;

namespace FInspectAPI.Controllers
{
    public class InspectorController : ApiController
    {
        private InspectorService _InspectorService = new InspectorService();
                
        [HttpGet()]
        [ActionName("GetInspectors")]
        public IHttpActionResult GetInspectors()
        {
            try
            {
                var inspectorList = _InspectorService.GetAll().Select(res => new Inspector
                {
                    Id = res.Id,
                    FirstName = res.FirstName,
                    LastName = res.LastName,
                    Location = res.Location,
                    EmployeeId = res.EmployeeId
                });
                if (inspectorList != null)
                {
                    return Ok(inspectorList);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpPost()]
        [ActionName("AddInspector")]
        public IHttpActionResult AddInspector(Inspector inspector)
        {
            if (inspector != null)
            {
                var Record = new FInspectData.Models.Inspector()
                {
                    Id = inspector.Id,
                    FirstName = inspector.FirstName,
                    LastName = inspector.LastName,
                    Location = inspector.Location,
                    EmployeeId = inspector.EmployeeId
                };
                _InspectorService.Add(Record);
                return Ok(Record);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpDelete()]
        [ActionName("DeleteInspector")]
        public IHttpActionResult DeleteInspector(int id)
        {
            if (id != 0)
            {
                _InspectorService.Delete(id);
                return Ok(id);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut()]
        [ActionName("UpdateInspector")]
        public IHttpActionResult UpdateInspector(int? id, Inspector inspector)
        {
            if (id != inspector.Id)
            {
                return BadRequest();
            }

            if (id != null)
            {
                var inspectorDetails = new FInspectData.Models.Inspector()
                {
                    Id = inspector.Id,
                    FirstName = inspector.FirstName,
                    LastName = inspector.LastName,
                    Location = inspector.Location,
                    EmployeeId = inspector.EmployeeId
                };
                _InspectorService.Update(inspectorDetails);
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }
            else
            {
                return NotFound();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}