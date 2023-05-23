// Jay Bai
// L6oop  
// TINFO-200
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date             Developer       Description of change
// 2022-02-10       Jay             create file
// 2022-02-10       Jay             add codes and create info GradePtAvg EnrollmentDate methods
// 2022-02-12       Jay             start debug and rebuild
// 2022-03-04       Jay             add discription and final build
using System;

namespace StudentDB
{
    internal class Student // : object
    {
        // definition of the data stored in a POCO student class object

        public ContactInfo Info { get; set; }
        private double gradePtAvg;
        public DateTime EnrollmentDate { get; set; }

        // replace the do nothing no-arg ctor
        public Student()
        { 
        }

        // overloading the ctor for student class
        // fully specified ctor for making student POCO objects
        public Student(ContactInfo info, double grades, DateTime enrolled)
        {
            Info = info;
            GradePtAvg = grades;
            EnrollmentDate = enrolled;
        }

        public double GradePtAvg
        {
            get
            {
                return gradePtAvg;
            }
            set
            {
                if(0 <= value && value <= 4)
                {
                    // only set the gpa if passe in val is between
                    // "legal" defined GPA range 0 to 4 inclusive
                    gradePtAvg = value;
                }
                else
                {
                    gradePtAvg = 0.7;
                }
            }
        }


        // format a student object to a string for
        // displaying student data to the user in the UI
        // writing the data to the output file
        public override string ToString()
        {
            // create a temp string to hold the output
            string str = string.Empty;

            str += "**** Student Record *********************************\n";
            // build up the string with data from the object
            str += $"First Name: {Info.FirstName}\n";
            str += $" Last Name: {Info.LastName}\n";
            str += $"       GPA: {GradePtAvg}\n";
            str += $"     Email: {Info.EmailAddress}\n";
            str += $"  Enrolled: {EnrollmentDate}\n\n";

            // return the string
            return str;
        }


        // format a student object to a string for
        // writing the data to the output file
        public virtual string ToStringForOutputFile()
        {
            // temp string to hold output
            string str = string.Empty;

            // build up the string with data from the object
            str += $"{Info.FirstName}\n";
            str += $"{Info.LastName}\n";
            str += $"{GradePtAvg}\n";
            str += $"{Info.EmailAddress}\n";
            str += $"{EnrollmentDate}\n";

            // return the string
            return str;
        }
    }
}