import UIKit

class ViewController: UIViewController {

    @IBOutlet weak var myButton: UIButton!
    @IBOutlet weak var counterLabel1: UILabel!
    @IBOutlet weak var counterTimeLabel1: UILabel!
    @IBOutlet weak var counterLabel2: UILabel!
    @IBOutlet weak var counterTimeLabel2: UILabel!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        reset();
    }
    
    func reset() {
        counterLabel1.text = "-";
        counterTimeLabel1.text = "-";
        counterLabel2.text = "-";
        counterTimeLabel2.text = "-";
    }

    @IBAction func runTests(sender: UIButton) {
        reset();
        myButton.enabled = false;
        myButton.setTitle("Reading...", forState: UIControlState.Disabled);
        dispatch_async(dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0))
        {
            var ipCounter = IpCounter();
            var start = NSDate();
            var numLogLines = ipCounter.readAllLogs();
            var end = NSDate();
            var diff = end.timeIntervalSinceDate(start);
            dispatch_async(dispatch_get_main_queue()) {
                self.counterLabel1.text = String(numLogLines);
                self.counterTimeLabel1.text = String(format: "(%.1f s)", diff);
            }
            
            start = NSDate();
            var count = ipCounter.countUniqueIPs();
            end = NSDate();
            diff = end.timeIntervalSinceDate(start);
            dispatch_async(dispatch_get_main_queue()) {
                self.counterLabel2.text = String(count);
                self.counterTimeLabel2.text = String(format: "(%.1f s)", diff);
                self.myButton.enabled = true;
            }
        }
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    override func prefersStatusBarHidden() -> Bool {
        return true
    }
}

