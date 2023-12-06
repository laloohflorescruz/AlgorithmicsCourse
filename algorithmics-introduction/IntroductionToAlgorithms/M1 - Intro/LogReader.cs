using System.Collections;
using System.Collections.Generic;

namespace Module1Intro
{
    // The LogReader produces synthetic data for use in experiments.
    // It simulates a log file with 100,000 log lines and 90,001 different IP adresses.
    class LogReader : IEnumerable<LogLine>
    {
        int counter = 0;

        public IEnumerator<LogLine> GetEnumerator()
        {
            while (counter < 100000)
            {
                yield return new LogLine(counter % 90001);
                counter++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    class LogLine
    {
        int counter;
        public LogLine(int counter)
        {
            this.counter = counter;
        }

        // The return value is not an IP-address, but just a string.
        // The strings will be unique to the extend of the 'counter' parameter.
        public string GetIP()
        {
            return "ip" + counter;
        }
    }
}
