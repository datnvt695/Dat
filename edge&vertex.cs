using System;

public class Vertex
{
    public int Id;
    public string Name;
    public int X, Y;
    public Edge[] Edges = new Edge[100];
    public int EdgeCount = 0;

    public Vertex(int id, string name, int x, int y)
    {
        Id = id;
        Name = name;
        X = x;
        Y = y;
    }

    public void AddEdge(int to, double weight)
    {
        for (int i = 0; i < EdgeCount; i++)
            if (Edges[i].To == to) return;
        Edges[EdgeCount++] = new Edge(to, weight);
    }

    public void RemoveEdgeTo(int to)
    {
        for (int i = 0; i < EdgeCount; i++)
        {
            if (Edges[i].To == to)
            {
                for (int j = i; j < EdgeCount - 1; j++)
                    Edges[j] = Edges[j + 1];
                EdgeCount--;
                break;
            }
        }
    }

    public double DistanceTo(Vertex other)
    {
        int dx = X - other.X;
        int dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}

public class Edge
{
    public int To;
    public double Weight;

    public Edge(int to, double weight)
    {
        To = to;
        Weight = weight;
    }
}
