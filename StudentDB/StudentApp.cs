// Jay Bai
// L6oop  
// TINFO-200
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date             Developer       Description of change
// 2022-02-10       Jay             file create
// 2022-02-10       Jay             add codes and create student file 
// 2022-02-12       Jay             start debug
// 2022-02-12       Jay             create OUTPUT and INPUT file
// 2022-02-20       Jay             testing OUPUT file and debug
// 2022-03-04       Jay             add [C] [R] [D] [U] methods
// 2021-03-05       Jay             change methods and final testing
// 2021-03-06       Jay             fix StudentDB.GradStudent error
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    internal class StudentApp
    {
        // create the storage for a collection of students
        private List<Student> students = new List<Student>();
        internal void ReadDataFromInputFile()
        {
            // create a stream reader to attach to the input file on disk
            StreamReader infile = new StreamReader("INPUTDATAFILE.txt");

            // use the file to read in student data
            string studentType = string.Empty;
            while ((studentType = infile.ReadLine()) != null)
            {
                // reading in the rest of the srudent record
                string first = infile.ReadLine();
                string last = infile.ReadLine();
                double gpa = double.Parse(infile.ReadLine());
                string email = infile.ReadLine();
                DateTime date = DateTime.Parse(infile.ReadLine());
                 
                // branch
                if(studentType == "StudentDB.Undergrad")
                {
                    YearRank rank = (YearRank)Enum.Parse(typeof(YearRank), infile.ReadLine());
                    string major = infile.ReadLine();

                    Undergrad undergrad = new Undergrad(first, last, gpa, email, date, rank, major);
                    students.Add(undergrad);

                    // Testing (if needed)
                    // Console.WriteLine(undergrad);
                }
                else if (studentType == "StudentDB.GradStudent")
                {
                    decimal tuition = decimal.Parse(infile.ReadLine());
                    string facAdvisor = infile.ReadLine();

                    GradStudent grad = new GradStudent(first, last, gpa, email, date, tuition, facAdvisor);
                    students.Add(grad);

                    // Console.WriteLine(grad);
                }
                else
                {
                    Console.WriteLine($"ERROR: type {studentType} is not a valid student.");
                    break;
                }
                // create the new read-in student from the data and store in the list
                // Student stu = new Student(first, last, gpa, email, date);
                // students.Add(stu);
                // Console.WriteLine($"Done reading record for:\n {stu}");
            }
            // release the resource
            infile.Close();
        }

        // TODO: searches the current list for a student record
        // returns the student object if found, null if not found
        // email contains the search string
        private Student FindStudentRecord(out string email)
        {
            Console.Write("\nENTER e-mail address to search: ");
            email = Console.ReadLine();

            foreach (var student in students)
            {
                if(email == student.Info.EmailAddress)
                {
                    // found it!
                    Console.WriteLine($"FOUND email address: {student.Info.EmailAddress}");
                    return student;
                }
            }
            // arrived here, must not have found the rec
            Console.WriteLine($"{email} NOT FOUND.");
            return null;
        }

        internal void RunDatabaseApp()
        {
            while(true)
            {
                // display a menu for the main selection of CRUD operations
                DisplayMainMenu();
                // capture the user choice
                // ConsoleKeyInfo obj
                char selection = GetUserSelection();
                string email = string.Empty;

                // capturing the user's selection
                // char selection = char.Parse(Console.ReadLine());

                // doing that thing (method call) that the user indicated
                switch (selection)
                {
                    case 'A':
                    case 'a':
                        AddStudentRecord();
                        break;
                    case 'F':
                    case 'f':
                        FindStudentRecord(out email);
                        break;
                    case 'P':
                    case 'p':
                        PrintAllRecords();
                        break;
                    case 'D':
                    case 'd':
                        DeleteStudentRecord();
                        break;
                    case 'M':
                    case 'm':
                        ModifyStudentRecord();
                        break;
                    case 'E':
                    case 'e':
                        ExitApplicationWithoutSave();
                        break;
                    case 'S':
                    case 's':
                        SaveAllChangesAndQuit();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine($"ERROR: {selection} is not a valid choice!");
                        break;
                }
            }
        }

        private void AddStudentRecord()
        {
            // first, search the list to see if this email rec already exists
            string email = string.Empty;
            Student stu = FindStudentRecord(out email);
            if(stu == null)
            {
                // gathe the update data
                Console.WriteLine($"Adding new student, Email:{email}");

                // start gathering data
                Console.WriteLine("ENTER first name: ");
                string first = Console.ReadLine();
                Console.WriteLine("ENTER last name: ");
                string last = Console.ReadLine();
                Console.WriteLine("ENTER GPA: ");
                double gpa = double.Parse(Console.ReadLine());
                // email
                // undergrad/grad students
                Console.Write("[U]ndergrad or [G]rad student? ");
                string studentType = Console.ReadLine().ToUpper();

                // branch out for [U] and [G]
                if(studentType == "U")
                {
                    // reading in an enumerated tyoe
                    Console.WriteLine("[1]Freshman, [2]Sophomore, [3]Junior, [4]Senior");
                    Console.Write("ENTER year/rank in school from above choices: ");
                    YearRank rank = (YearRank)int.Parse(Console.ReadLine());

                    Console.Write("Enter major degree program: ");
                    string major = Console.ReadLine();

                    // TODO: test if this use of polumorphism is allowing undergrad info
                    // in the list collection
                    stu = new Undergrad(first, last, gpa, email, DateTime.Now, rank, major);
                    students.Add(stu);
                }
                else if(studentType == "G")
                {
                    // gather additional grad student information
                    Console.Write("ENTER the tuition reimbursement earned(no commas): $");
                    decimal discount = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Enter full name of graduate faculty advisor: ");
                    string facAdvisor = Console.ReadLine();

                    GradStudent grad = new GradStudent(first, last, gpa,
                                                        email, DateTime.Now,
                                                        discount, facAdvisor);
                    students.Add(grad);
                }
                else
                {
                    Console.WriteLine($"ERROR: No student {email} created.\n" +
                        $"{studentType} is not valid type.");
                }
            }
            else
            {
                Console.WriteLine($"{email} RECORD FOUND! Can't add student {email}, \n" +
                                    $"Record already exists.");
            }
        }

        private void DeleteStudentRecord()
        {
            //search name
            string email = string.Empty;
            Student stu = FindStudentRecord(out email);
            if(stu != null)
            {
                // found the record
                students.Remove(stu);
            }
            else
            {
                // record not in database
                Console.WriteLine($"***** RECORD NOT FOUND. \nCan't delete record for user: {email}.");
            }
        }
        private void ModifyStudentRecord()
        {
            string email = string.Empty;
            Student stu = FindStudentRecord(out email);
            if(stu != null)
            {
                // start update the email
                students.Remove(stu);
                // update new first, last, gpa, and undergrad/grad information
                Console.WriteLine("ENTER the new first name: ");
                string first = Console.ReadLine();
                Console.WriteLine("ENTER the new last name: ");
                string last = Console.ReadLine();
                Console.WriteLine("ENTER the new GPA: ");
                double gpa = double.Parse(Console.ReadLine());
                // ask a user if needed to update undergrad/grad status
                Console.Write("[U]ndergrad or [G]rad student? ");
                string studentType = Console.ReadLine().ToUpper();

                // ask user to update undergrad/grad status
                if (studentType == "U")
                {
                    // enumerated type 1, 2, 3, 4 years in college level
                    Console.WriteLine("[1]Freshman, [2]Sophomore, [3]Junior, [4]Senior");
                    Console.Write("ENTER a new year/rank in school: ");
                    YearRank rank = (YearRank)int.Parse(Console.ReadLine());

                    Console.Write("Enter the new major: ");
                    string major = Console.ReadLine();

                    // update an exsiting student information
                    Undergrad undergrad = new Undergrad(first, last, gpa, email, DateTime.Now, rank, major);
                    students.Add(undergrad);
                }
                else if (studentType == "G")
                {
                    // gather additional grad student information
                    Console.Write("ENTER the new tuition reimbursement earned(no commas): $");
                    decimal discount = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Enter full name of new graduate faculty advisor: ");
                    string facAdvisor = Console.ReadLine();

                    GradStudent grad = new GradStudent(first, last, gpa, email, DateTime.Now, discount, facAdvisor);
                    students.Add(grad);
                }
                else
                {
                    // if user enter the wrong email
                    Console.WriteLine($"ERROR: No student {email} created.\n" +
                        $"{studentType} is not valid type.");
                }
            }
            else
            {
                // result when user enter the eight email
                Console.WriteLine($"{email} RECORD FOUND! Can't add student {email}, \n" +
                                    $"Record already exists.");
            }




        }
        private void PrintAllRecords()
        {
            foreach (var student in students)
            {
                Console.WriteLine("Printing all student records in list: ");
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }

        private char GetUserSelection()
        {
            ConsoleKeyInfo keypressed = Console.ReadKey();
            return keypressed.KeyChar;
        }

        private void SaveAllChangesAndQuit()
        {
            WriteDataToOutputFile(); // TODO: write SaveAllChangesAndQuit()
            Environment.Exit(0);
        }

        private void ExitApplicationWithoutSave()
        {
            // ExitWithoutSave();
            // TODD: change to use ExitApplicationWithoutSave()
            Environment.Exit(0);
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine(@"
********************************************
********** Student Database App ************
********************************************
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
[A]dd a student record          (C in CRUD)
[F]ind a student record         (R in CRUD)
[P]rint all records             
[D]elete an existing record     (D in CRUD)
[M]odify an existing changes    (U in CRUD)
[E]xit without saving changes   
[S]ave all changes and quit 
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
");
            Console.Write("Enter user selection: ");
        }

        internal void WriteDataToOutputFile()
        {
            // create the output file details
            StreamWriter outFile = new StreamWriter("OUTPUTFILE.txt");

            Console.WriteLine("Writing data to output file.....");

            foreach (var student in students)
            {
                // using the output file
                outFile.WriteLine(student.ToStringForOutputFile());
                // echo of the content writing to a file
                Console.WriteLine(student.ToStringForOutputFile());
                // Console.WriteLine(student);
            }

            // close the output file
            outFile.Close();

            Console.WriteLine("Done writing data - file has been closed");
        }
    }
}
