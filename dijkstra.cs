using System;

public class Graph
{
    public const int Max = 100;
    public Vertex[] Vertices = new Vertex[Max];
    public int VertexCount = 0;

    public double[] Distance = new double[Max];
    public int[] Previous = new int[Max];
    public bool[] Visited = new bool[Max];

    public void AddVertex(string name, int x, int y)
    {
        if (VertexCount >= Max) return;
        Vertices[VertexCount] = new Vertex(VertexCount, name, x, y);
        VertexCount++;
    }

    public void AddEdge(int from, int to)
    {
        if (Vertices[from] == null || Vertices[to] == null || from == to) return;

        double weight = Vertices[from].DistanceTo(Vertices[to]);
        Vertices[from].AddEdge(to, weight);
        Vertices[to].AddEdge(from, weight);
    }

    public void RemoveEdge(int from, int to)
    {
        if (Vertices[from] != null)
            Vertices[from].RemoveEdgeTo(to);
        if (Vertices[to] != null)
            Vertices[to].RemoveEdgeTo(from);
    }

    public void RemoveVertex(int id)
    {
        if (Vertices[id] == null) return;

        for (int i = 0; i < Max; i++)
        {
            if (Vertices[i] != null)
                Vertices[i].RemoveEdgeTo(id);
        }

        Vertices[id] = null;
    }

    public void Dijkstra(int source)
    {
        for (int i = 0; i < Max; i++)
        {
            Distance[i] = double.MaxValue;
            Previous[i] = -1;
            Visited[i] = false;
        }

        Distance[source] = 0;

        for (int count = 0; count < VertexCount; count++)
        {
            int u = MinDistance();
            if (u == -1) break;

            Visited[u] = true;

            Vertex v = Vertices[u];
            for (int i = 0; i < v.EdgeCount; i++)
            {
                int to = v.Edges[i].To;
                double weight = v.Edges[i].Weight;

                if (!Visited[to] && Distance[u] + weight < Distance[to])
                {
                    Distance[to] = Distance[u] + weight;
                    Previous[to] = u;
                }
            }
        }
    }

    private int MinDistance()
    {
        double min = double.MaxValue;
        int index = -1;

        for (int i = 0; i < Max; i++)
        {
            if (Vertices[i] != null && !Visited[i] && Distance[i] < min)
            {
                min = Distance[i];
                index = i;
            }
        }
        return index;
    }

    public string GetPath(int target)
    {
        if (Distance[target] == double.MaxValue)
            return "No path";

        string path = "";
        int current = target;
        while (current != -1)
        {
            path = Vertices[current].Name + " → " + path;
            current = Previous[current];
        }
        return path.TrimEnd('→', ' ');
    }
}
