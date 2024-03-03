using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using Service.Interface;
using AutoMapper;
using GroupProject.Mapper;
using BusinessObject.DTO.Response;
using BusinessObject.DTO.Request;

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

        
            var config = new MapperConfiguration(
                cfg => cfg.AddProfile(new RealEstateProfile())
            );
            // create mapper
            var mapper = config.CreateMapper();

            

            var data = _service.GetRealEstates().ToList().Select(estate => mapper.Map<RealEstate, RealEstateResponseDTO>(estate));
                
            return Ok(data);
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
        public IActionResult UpdateRealEstate(int id, [FromForm] RealEstateUpdateDTO estateUpdateDTO)
        {
           try
            {

                var estate = _service.GetRealEstateById(id);

                if (estateUpdateDTO.Estimation != null)
                {
                    estate.Estimation = estateUpdateDTO.Estimation;
                }
                if (estateUpdateDTO.Description != null)
                {
                    estate.Description = estateUpdateDTO.Description;
                }
                if (estateUpdateDTO.UserID!= null)
                {
                    estate.UserID = estateUpdateDTO.UserID;
                }
                if (estateUpdateDTO.Status != null)
                {
                    estate.Status = estateUpdateDTO.Status;
                }
                _service.UpdateRealEstate(estate);
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

            return Ok("Update Successfully");
        }

        // POST: api/RealEstates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<RealEstate> PostRealEstate(RealEstateCreateDTO realEstateDTO)
        {
            var config = new MapperConfiguration(
              cfg => cfg.AddProfile(new RealEstateProfile())
          );
            var mapper = config.CreateMapper();
            var estate = mapper.Map<RealEstate>(realEstateDTO);
            _service.AddNewRealEstate(estate);
            return Ok(estate);
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
