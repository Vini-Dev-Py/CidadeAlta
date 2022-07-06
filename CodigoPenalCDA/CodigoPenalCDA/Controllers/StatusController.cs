using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodigoPenalCDA.Business;
using CodigoPenalCDA.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodigoPenalCDA.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private IStatusBusiness _statusBusiness;

        public StatusController(IStatusBusiness statusBusiness)
        {
            _statusBusiness = statusBusiness;
        }

        [HttpGet]
        public IActionResult GetCriminalCodes() 
        {
            return Ok(_statusBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetCriminalCode(long id) 
        {
            var status = _statusBusiness.FindByID(id);
            if (status == null) return NotFound();

            return Ok(status);
        }

        [HttpPost]
        public IActionResult CreateCriminalCode([FromBody] StatusVO status)
        {
            if (status == null) return BadRequest();
            return Ok(_statusBusiness.Create(status));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCriminalCode([FromBody] StatusVO status)
        {
            if (status == null) return BadRequest();
            return Ok(_statusBusiness.Update(status));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCriminalCode(long id)
        {
            _statusBusiness.Delete(id);
            return NoContent();
        }

    }
}