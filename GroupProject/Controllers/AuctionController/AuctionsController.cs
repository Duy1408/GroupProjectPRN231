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
using BusinessObject.DTO.Response;
using GroupProject.Mapper;
using BusinessObject.DTO.Request;
using DAO;
using System.Xml.Linq;

namespace GroupProject.Controllers.AuctionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionService _auction;

        public AuctionsController(IAuctionService auction)
        {
            _auction = auction;
        }

        // GET: api/Auctions
        [HttpGet]
        public ActionResult<IEnumerable<AuctionResponseDTO>> GetAuctions()
        {
          if (_auction.GetAuction() == null)
          {
              return NotFound();
          }

            var config = new MapperConfiguration(
                 cfg => cfg.AddProfile(new AuctionProfile())
             );
            // create mapper
            var mapper = config.CreateMapper();



           
            var data = _auction.GetAuction().ToList().Select(auction => mapper.Map<Auction, AuctionResponseDTO>(auction));
            return Ok(data);
;        }

        // GET: api/Auctions/5
        [HttpGet("{id}")]
        public ActionResult<Auction> GetAuction(int id)
        {
          if (_auction.GetAuction() == null)
          {
              return NotFound();
          }
            var auction =  _auction.GetAuctionById(id);

            if (auction == null)
            {
                return NotFound();
            }

            return auction;
        }

        // PUT: api/Auctions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuction(int id, [FromForm] AuctionUpdateDTO autionUpdateDTO)
        {
            try
            {

                var auction = _auction.GetAuctionById(id);

                if (autionUpdateDTO.DateStart != null)
                {
                    auction.DateStart = (DateTime)autionUpdateDTO.DateStart;
                }
                if (autionUpdateDTO.DateEnd != null)
                {
                    auction.DateEnd = (DateTime)autionUpdateDTO.DateEnd;
                }
                if (autionUpdateDTO.AuctionType != null)
                {
                    auction.AuctionType = (bool)autionUpdateDTO.AuctionType;
                }
                if (autionUpdateDTO.DepositeAmount != null)
                {
                    auction.DepositeAmount = (double)autionUpdateDTO.DepositeAmount;
                }
                if (autionUpdateDTO.FeeAmount != null)
                {
                    auction.FeeAmount = (double)autionUpdateDTO.FeeAmount;
                }
                if (autionUpdateDTO.Status!= null)
                {
                    auction.Status = (bool)autionUpdateDTO.Status;

                }
                if (autionUpdateDTO.BidID != null)
                {
                    auction.BidID = (int)autionUpdateDTO.BidID;
                }
                if (autionUpdateDTO.RealEstateID != null)
                {
                    auction.RealEstateID = (int)autionUpdateDTO.RealEstateID;
                }
                _auction.UpdateAuction(auction);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_auction.GetAuctionById(id) == null)
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


        // POST: api/Auctions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Auction> PostAuction(  AuctionCreateDTO auctioncreateDTO)
        {
            var config = new MapperConfiguration(
                cfg => cfg.AddProfile(new AuctionProfile())
            );
            var mapper = config.CreateMapper();
            var auction = mapper.Map<Auction>(auctioncreateDTO);
            _auction.AddNewAuction(auction);
           
            return Ok(auction);
        }

        // DELETE: api/Auctions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuction(int id)
        {
            if (_auction.GetAuction()==null)
            {
                return NotFound();
            }
            var auction = _auction.GetAuctionById(id);
            if (auction == null)
            {
                return NotFound();
            }

            _auction.DeleteAuction(auction);

            return NoContent();
        }

     
    }
}
