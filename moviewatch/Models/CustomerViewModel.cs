using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;

namespace moviewatch.Models
{
    public class CustomerViewModel
    {
        public IEnumerable<MemberShip> Membership { get; set; }
        public Customer Customer { get; set; }
    }
}