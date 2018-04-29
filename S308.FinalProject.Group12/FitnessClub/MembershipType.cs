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
        public string MembershipLength { get; set; }
        public string MembershipAvailibility { get; set; }

        public MembershipType()
        {

        }
        public MembershipType(string membershipname, string membershipprice, string membershiplength, string membershipavailibility)
        {
            MembershipName = membershipname;
            MembershipPrice = membershipprice;
            MembershipLength = membershiplength;
            MembershipAvailibility = membershipavailibility;
        }
        public override string ToString()
        {
            return "MembershipType" + Environment.NewLine + "MembershipName:" + MembershipName + Environment.NewLine + "Membership Price:" + MembershipPrice + Environment.NewLine + "MembershipLength:" + MembershipLength + Environment.NewLine + "Membership Availibility:" + MembershipAvailibility;
        }
    }
}
