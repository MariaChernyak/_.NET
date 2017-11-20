using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Model;
using DL.Implementations;
using BinaryTree;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var filepath = @"D:\NET\_.NET\Lab2\ConsoleApp\students.bin";
            var tree = new BinaryTree<StudentReport>();
            var st1 = new StudentReport("Petr", "Vasiliev", "Test1", DateTime.Now, 5);
            tree.Add(st1);
            var st2 = new StudentReport("Inga", "Vasilieva", "Test1", DateTime.Now, 3);
            tree.Add(st2);
            var manager = new FileManager<StudentReport>(filepath);
            var a2 = manager.GetList(p=>p,2,false);
        }
    }
}
