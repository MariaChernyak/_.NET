using DL.Implementations;
using DL.Model;
using System.Windows;

namespace WpfApp
{
    public partial class App : Application
    {
        private const string FilePath = @"..\..\students.bin";
        public static FileManager<StudentReport> Manager = new FileManager<StudentReport>(FilePath);
    }
}
