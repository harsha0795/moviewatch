using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace moviewatch.Models
{
    public class MemberShip
    {
        public int Id { get; set; }
        public int signupFee { get; set; }
        public int DurationMonths { get; set; }
        public int DiscountPercentage { get; set; }
        public string Name { get; set; }

        public static int unknown = 0;
        public static int PayAsYouGo = 1;
    }
}