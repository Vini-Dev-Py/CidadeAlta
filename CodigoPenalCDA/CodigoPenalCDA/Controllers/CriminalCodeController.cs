using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CodigoPenalCDA.Business;
using CodigoPenalCDA.Data.VO;
using CodigoPenalCDA.Hypermedia.Filters;

namespace CodigoPenalCDA.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CriminalCodeController : ControllerBase
    {
        private ICriminalCodeBusiness _criminalCodeBusiness;

        public CriminalCodeController(ICriminalCodeBusiness criminalCodeBusiness)
        {
            _criminalCodeBusiness = criminalCodeBusiness;
        }

        // [HttpGet]
        // [TypeFilter(typeof(HyperMediaFilter))]
        // public IActionResult GetCriminalCodes() 
        // {
        //     return Ok(_criminalCodeBusiness.FindAll());
        // }

        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetCriminalCodesPage(
            [FromQuery] string name, 
            string sortDirection, 
            int pageSize,
            int page
        ) 
        {
            return Ok(_criminalCodeBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetCriminalCode(long id) 
        {
            var criminalCode = _criminalCodeBusiness.FindByID(id);
            if (criminalCode == null) return NotFound();

            return Ok(criminalCode);
        }

        [HttpGet("FindName")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetCriminalCodeByName([FromQuery] string name) 
        {
            var criminalCode = _criminalCodeBusiness.FindByName(name);
            if (criminalCode == null) return NotFound();

            return Ok(criminalCode);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult CreateCriminalCode([FromBody] CriminalCodeVO CriminalCode, [FromQuery] string token)
        {
            if (CriminalCode == null) return BadRequest();
            return Ok(_criminalCodeBusiness.Create(CriminalCode, token));
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
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