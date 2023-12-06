using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Module1Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            var lineCount = ReadAllLogs();
            Console.WriteLine("Number of lines: " + lineCount);
            Console.WriteLine("Time elabsed: {0:0.00}", Math.Round(stopWatch.ElapsedMilliseconds / 1000.0, 2));

            stopWatch.Restart();
            var ipCount = CountUniqueIPs();
            Console.WriteLine("Number of unique IPs: " + ipCount);
            Console.WriteLine("Time elabsed: {0:0.0}", Math.Round(stopWatch.ElapsedMilliseconds / 1000.0, 1));

            Console.ReadLine();
        }

        static int ReadAllLogs()
        {
            var logReader = new LogReader();
            var linesSeen = 0;
            foreach (var line in logReader)
            {
                var ip = line.GetIP();
                linesSeen++;
            }
            return linesSeen;
        }

        static int CountUniqueIPs()
        {
            var logReader = new LogReader();
            var ipsSeen = new List<string>();
            foreach (var logLine in logReader)
            {
                var ip = logLine.GetIP();
                if (!ipsSeen.Contains(ip))
                    ipsSeen.Add(ip);
            }
            return ipsSeen.Count;
        }
    }
}
