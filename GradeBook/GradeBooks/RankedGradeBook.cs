using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var numberOfStudents = Students.Count;
          
            if (numberOfStudents < 5)
            {
                throw new InvalidOperationException();
            }
            var numberOfStudentsGreaterThanGivenAverageGrade = 0; 
            foreach (var student in Students)
            {
                if (student.AverageGrade >= averageGrade )
                {
                    numberOfStudentsGreaterThanGivenAverageGrade++;
                }
            }
            var percentage = numberOfStudentsGreaterThanGivenAverageGrade * 100 / numberOfStudents;
            if (percentage <= 20)
            {
                return 'A';
            }
            if (percentage > 20 && percentage <= 40)
            {
                return 'B';
            }
            if (percentage > 40 && percentage <= 60)
            {
                return 'C';
            }
            if (percentage > 60 && percentage <= 80)
            {
                return 'D';
            }
            return 'F';
        }

        public override void CalculateStatistics()
        {
            var numberOfStudents = Students.Count;
            if (numberOfStudents < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly " +
                    "calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            var numberOfStudents = Students.Count;
            if (numberOfStudents < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly " +
                    "calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
