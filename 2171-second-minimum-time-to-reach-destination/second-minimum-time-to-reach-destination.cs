public class Solution {
    public int SecondMinimum(int n, int[][] edges, int time, int change) {
        List<int>[] graph = new List<int>[n + 1];
        int[] count = new int[n + 1];
        (int first, int second)[] dist = new (int, int)[n + 1];
        
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<int>();
            dist[i] = (int.MaxValue, int.MaxValue);
        }
        
        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }
        
        Queue<(int, int)> q = new Queue<(int, int)>();
        q.Enqueue((1, 0));
        dist[1] = (0, int.MaxValue);
        
        while (q.Count > 0)
        {
            int size = q.Count;
            
            for (int i = 0; i < size; i++)
            {
                (int v, int t) = q.Dequeue();
                
                foreach (var u in graph[v])
                {
                    bool isGreen = ((t / change) % 2 == 0);
                    int newTime = t + time + (isGreen ? 0 : change - t % change);
                    
                    if (dist[u].first == int.MaxValue)
                    {
                        dist[u].first = newTime;
                        q.Enqueue((u, newTime));
                    }
                    else if (newTime > dist[u].first && dist[u].second == int.MaxValue)
                    {
                        dist[u].second = newTime;
                        q.Enqueue((u, newTime));
                    }
                }
            }
        }
        
        return dist[n].second;
    }
}