public class Solution {
   public int MaximumGain(string s, int x, int y) {
        
        char a = 'a';
        char b = 'b';
        if(y > x) {
            (a, b) = (b, a);
            (x, y) = (y, x);
        }
        
        int score = 0;
        var forwardStack = new Stack<char>();
        foreach (var ch in s)
            if(forwardStack.Count != 0 && ch == b && forwardStack.Peek() == a) {
                score += x;
                forwardStack.Pop();
            }
            else forwardStack.Push(ch);
        
        var reverseStack = new Stack<char>();
        while (forwardStack.Count != 0)
            if(reverseStack.Count != 0 && reverseStack.Peek() == a && forwardStack.Peek() == b) { 
                score += y;
                forwardStack.Pop();
                reverseStack.Pop();
            } else reverseStack.Push(forwardStack.Pop());

        return score;
    }
}
