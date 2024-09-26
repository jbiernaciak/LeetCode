public class MyCalendar {
 
    private class Node {
        public int start;
        public int end;
        public Node left;
        public Node right;
        
        public Node(int start, int end) {
            this.start = start;
            this.end = end;
            left = null;
            right = null;
        }
    }
    
    private Node root;

    public MyCalendar() {
        root = null;
    }
    
    public bool Book(int start, int end) {
        if (root == null) {
            root = new Node(start, end);  
            return true;
        }
        return Insert(root, start, end);
    }

    private bool Insert(Node node, int start, int end) {
       
        if (end <= node.start) {
            if (node.left == null) {
                node.left = new Node(start, end);  
                return true;
            } else {
                return Insert(node.left, start, end);
            }
        }
        
        else if (start >= node.end) {
            if (node.right == null) {
                node.right = new Node(start, end);  
                return true;
            } else {
                return Insert(node.right, start, end);
            }
        }
       
        else {
            return false;
        }
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */