using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
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

    }
}
