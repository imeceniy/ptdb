using System;

namespace DataGrabber
{
    class Program
    {
        public static void Main()
        {
            var reader = new FileReader();
            reader.ReadFile(@"D:\Work\Andrew\8T13_9.CK");
            foreach (var thing in reader.Things)
            {
                Console.WriteLine($"Thing number {thing.Key}:");
                foreach (var section in thing.Value)
                {
                    Console.WriteLine($"Section {section.Key}:");
                    foreach (var data in section.Value)
                    {
                        Console.WriteLine($"\t {data.Key}: {data.Value}");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}
