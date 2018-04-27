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
        public Features(string individualsinglemonth, string individualsinglemonthcheck, string individualtwelvemonth, string individualtwelvemonthcheck, string twosinglemonth, string twosinglemonthcheck, string twotwelvemonth, string twotwelvemonthcheck, string familysinglemonth, string familysinglemonthcheck, string familytwelvemonth, string familytwelvemonthcheck)
        {
            IndividualSingleMonth = individualsinglemonth;
            IndividualSingleMonthCheck = individualsinglemonthcheck;
            IndividualTwelveMonth = individualtwelvemonth;
            IndividualTwelveMonthCheck = individualtwelvemonthcheck;
            TwoSingleMonth = twosinglemonth;
            TwoSingleMonthCheck = twosinglemonthcheck;
            TwoTwelveMonth = twotwelvemonth;
            TwoTwelveMonthCheck = twotwelvemonthcheck;
            FamilySingleMonth = familysinglemonth;
            FamilySingleMonthCheck = familysinglemonthcheck;
            FamilyTwelveMonth = familytwelvemonth;
            FamilyTwelveMonthCheck = familytwelvemonthcheck;
        }
        public override string ToString()
        {
            return "Features" + Environment.NewLine + "Individual Single Month:" + IndividualSingleMonth + Environment.NewLine + "Individual Single Month Check:" + IndividualSingleMonthCheck + Environment.NewLine + "Individual Twelve Month:" + IndividualTwelveMonth + Environment.NewLine +"Individual Twelve Month Check:" + IndividualTwelveMonthCheck + Environment.NewLine + "Two Single Month:" + TwoSingleMonth + Environment.NewLine + "Two Single Month Check:" + TwoSingleMonthCheck + Environment.NewLine + "Two Twelve Month:" + TwoTwelveMonth + Environment.NewLine + "Two Twelve Month Check:" + TwoTwelveMonthCheck + Environment.NewLine + "Family Single Month:" + FamilySingleMonth + Environment.NewLine + "Family Single Month Check:" + FamilySingleMonthCheck + Environment.NewLine + "Family Twelve Month:" + FamilyTwelveMonth + Environment.NewLine + "Family Twelve Month:" + FamilyTwelveMonthCheck;
        }
    }
}
