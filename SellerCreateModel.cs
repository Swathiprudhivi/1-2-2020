using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EMART.Models
{
    public class SellerCreateModel
    {
        [Key]
        public int sid { get; set; }
        [Required(ErrorMessage = "pls Enter Name")]
        [StringLength(maximumLength: 20, MinimumLength = 4, ErrorMessage = "Name shold be 4 between 20")]
        public string sname { get; set; }
        [DataType("Password")]
        public string spassword { get; set; }
        public string companyname { get; set; }
        public int gstin { get; set; }
        //[RegularExpression(@"[6-9]\d{9}", ErrorMessage = "Invalid Mobile no")]
        public int sphnum { get; set; }
        public string semail { get; set; }
        public string postal_address { get; set; }
        public IFormFile PhotoPath { get; set; }
    }
}
