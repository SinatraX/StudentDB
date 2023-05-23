// Jay Bai
// L6oop  
// TINFO-200
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date             Developer       Description of change
// 2022-02-10       Jay             file creation and initial testing
// 2022-02-10       Jay             add app solution
// 2022-03-04       Jay             add discription
// 2022-03-05       Jay             final check           
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    class Program
    {
        // document the class and the useage
        static void Main(string[] args)
        {
            // create a single instance of db application
            StudentApp app = new StudentApp();

            // read in the data from the input file
            app.ReadDataFromInputFile();
            // operate the database - carry out the user's CRUD operations
            app.RunDatabaseApp();

            //app.WriteDataToOutputFile();

        }
    }
}
