using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZAAppliciation
{
    public class UserMemberShip
    {
        public int? UserID { get; set; }
        public string? MemberType { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? Adults { get; set; }
        public int? Students { get; set; }
        public int? Children { get; set; }
        public Boolean? Renewal { get; set; }

        public UserMemberShip(int? userID, string? memberType, decimal? totalPrice, int? adults, int? students, int? children, bool? renewal)
        {
            UserID = userID;
            MemberType = memberType;
            TotalPrice = totalPrice;
            Adults = adults;
            Students = students;
            Children = children;
            Renewal = renewal;
        }
    }
}
