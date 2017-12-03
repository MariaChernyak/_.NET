using System;

namespace BinaryTreeTests
{
    public class Student : IComparable<Student>
    {
        public Student(string name, string lastName, string testName, int rating)
        {
            Name = name;
            LastName = lastName;
            TestName = testName;
            Rating = rating;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public int Rating { get; set; }

        public int CompareTo(Student other)
        {
            return Rating.CompareTo(other.Rating);
        }
    }
}