// Jay Bai
// L6oop  
// TINFO-200
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date             Developer       Description of change
// 2022-03-05       Jay             file creation
// 2022-03-05       Jay             add methods
// 2022-03-05       Jay             start debug and rebuild
// 2021-03-05       Jay             change methods names and final testing
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    public enum YearRank
    {
        Freshman = 1,
        Sophomore = 2,
        Junior = 3,
        Senior = 4
    }
    internal class Undergrad : Student
    {
        public YearRank Rank { get; set; }
        public string DegreeMajor { get; set; }

        // chained ctor definition - study example 11_08 form deitel
        public Undergrad(string first, string last, double gpa, 
                         string email, DateTime enrolled,
                         YearRank rank, string degree)
            : base (new ContactInfo(first, last, email), gpa, enrolled)
        {
            Rank = rank;
            DegreeMajor = degree;
        }

        // expression-bodies method - using the lambda operator
        // for friendly printout to the UI or components

        public override string ToString() => base.ToString() + $"       Year: {Rank}\n        Major: {DegreeMajor}\n";

        public override string ToStringForOutputFile()
        {
            // put marker in the file that indicates the derived type of the student
            string str = this.GetType() + "\n";
            str += base.ToStringForOutputFile();

            str += $"{Rank}\n";
            str += $"{DegreeMajor}";    // no CRLF on the last output line because: WriteLine()

            return str;
        }
    }
}
