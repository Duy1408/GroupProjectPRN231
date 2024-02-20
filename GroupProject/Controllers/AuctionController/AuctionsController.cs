using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using Service.Interface;

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
        public ActionResult<IEnumerable<Auction>> GetAuctions()
        {
          if (_auction.GetAuction() == null)
          {
              return NotFound();
          }
            return _auction.GetAuction().ToList()
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
        public async Task<IActionResult> PutAuction(int id, Auction auction)
        {
            if (_auction.GetAuction()==null)
            {
                return BadRequest();
            }
        

            try
            {
                _auction.UpdateAuction(auction);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_auction.GetAuctionById(id)==null)
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

        // POST: api/Auctions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Auction>> PostAuction(Auction auction)
        {
          if (_auction.GetAuction()==null)
          {
              return Problem("Entity set 'TheRealEstateDBContext.Auctions'  is null.");
          }
            _auction.AddNewAuction(auction);

            return CreatedAtAction("GetAuction", new { id = auction.AuctionID }, auction);
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
