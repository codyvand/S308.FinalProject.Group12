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
        public string MembershipLength { get; set; }

        public MembershipType()
        {

        }
        public MembershipType(string membershipname, string membershipprice, string membershipavailibility, string membershiplength)
        {
            MembershipName = membershipname;
            MembershipPrice = membershipprice;
            MembershipAvailibility = membershipavailibility;
            MembershipLength = membershiplength;
        }
        public override string ToString()
        {
            string strOutput = "";

            strOutput += "MembershipType: " + Environment.NewLine;
            strOutput += "Membership Name: " + MembershipName+ Environment.NewLine;
            strOutput += "Membership Price " + MembershipPrice + Environment.NewLine;
            strOutput += "Membership Availibility: " + MembershipAvailibility + Environment.NewLine;
            strOutput += "Membership Length " + MembershipLength + Environment.NewLine;

            return strOutput;
        }
    }
}
