public class MyCalendarTwo {
    private SortedDictionary<int, int> timeline;
    public MyCalendarTwo() {
        timeline = new SortedDictionary<int, int>();
    }
    
    public bool Book(int start, int end) {
        if (!timeline.ContainsKey(start)) {
            timeline[start] = 0;
        }
        timeline[start]++;

        
        if (!timeline.ContainsKey(end)) {
            timeline[end] = 0;
        }
        timeline[end]--;
        
        
        int activeEvents = 0;
        foreach (var key in timeline.Keys) {
            activeEvents += timeline[key];
            if (activeEvents >= 3) {
                
                timeline[start]--;
                if (timeline[start] == 0) {
                    timeline.Remove(start);
                }
                timeline[end]++;
                if (timeline[end] == 0) {
                    timeline.Remove(end);
                }
                return false;
            }
        }
        
        return true;
    }
}

/**
 * Your MyCalendarTwo object will be instantiated and called as such:
 * MyCalendarTwo obj = new MyCalendarTwo();
 * bool param_1 = obj.Book(start,end);
 */