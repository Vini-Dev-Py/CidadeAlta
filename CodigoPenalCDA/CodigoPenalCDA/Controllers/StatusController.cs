using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CodigoPenalCDA.Business;
using CodigoPenalCDA.Data.VO;

namespace CodigoPenalCDA.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class StatusController : ControllerBase
    {
        private IStatusBusiness _statusBusiness;

        public StatusController(IStatusBusiness statusBusiness)
        {
            _statusBusiness = statusBusiness;
        }

        [HttpGet]
        public IActionResult GetStatus() 
        {
            return Ok(_statusBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id) 
        {
            var status = _statusBusiness.FindByID(id);
            if (status == null) return NotFound();

            return Ok(status);
        }

        [HttpPost]
        public IActionResult CreateStatus([FromBody] StatusVO status)
        {
            if (status == null) return BadRequest();
            return Ok(_statusBusiness.Create(status));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStatus([FromBody] StatusVO status)
        {
            if (status == null) return BadRequest();
            return Ok(_statusBusiness.Update(status));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStatus(long id)
        {
            _statusBusiness.Delete(id);
            return NoContent();
        }

    }
}