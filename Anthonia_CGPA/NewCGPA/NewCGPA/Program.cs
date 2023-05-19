using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace NewCGPA
{
    internal class Program
    {
        static void Main(string[] args)
        {
                 string courseCode;
                 int courseUnit;
                 int courseWeightPoint;
                 string remark;
                 int courseScore;
                 bool isAnotherCourse;
                 int gradeUnit;
                 int courseCounter = 1;
                 char charact;
          
      



            try
                {
                    Console.Clear();
                    Console.Write("Enter your full name: ");
                    Console.ReadLine();
                    Console.WriteLine();
                
                    var studentCourse = new List<string>();//course & code
                    var courseScores = new List<int>();//score
                    var courseUnits = new List<int>();// unit of course
                    var courseGrade = new List<char>();// cha A B C D E
                    var courseWeight = new List<int>();// weight point 
                    var courseGradeUnit = new List<int>();//unit passed
                    var courseRemark = new List<string>();//v.g excell good pass fail
                    var unitTimesPoint = new List<int>();//unit * grunit
                    


                                                isAnotherCourse = true;

                         while (isAnotherCourse)
                             {
                   
                                    Console.Write($"Enter your course code:  ");
                                    courseCode = Console.ReadLine();
                                    studentCourse.Add(courseCode);
                    

                                    Console.Write($"Enter your course unit:  ");
                                    courseUnit = Convert.ToInt32(Console.ReadLine());
                                    courseUnits.Add(courseUnit);

                                    Console.Write($"Enter your course score:  ");
                                    courseScore = Convert.ToInt32(Console.ReadLine());
                                    courseScores.Add(courseScore);
                                    gradeUnit = GradeUnit(courseScore);
                                    courseGradeUnit.Add(gradeUnit);
                                    charact = CalcChar(courseScore);        //grade
                                    courseGrade.Add(charact);
                                    remark = CalcRemark(courseScore);
                                    courseRemark.Add(remark);
                                    courseWeightPoint = CalcWeightPoint();
                                    unitTimesPoint.Add(courseWeightPoint);
                    
                   
                   
                                    Console.WriteLine("Enter y for another course, any key to display table data: ");
                                    char choice = Convert.ToChar(Console.ReadLine());

                    

                                    if (choice == 'y')
                                    {
                                        Console.Clear();
                                        isAnotherCourse = true;
                                        courseCounter++;
                                    }
                                    else if (choice == 'n')
                                    {
                                        isAnotherCourse = false;
                                        Console.Clear();
                                    }else
                                    {
                   
                                        isAnotherCourse = false;
                                    }
                                    Console.WriteLine();
                         }

                int TotalGradeUnits()
                {
                    int totalGradeUnits = 0;

                    for (int i = 0; i < courseCounter; i++)
                    {
                        totalGradeUnits += courseUnits[i];
                    }
                    return totalGradeUnits;
                 }
                    int totalGradeUnit = TotalGradeUnits();


                int TotalWeightPoints()
                {
                    int totalWeightPoints = 0;

                    for (int i = 0; i < courseCounter; i++)
                    {
                        totalWeightPoints += unitTimesPoint[i];
                    }
                    return totalWeightPoints;
                }
                    int totalWeightPoints = TotalWeightPoints();


                int TotalGradeUnitPassed()
                {
                    int gradeUnitPassed = 0;

                    for (int i = 0; i < courseCounter; i++)
                    {
                        gradeUnitPassed += courseGradeUnit[i];

                    }
                    return gradeUnitPassed;
                }
                     int gradeUnitsPassed = TotalGradeUnitPassed();


                int CalcWeightPoint()
                {
                    int courseWeightPoint = 0;

                        courseWeightPoint = gradeUnit * courseUnit;
                    
                    return courseWeightPoint;
                }
 
                 double GPA = Math.Round((double)totalWeightPoints / gradeUnitsPassed, 2);
                    
                  
                
                
                Console.WriteLine("Student course data: ");
                Console.WriteLine();

                List<Data> table = new List<Data>()

                {
                    new Data() { S1 = studentCourse[0], S2 = courseUnits[0], S3 = courseGrade[0], S4 = courseGradeUnit[0], S5 = unitTimesPoint[0], S6 = courseRemark[0] },
                    new Data() { S1 = studentCourse[1], S2 = courseUnits[1], S3 = courseGrade[1], S4 = courseGradeUnit[1], S5 = unitTimesPoint[1], S6 = courseRemark[1] },
                    new Data() { S1 = studentCourse[2], S2 = courseUnits[2], S3 = courseGrade[2], S4 = courseGradeUnit[2], S5 = unitTimesPoint[2], S6 = courseRemark[2] },
                    new Data() { S1 = studentCourse[3], S2 = courseUnits[3], S3 = courseGrade[3], S4 = courseGradeUnit[3], S5 = unitTimesPoint[3], S6 = courseRemark[3] },
                    new Data() { S1 = studentCourse[4], S2 = courseUnits[4], S3 = courseGrade[4], S4 = courseGradeUnit[4], S5 = unitTimesPoint[4], S6 = courseRemark[4] }
                };


                var lineSep = "|--------------------|-------------------|------------|-----------------|----------------|-------------|";
                var header = $"|{"COURSE & CODE",15}     |{"COURSE UNIT",15}    |{"GRADE",10}  |{"GRADE-UNIT",12}     |{"WEIGHT Pt",15} |{"REMARK",12} |";
                var footer = "|--------------------|-------------------|------------|-----------------|----------------|-------------|";
                Console.WriteLine(lineSep);
                Console.WriteLine(header);
                Console.WriteLine(lineSep);

                foreach (var data in table)
                {
                    
                    var line = $"|{data.S1,-15}     |{data.S2,-15}    | {data.S3,-10} | {data.S4,-12}    | {data.S5,-15}| {data.S6,-12}|";
                    Console.WriteLine(line);
                    Console.WriteLine(footer); 
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Total Course Unit Registered is {totalGradeUnit}");
                Console.WriteLine();
                Console.WriteLine($"The Total Course Unit Passed is {gradeUnitsPassed}");
                Console.WriteLine();
                Console.WriteLine($"The total weight point is {totalWeightPoints}");
                Console.WriteLine();
                Console.WriteLine($"Your GPA is = {GPA}");
                    

            }
            catch (Exception e)
            {
                    Console.WriteLine("Invalid Input: " + e.Message);
                    Environment.Exit(0);
            }
        }
      
          static int GradeUnit(int courseScore)
          {
            int gradeUnit;
            if (courseScore >= 70 && courseScore <= 100)
            {
                gradeUnit = 5;
            }
            else if (courseScore >= 60 && courseScore <= 69)
            {
                gradeUnit = 4;
            }
            else if (courseScore >= 50 && courseScore <= 59)
            {
                gradeUnit = 3;
            }
            else if (courseScore >= 45 && courseScore <= 49)
            {
                gradeUnit = 2;
            }
            else if (courseScore >= 40 && courseScore <= 44)
            {
                gradeUnit = 1;
            }
            else if (courseScore >= 0 && courseScore <= 39)
            {
                gradeUnit = 0;
            }else 
            {
                gradeUnit = 0;
            }
            return gradeUnit;
          }
         static char CalcChar(int courseScore)
         {
            char charact;

            if (courseScore >= 70 && courseScore <= 100)
            {
                charact = 'A';
            }
            else if (courseScore >= 60 && courseScore <= 69)
            {
                charact = 'B';
            }
            else if (courseScore >= 50 && courseScore <= 59)
            {
                charact = 'C';
            }
            else if (courseScore >= 45 && courseScore <= 49)
            {
                charact = 'D';
            }
            else if (courseScore >= 40 && courseScore <= 44)
            {
                charact = 'E';
            }
            else if (courseScore >= 0 && courseScore <= 39)
            {
                charact = 'F';
            }
            else
            {
                charact = 'F';
            }
            return charact;
           
         } 
        static string CalcRemark(int courseScore)
        {
            string remark;
            if (courseScore >= 70 && courseScore <= 100)
            {
                remark = "Excellent";
            }
            else if (courseScore >= 60 && courseScore <= 69)
            {
                remark = "Very Good";
            }
            else if (courseScore >= 50 && courseScore <= 59)
            {
                remark = "Good";
            }
            else if (courseScore >= 45 && courseScore <= 49)
            {
                remark = "Fair";
            }
            else if (courseScore >= 40 && courseScore <= 44)
            {
                remark = "Pass";
            }
            else if (courseScore >= 0 && courseScore <= 39)
            {
                remark = "Fail";
            }
            else
            {
                remark = "Invalid input!";
            }
            return remark;

        }

    }
}
            

 

