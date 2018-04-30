using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    class MembershipType
    {
        public string MembershipName { get; set; }
        public string MembershipPrice { get; set; }
        public string MembershipAvailibility { get; set; }

        public MembershipType()
        {

        }
        public MembershipType(string membershipname, string membershipprice, string membershipavailibility)
        {
            MembershipName = membershipname;
            MembershipPrice = membershipprice;
            MembershipAvailibility = membershipavailibility;
        }
        public override string ToString()
        {
            return "Membership Type" + Environment.NewLine + "Membership Name:" + MembershipName + Environment.NewLine + "Membership Price:" + MembershipPrice + Environment.NewLine + "Membership Availibility:" + MembershipAvailibility;
        }
    }
}
