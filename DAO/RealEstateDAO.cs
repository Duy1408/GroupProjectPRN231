using BusinessObject.BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RealEstateDAO
    {
        private static RealEstateDAO instance;

        public static RealEstateDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RealEstateDAO();
                }
                return instance;
            }
        }

        public List<RealEstate> GetAllRealEstate()
        {
            var _context = new TheRealEstateDBContext();
            return _context.RealEstates.Include(c => c.User).ToList();
        }

        public bool AddNewRealEstate(RealEstate realestate)
        {
            var _context = new TheRealEstateDBContext();
            var a = _context.RealEstates.SingleOrDefault(c => c.RealEstateID == realestate.RealEstateID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.RealEstates.Add(realestate);
                _context.SaveChanges();
                return true;

            }
        }

        public bool UpdateRealEstate(RealEstate realestate)
        {
            var _context = new TheRealEstateDBContext();
            var a = _context.RealEstates.SingleOrDefault(c => c.RealEstateID == realestate.RealEstateID);

            if (a == null)
            {
                return false;
            }
            else
            {
                _context.Entry(a).CurrentValues.SetValues(realestate);
                _context.SaveChanges();
                return true;
            }
        }

        public RealEstate GetRealEstateByID(int id)
        {
            var _context = new TheRealEstateDBContext();
            return _context.RealEstates.SingleOrDefault(a => a.RealEstateID == id);
        }

        public void DeleteRealEstate(RealEstate realestate)
        {
            var _context = new TheRealEstateDBContext();

            var a = _context.RealEstates.FirstOrDefault(a => a.RealEstateID == realestate.RealEstateID);
            _context.RealEstates.Remove(a);

            _context.SaveChanges();
        }

        public IQueryable<RealEstate> SearchRealEstateByName(string searchvalue)
        {
            var _context = new TheRealEstateDBContext();
            var a = _context.RealEstates.Where(a => a.RealEstateAddress.ToUpper().Contains(searchvalue.Trim().ToUpper()));


            return a;
        }


    }
}
