public class Solution {
    public string ReverseParentheses(string s) {
        Stack<char> stack = new Stack<char>();

        foreach (char c in s)
        {
            if (c == ')')
            {
                // If we encounter a closing bracket, we need to reverse the substring
                StringBuilder sb = new StringBuilder();
                while (stack.Peek() != '(')
                {
                    sb.Append(stack.Pop());
                }
                stack.Pop(); // remove the '(' from the stack

                // Push the reversed substring back to the stack
                foreach (char revChar in sb.ToString())
                {
                    stack.Push(revChar);
                }
            }
            else
            {
                // Push the current character to the stack
                stack.Push(c);
            }
        }

        // The result will be in the stack in reversed order
        StringBuilder resultBuilder = new StringBuilder();
        while (stack.Count > 0)
        {
            resultBuilder.Insert(0, stack.Pop());
        }

        return resultBuilder.ToString();
    }
}