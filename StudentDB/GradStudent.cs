// L6oop  
// TINFO-200
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date             Developer       Description of change
// 2022-03-04       Jay             file creation and initial testing
// 2021-03-05       Jay             create TuitionCredit and FacultyAdvisor methods
// 2021-03-05       Jay             change methods and final testing
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    internal class GradStudent : Student
    {
        // data store for the database in operation
        public decimal TuitionCredit { get; set; }
        public string FacultyAdvisor { get; set; }

        public GradStudent(string first, string last, double gpa,
                            string email, DateTime enrolled,
                            decimal credit, string advisor)
            : base (new ContactInfo(first, last, email), gpa, enrolled)
        {
            TuitionCredit = credit;
            FacultyAdvisor = advisor;
        }

        // lambda expression - "=>" reads: "goes to"
        public override string ToString() => base.ToString() + $"    Credit: {TuitionCredit:C}\n      Fac: {FacultyAdvisor}\n";

        public override string ToStringForOutputFile()
        {
            StringBuilder str = new StringBuilder(this.GetType() + "\n");
            str.Append(base.ToStringForOutputFile());

            str.Append($"{TuitionCredit}\n");
            str.Append($"{FacultyAdvisor}"); // NO CRLF

            return str.ToString();
        }
    }
}
