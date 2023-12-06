import Foundation

class IpCounter
{
    func readAllLogs() -> Int
    {
        var reader = LogReader();
        var linesSeen = 0;
        for logLine in reader.GetLogLines() {
            logLine.getIP();
            linesSeen++;
        }
        return linesSeen;
    }
    
    func countUniqueIPs() -> Int {
        var reader = LogReader();
        var ipsSeen = NSMutableSet();
        for logLine in reader.GetLogLines() {
            var ip = logLine.getIP();
            if(!ipsSeen.containsObject(ip)) {
                ipsSeen.addObject(ip);
            }
        }
        return ipsSeen.count;
    }
}