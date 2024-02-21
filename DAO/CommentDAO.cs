using BusinessObject.BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CommentDAO
    {
        private static CommentDAO instance;

        public static CommentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommentDAO();
                }
                return instance;
            }
        }

        public List<Comment> GetAllComment()
        {
            var _context = new TheRealEstateDBContext();
            return _context.Comments.Include(c => c.UserID).Include(c => c.RealEstateID).ToList();

        }

        public bool AddNewAuction(Auction auction)
        {
            var _context = new TheRealEstateDBContext();
            var a = _context.Auctions.SingleOrDefault(c => c.AuctionID == auction.AuctionID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.Auctions.Add(auction);
                _context.SaveChanges();
                return true;

            }
        }

    }
}
