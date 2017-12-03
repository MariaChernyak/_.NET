using BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Int32PostorderTest()
        {
            var tree = new BinaryTree<int>();
            tree.Add(8);
            tree.Add(6);
            tree.Add(10);
            tree.Add(4);
            tree.Add(7);
            tree.Add(8);
            tree.Add(7);
            tree.Add(11);
            tree.Add(9);
            var mas = new[] {4, 7, 8, 7, 6, 9, 11, 10, 8};
            var index = 0;
            var isRight = true;
            foreach (var node in tree.Postorder())
            {
                if (mas[index] != node)
                    isRight = false;
                index++;
            }
            Assert.IsTrue(isRight);
        }

        [TestMethod]
        public void Int32PreorderTest()
        {
            var tree = new BinaryTree<int>();
            tree.Add(8);
            tree.Add(6);
            tree.Add(10);
            tree.Add(4);
            tree.Add(7);
            tree.Add(8);
            tree.Add(7);
            tree.Add(11);
            tree.Add(9);

            var mas = new[] {8, 6, 4, 7, 7, 8, 10, 9, 11};
            var index = 0;
            var isRight = true;
            foreach (var node in tree.Preorder())
            {
                if (mas[index] != node)
                    isRight = false;
                index++;
            }
            Assert.IsTrue(isRight);
        }

        [TestMethod]
        public void Int32InorderTest()
        {
            var tree = new BinaryTree<int>();
            tree.Add(8);
            tree.Add(6);
            tree.Add(10);
            tree.Add(4);
            tree.Add(7);
            tree.Add(8);
            tree.Add(7);
            tree.Add(11);
            tree.Add(9);

            var mas = new[] {4, 6, 7, 7, 8, 8, 9, 10, 11};
            var index = 0;
            var isRight = true;
            foreach (var node in tree.Inorder())
            {
                if (mas[index] != node)
                    isRight = false;
                index++;
            }
            Assert.IsTrue(isRight);
        }

        [TestMethod]
        public void StringPostorderTest()
        {
            var tree = new BinaryTree<string>();
            tree.Add("de");
            tree.Add("bc");
            tree.Add("bb");
            tree.Add("bd");
            tree.Add("ef");
            tree.Add("ea");
            tree.Add("yabc");

            var mas = new[] {"bb", "bd", "bc", "ea", "yabc", "ef", "de"};
            var index = 0;
            var isRight = true;
            foreach (var node in tree.Postorder())
            {
                if (mas[index] != node)
                    isRight = false;
                index++;
            }
            Assert.IsTrue(isRight);
        }

        [TestMethod]
        public void StringPreorderTest()
        {
            var tree = new BinaryTree<string>();
            tree.Add("de");
            tree.Add("bc");
            tree.Add("bb");
            tree.Add("bd");
            tree.Add("ef");
            tree.Add("ea");
            tree.Add("yabc");

            var mas = new[] {"de", "bc", "bb", "bd", "ef", "ea", "yabc"};
            var index = 0;
            var isRight = true;
            foreach (var node in tree.Preorder())
            {
                if (mas[index] != node)
                    isRight = false;
                index++;
            }
            Assert.IsTrue(isRight);
        }

        [TestMethod]
        public void StringInorderTest()
        {
            var tree = new BinaryTree<string>();
            tree.Add("de");
            tree.Add("bc");
            tree.Add("bb");
            tree.Add("bd");
            tree.Add("ef");
            tree.Add("ea");
            tree.Add("yabc");

            var mas = new[] {"bb", "bc", "bd", "de", "ea", "ef", "yabc"};
            var index = 0;
            var isRight = true;
            foreach (var node in tree.Inorder())
            {
                if (mas[index] != node)
                    isRight = false;
                index++;
            }
            Assert.IsTrue(isRight);
        }

        [TestMethod]
        public void StudentPostorderTest()
        {
            var tree = new BinaryTree<Student>();
            var student1 = new Student("Bob", "Abc", "Math", 8);
            var student2 = new Student("Boris", "Abc", "Math", 6);
            var student3 = new Student("Martin", "Abc", "Math", 4);
            var student4 = new Student("Ivan", "Abc", "Math", 7);
            var student5 = new Student("Max", "Abc", "Math", 10);
            var student6 = new Student("Arthur", "Abc", "Math", 9);
            var student7 = new Student("Nikolai", "Abc", "Math", 11);
            tree.Add(student1);
            tree.Add(student2);
            tree.Add(student3);
            tree.Add(student4);
            tree.Add(student5);
            tree.Add(student6);
            tree.Add(student7);

            var mas = new[] {student3, student4, student2, student6, student7, student5, student1};
            var index = 0;
            var isRight = true;
            foreach (var node in tree.Postorder())
            {
                if (mas[index] != node)
                    isRight = false;
                index++;
            }
            Assert.IsTrue(isRight);
        }

        [TestMethod]
        public void StudentPreorderTest()
        {
            var tree = new BinaryTree<Student>();
            var student1 = new Student("Bob", "Abc", "Math", 8);
            var student2 = new Student("Boris", "Abc", "Math", 6);
            var student3 = new Student("Martin", "Abc", "Math", 4);
            var student4 = new Student("Ivan", "Abc", "Math", 7);
            var student5 = new Student("Max", "Abc", "Math", 10);
            var student6 = new Student("Arthur", "Abc", "Math", 9);
            var student7 = new Student("Nikolai", "Abc", "Math", 11);
            tree.Add(student1);
            tree.Add(student2);
            tree.Add(student3);
            tree.Add(student4);
            tree.Add(student5);
            tree.Add(student6);
            tree.Add(student7);

            var mas = new[] {student1, student2, student3, student4, student5, student6, student7};
            var index = 0;
            var isRight = true;
            foreach (var node in tree.Preorder())
            {
                if (mas[index] != node)
                    isRight = false;
                index++;
            }
            Assert.IsTrue(isRight);
        }

        [TestMethod]
        public void StudentInorderTest()
        {
            var tree = new BinaryTree<Student>();
            var student1 = new Student("Bob", "Abc", "Math", 8);
            var student2 = new Student("Boris", "Abc", "Math", 6);
            var student3 = new Student("Martin", "Abc", "Math", 4);
            var student4 = new Student("Ivan", "Abc", "Math", 7);
            var student5 = new Student("Max", "Abc", "Math", 10);
            var student6 = new Student("Arthur", "Abc", "Math", 9);
            var student7 = new Student("Nikolai", "Abc", "Math", 11);
            tree.Add(student1);
            tree.Add(student2);
            tree.Add(student3);
            tree.Add(student4);
            tree.Add(student5);
            tree.Add(student6);
            tree.Add(student7);

            var mas = new[] {student3, student2, student4, student1, student6, student5, student7};
            var index = 0;
            var isRight = true;
            foreach (var node in tree.Inorder())
            {
                if (mas[index].CompareTo(node) != 0)
                    isRight = false;
                index++;
            }
            Assert.IsTrue(isRight);
        }

        [TestMethod]
        public void PointPreorderTest()
        {
            var comparator = new PointCorparator();
            var tree = new BinaryTree<Point>(comparator);
            var point1 = new Point(8, 2);
            var point2 = new Point(6, 3);
            var point3 = new Point(4, 1);
            var point4 = new Point(7, 0);
            var point5 = new Point(10, 5);
            var point6 = new Point(9, 3);
            var point7 = new Point(11, 2);
            tree.Add(point1);
            tree.Add(point2);
            tree.Add(point3);
            tree.Add(point4);
            tree.Add(point5);
            tree.Add(point6);
            tree.Add(point7);

            var mas = new[] {point1, point2, point3, point4, point5, point6, point7};
            var index = 0;
            var isRight = true;

            foreach (var node in tree.Postorder())
            {
                if (comparator.Compare(mas[index], node) != 0)
                    isRight = false;
                index++;
            }
            Assert.IsTrue(isRight);
        }
    }
}