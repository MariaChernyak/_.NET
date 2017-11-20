using System;
using System.Collections.Generic;

namespace ConsoleApp.Model
{
    [Serializable]
    public class StudentReport:IComparable<StudentReport>
    {
        public StudentReport(string name, string lastName, string testName, DateTime testDate, int raiting)
        {
            Name = name;
            LastName = lastName;
            TestName = testName;
            TestDate = testDate;
            Raiting = raiting;
        }

        public StudentReport()
        {
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public int Raiting { get; set; }
        public int Compare(StudentReport x, StudentReport y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            if (y == null)
            {
                throw new ArgumentNullException(nameof(y));
            }
            return x.Raiting.CompareTo(x.Raiting);
        }

        public int CompareTo(StudentReport other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return Raiting.CompareTo(other.Raiting);
        }
    }
}