using System;

namespace XmlTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            XmlReaderTest.Read();
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
