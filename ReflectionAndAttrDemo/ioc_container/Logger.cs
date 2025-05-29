using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttrDemo.ioc_container
{
    using System;
    using System.IO;

    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[Console] {message}");
        }
    }

    public class FileLogger : ILogger
    {
        private readonly string _filePath = "log.txt";

        public void Log(string message)
        {
            File.AppendAllText(_filePath, $"[File] {DateTime.Now}: {message}{Environment.NewLine}");
        }
    }

}
