using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    class Features
    {
        public string IndividualSingleMonth { get; set; }
        public string IndividualSingleMonthCheck { get; set; }
        public string IndividualTwelveMonth { get; set; }
        public string IndividualTwelveMonthCheck { get; set; }
        public string TwoSingleMonth { get; set; }
        public string TwoSingleMonthCheck { get; set; }
        public string TwoTwelveMonth { get; set; }
        public string TwoTwelveMonthCheck { get; set; }
        public string FamilySingleMonth { get; set; }
        public string FamilySingleMonthCheck { get; set; }
        public string FamilyTwelveMonth { get; set; }
        public string FamilyTwelveMonthCheck { get; set; }

        public Features()
        {

        }
        public Features(string individualsinglemonth, string individualtwelvemonth, string twosinglemonth, string twotwelvemonth, string familysinglemonth, string familytwelvemonth)
        {
            IndividualSingleMonth = individualsinglemonth;
            IndividualTwelveMonth = individualtwelvemonth;
            TwoSingleMonth = twosinglemonth;
            TwoTwelveMonth = twotwelvemonth;
            FamilySingleMonth = familysinglemonth;
            FamilyTwelveMonth = familytwelvemonth;
        }
        public override string ToString()
        {
            return "Features" + Environment.NewLine + "Individual Single Month:" + IndividualSingleMonth + Environment.NewLine + "Individual Twelve Month:" + IndividualTwelveMonth + Environment.NewLine + "Two Single Month:" + TwoSingleMonth + Environment.NewLine + "Two Twelve Month:" + TwoTwelveMonth + Environment.NewLine + "Family Single Month:" + FamilySingleMonth + Environment.NewLine + "Family Twelve Month:" + FamilyTwelveMonth;
        }
    }
}
