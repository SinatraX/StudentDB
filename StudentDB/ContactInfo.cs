// Jay Bai
// L6oop  
// TINFO-200
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date             Developer       Description of change
// 2022-02-10       Jay             create file
// 2022-02-10       Jay             add codes
// 2022-02-12       Jay             start rebuild
// 2022-02-12       Jay             start debug
// 2021-02-12       Jay             create Contact information
namespace StudentDB
{
    public class ContactInfo
    {
        // data store for the database in operation
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private string emailAddress;

        // display first last and email address
        public ContactInfo(string first, string last, string email)
        {
            FirstName = first;
            LastName = last;
            EmailAddress = email;
        }
        
        // method for enter email address
        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                // passed in email must have at least 3 chars and one must be "@"
                if (value.Contains("@") && value.Length > 3)
                {
                    emailAddress = value;
                }
                else
                {
                    // TODO: Wrong email enter result - look into possiable regex
                    emailAddress = "ERROR: NOT A VALID EMAIL ADDRESS.";
                }
            }
        }

        // lambda expression for user friendly printing of the contact info
        public override string ToString() => $"{FirstName}\n{LastName}\n{EmailAddress}\n";
        public string ToStringLegal() => $"{LastName}, {FirstName}\n{EmailAddress}\n";
    }
}