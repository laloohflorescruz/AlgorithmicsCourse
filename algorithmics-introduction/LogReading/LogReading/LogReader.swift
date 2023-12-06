import Foundation

/*
 * The LogReader produces synthetic data for use in experiments.
 * It simulates a log file with 100,000 log lines and 90,001 different IP adresses.
 */
class LogReader {
    var counter = 0;
    
    func GetLogLines() -> [LogLine] {
        var logLines = [LogLine]();
        for counter in 1...100000
        {
            logLines.append(LogLine(counter: counter % 90001));
        }
        return logLines;
    }
}

class LogLine {
    var counter = 0
    init(counter: Int)
    {
        self.counter = counter;
    }
   
    // The return value is not an IP-address, but just a string.
    // The strings will be unique to the extend of the 'counter' parameter.
    func getIP() -> String
    {
        return "ip" + String(counter);
    }
}
