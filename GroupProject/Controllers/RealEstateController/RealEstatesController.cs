using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using Service.Interface;

namespace GroupProject.Controllers.RealEstateController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstatesController : ControllerBase
    {
        private IRealEstateService _service;

        public RealEstatesController(IRealEstateService service)
        {
            _service = service;
        }

        // GET: api/RealEstates
        [HttpGet]
        public ActionResult<IEnumerable<RealEstate>> GetRealEstates()
        {
          if (_service.GetRealEstates() == null)
          {
              return NotFound();
          }
            return _service.GetRealEstates().ToList();
        }

        // GET: api/RealEstates/5
        [HttpGet("{id}")]
        public ActionResult<RealEstate> GetRealEstate(int id)
        {
          if (_service.GetRealEstates() == null)
          {
              return NotFound();
          }
            var realEstate = _service.GetRealEstateById(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            return realEstate;
        }

        // PUT: api/RealEstates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateRealEstate(int id, RealEstate realEstate)
        {
            if (_service.GetRealEstates()==null)
            {
                return BadRequest();
            }

      

            try
            {
                _service.UpdateRealEstate(realEstate);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_service.GetRealEstateById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RealEstates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RealEstate>> PostRealEstate(RealEstate realEstate)
        {
          if (_service.GetRealEstates() == null)
          {
              return Problem("Entity set 'TheRealEstateDBContext.RealEstates'  is null.");
          }
            _service.AddNewRealEstate(realEstate);

            return CreatedAtAction("GetRealEstate", new { id = realEstate.RealEstateID }, realEstate);
        }

        // DELETE: api/RealEstates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealEstate(int id)
        {
            if (_service.GetRealEstates() == null)
            {
                return NotFound();
            }
            var realEstate =  _service.GetRealEstateById(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            _service.DeleteRealEstate(realEstate);

            return NoContent();
        }

        
    }
}
