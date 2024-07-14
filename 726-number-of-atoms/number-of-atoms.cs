public class Solution {
    public string CountOfAtoms(string formula) {
        int n = formula.Length;
        Stack<Dictionary<string, int>> stack = new Stack<Dictionary<string, int>>();
        stack.Push(new Dictionary<string, int>());
        
        for (int i = 0; i < n;) {
            if (formula[i] == '(') {
                stack.Push(new Dictionary<string, int>());
                i++;
            } else if (formula[i] == ')') {
                Dictionary<string, int> top = stack.Pop();
                i++;
                int start = i;
                while (i < n && char.IsDigit(formula[i])) i++;
                int multiplier = start < i ? int.Parse(formula.Substring(start, i - start)) : 1;
                
                foreach (var item in top) {
                    if (stack.Peek().ContainsKey(item.Key)) {
                        stack.Peek()[item.Key] += item.Value * multiplier;
                    } else {
                        stack.Peek()[item.Key] = item.Value * multiplier;
                    }
                }
            } else {
                int start = i++;
                while (i < n && char.IsLower(formula[i])) i++;
                string name = formula.Substring(start, i - start);
                start = i;
                while (i < n && char.IsDigit(formula[i])) i++;
                int count = start < i ? int.Parse(formula.Substring(start, i - start)) : 1;
                
                if (stack.Peek().ContainsKey(name)) {
                    stack.Peek()[name] += count;
                } else {
                    stack.Peek()[name] = count;
                }
            }
        }
        
        Dictionary<string, int> finalCount = stack.Pop();
        StringBuilder sb = new StringBuilder();
        foreach (var item in finalCount.OrderBy(kvp => kvp.Key)) {
            sb.Append(item.Key);
            if (item.Value > 1) {
                sb.Append(item.Value);
            }
        }
        
        return sb.ToString();
    }
}
