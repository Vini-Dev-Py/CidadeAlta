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
    public class CriminalCodeController : ControllerBase
    {
        private ICriminalCodeBusiness _criminalCodeBusiness;

        public CriminalCodeController(ICriminalCodeBusiness criminalCodeBusiness)
        {
            _criminalCodeBusiness = criminalCodeBusiness;
        }

        [HttpGet]
        public IActionResult GetCriminalCodes() 
        {
            return Ok(_criminalCodeBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetCriminalCode(long id) 
        {
            var criminalCode = _criminalCodeBusiness.FindByID(id);
            if (criminalCode == null) return NotFound();

            return Ok(criminalCode);
        }

        [HttpPost]
        public IActionResult CreateCriminalCode([FromBody] CriminalCodeVO CriminalCode, [FromQuery] string token)
        {
            if (CriminalCode == null) return BadRequest();
            return Ok(_criminalCodeBusiness.Create(CriminalCode, token));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCriminalCode([FromBody] CriminalCodeVO CriminalCode, [FromQuery] string token)
        {
            if (CriminalCode == null) return BadRequest();
            return Ok(_criminalCodeBusiness.Update(CriminalCode, token));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCriminalCode(long id)
        {
            _criminalCodeBusiness.Delete(id);
            return NoContent();
        }

    }
}