// Jay Bai
// L6oop  
// TINFO-200
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date             Developer       Description of change
// 2022-02-10       Jay             file creation and initial testing
// 2022-02-10       Jay             add codes and create student file 
// 2022-02-12       Jay             start debug
// 2022-03-05       Jay             add code in userChoice and fix the error
// 2021-03-05       Jay             final check
using System;
using System.Collections.Generic;

namespace StudentDB
{
    internal class DbApp
    {
        // data store for the database in operation
        private List<Student> students = new List<Student>();

        internal void Run()
        {
            while(true)
            {
                // display a main menu
                DisplayMainMenu();

                // capture the user's choice of operation
                // obtain a choice from the user
                char userChoice = GetUserSelection();

                // execute the user choice of operation
                switch(userChoice)
                {
                    case 'C':           // [C]reate
                    case 'c':
                        break;
                    case 'D':           // [D]elete
                    case 'd':
                        // DeleteStudentRecord();
                        break;
                    case 'M':           // [M]odify
                    case 'm':
                        break;
                    case 'F':           // [F]ind
                    case 'f':
                        break;
                    case 'P':           // [P]rint
                    case 'p':
                        break;
                    case 'S':           // [S]ave
                    case 's':
                        break;
                    case 'E':           // [E]xit
                    case 'e':
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        private char GetUserSelection()
        {
            // code to accept the user input as a char single key press
            return char.Parse(Console.ReadLine());
        }

        private void DisplayMainMenu()
        {
            Console.Write(@"
***********************************
***** Student DB Main Menu ********
***********************************
[C]reate new student record
[D]elete student record
[M]odify a student record
[F]ind a student record for review
[P]rint all records
[S]ave all records w/o exit
[E]xit the application (also saves)
            User selection: ");
        }

        // send data into the list for testing during development
        public void SeedDatabaseList()
        {
            // the 2 step method - make a student then add it to the list
            //Student stu1 = new Student("Jay", "Bai", 4.0, "jbai1996@uw.edu", DateTime.Now);
            //students.Add(stu1);

            // the 1 step method - make a student in the add method to the list
            //students.Add(new Student("Bruce", "Lee", 4.0, "brucelee@uw.edu", DateTime.Now));
            
            //students.Add(new Student("Bob", "Dylan", 3.9, "bobdylan@uw.edu", DateTime.Now));
            //students.Add(new Student("Jimi", "Hendrix", 3.8, "jimihendrix@uw.edu", DateTime.Now));
        }
    }
}