using moviewatch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace moviewatch.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        public bool IsSubscribedNewsletter { get; set; }
        [Required]

        public MemberShipDTO MemberShip { get; set; }
        public int MemberShipId { get; set; }
       // [Men18yrs]
        public DateTime? DOB { get; set; }
    }
}