using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTests
{
    public class Student:IComparable<Student>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public int Rating { get; set; }

        public int CompareTo(Student other)
        {
            return Rating.CompareTo(other.Rating);
        }
        public Student(string name, string lastName, string testName, int rating)
        {
            Name = name;
            LastName = lastName;
            TestName = testName;
            Rating = rating;
        }
    }
}
