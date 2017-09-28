using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Data.Entity.Infrastructure;

namespace moviewatch.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        public bool IsSubscribedNewsletter { get; set; }
        public MemberShip MemberShip { get; set; }
        [Required]
        public int MemberShipId { get; set; }

        [Men18yrs]
        public DateTime? DOB { get; set; }
    }
}