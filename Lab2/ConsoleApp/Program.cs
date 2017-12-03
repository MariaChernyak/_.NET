using System;
using DL.Implementations;
using DL.Model;

namespace ConsoleApp
{
    internal class Program
    {
        private const string FilePath = @"D:\NET\_.NET\Lab2\ConsoleApp\students.bin";
        private static FileManager<StudentReport> _manager;

        public static void Main(string[] args)
        {
            _manager = new FileManager<StudentReport>(FilePath);
            while (true)
            {
                Console.WriteLine("enter c - Create new Student");
                Console.WriteLine("enter s - show all students");
                Console.WriteLine("enter z - save data ");
                Console.WriteLine("enter e - exit program");

                var r = Console.ReadLine();
                switch (r)
                {
                    case "c":
                        CreateStudent();
                        break;
                    case "s":
                        ShowAll();
                        break;
                    case "e": return;
                    case "z":
                        SaveData();
                        break;
                }
                Console.Clear();
            }
        }

        private static void SaveData()
        {
            Console.Clear();
            _manager.Save();
            Console.WriteLine("save success");
            Console.ReadKey();
        }

        private static void ShowAll()
        {
            var tempList = _manager.GetList();
            while (true)
            {
                Console.Clear();
                foreach (var item in tempList)
                    Console.WriteLine(item.ToString());
                Console.WriteLine("enter p - parametres for search");
                Console.WriteLine("e - ../");
                var result = Console.ReadLine();
                switch (result)
                {
                    case "e": return;
                    case "p":
                        ShowByParametres();
                        break;
                }
            }
        }

        private static void ShowByParametres()
        {
            int count;
            Console.Clear();
            Console.WriteLine("enter 1:name, 2:last name, 3:test name, 4:date, 5:raiting");
            var searchParam = Console.ReadLine();
            Console.WriteLine("enter +/- to asc/desc sort");
            var asc = Console.ReadLine();
            Console.WriteLine("enter count");
            int.TryParse(Console.ReadLine(), out count);
            if (count == 0) count = 10;
            foreach (var studentReport in _manager.GetList<object>(p =>
            {
                switch (searchParam)
                {
                    case "1": return p.Name;
                    case "2": return p.LastName;
                    case "3": return p.TestName;
                    case "4": return p.TestDate;
                    case "5": return p.Raiting;
                    default: return p;
                }
            }, count, asc == "+"))
                Console.WriteLine(studentReport.ToString());
            Console.ReadKey();
        }

        private static void CreateStudent()
        {
            Console.Clear();
            try
            {
                InputStudent();
            }
            catch (Exception)
            {
                Console.WriteLine("no valid data");
                Console.ReadKey();
                InputStudent();
            }
        }

        private static void InputStudent()
        {
            Console.Clear();
            Console.WriteLine("input Name:");
            var name = Console.ReadLine();
            Console.WriteLine("input Second Name:");
            var secondName = Console.ReadLine();
            Console.WriteLine("input test name:");
            var test = Console.ReadLine();
            Console.WriteLine("input date of test (dd/mm/yyyy):");
            var date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("input rating:");
            var rating = int.Parse(Console.ReadLine());
            _manager.Add(new StudentReport(name, secondName, test, date, rating));
        }
    }
}