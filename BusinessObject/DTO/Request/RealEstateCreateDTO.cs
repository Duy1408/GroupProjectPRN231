using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.Request
{
    public class RealEstateCreateDTO
    {
      
        public string? RealEstateName { get; set; }

        public string RealEstateAddress { get; set; }

        public double Estimation { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
       
        public int UserID { get; set; }
        
    }
}
