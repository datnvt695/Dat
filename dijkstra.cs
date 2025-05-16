using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

public class Graph
{
    public const int Max = 100;
    public Vertex[] Vertices = new Vertex[Max];//mảng chứa đỉnh
    public int VertexCount = 0;

    public double[] Distance = new double[Max];//khoảng cách ngắn nhất đã biết từ nguồn đến đỉnh i.
    public int[] Previous = new int[Max];//đỉnh nào đi trước i trong đường dẫn ngắn nhất.
    public bool[] Visited = new bool[Max];//kiểm tra đỉnh i đã được thăm chưa.

    public bool AddVertex(string name, int x, int y)
    {
        for (int i = 0; i < VertexCount; i++)
        {
            if (Vertices[i] != null && Vertices[i].X == x && Vertices[i].Y == y)
            {
                // Tọa độ đã tồn tại, trả về false để báo hiệu lỗi
                return false;
            }
        }

        if (VertexCount >= Max) return false;

        Vertices[VertexCount] = new Vertex(VertexCount, name, x, y);
        VertexCount++;
        return true;
    }

    public void AddEdge(int from, int to)
    {
        if (Vertices[from] == null || Vertices[to] == null || from == to) return;//Bỏ qua các kết nối không hợp lệ hoặc vòng lặp.

        double weight = Vertices[from].DistanceTo(Vertices[to]);//Tính toán khoảng cách bằng công thức Euclid
        Vertices[from].AddEdge(to, weight);//thêm cạnh cho cả hai đỉnh (đồ thị vô hướng)
        Vertices[to].AddEdge(from, weight);
    }

    public void RemoveEdge(int from, int to)
    {
        if (Vertices[from] != null)
            Vertices[from].RemoveEdgeTo(to);  //Xóa 2 hướng của cạnh
        if (Vertices[to] != null)
            Vertices[to].RemoveEdgeTo(from);
    }

    public void RemoveVertex(int id)
    {
        if (Vertices[id] == null) return;

        for (int i = 0; i < Max; i++)  //Đối với mọi đỉnh khác, loại bỏ cạnh trỏ tới đỉnh này.
        {
            if (Vertices[i] != null)
                Vertices[i].RemoveEdgeTo(id);
        }

        Vertices[id] = null;
    }

    public void Dijkstra(int source)
    {
        for (int i = 0; i < Max; i++)//Đặt điều kiện ban đầu: tất cả các khoảng cách đều vô hạn, không có điểm nào được truy cập và không có đỉnh nào trước đó được biết đến.
        {
            Distance[i] = double.MaxValue;
            Previous[i] = -1;
            Visited[i] = false;
        }

        Distance[source] = 0;//Khoảng cách từ nguồn đến chính nó là 0.

        for (int count = 0; count < VertexCount; count++)//thực hiện vòng lặp này tới VertexCount lần, mỗi lần ghé thăm một đỉnh.
        {
            int u = MinDistance();
            if (u == -1) break;  //Chọn đỉnh u gần nhất chưa được thăm. Nếu không tìm thấy, thuật toán sẽ hoàn tất.
            Visited[u] = true;

            Vertex v = Vertices[u];
            for (int i = 0; i < v.EdgeCount; i++)//Nếu tìm thấy đường dẫn ngắn hơn đến đỉnh kề,cập nhật khoảng cách của nó và ghi lại u là đỉnh trước đó.
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
        int index = -1; //Bắt đầu với khoảng cách vô hạn.


        for (int i = 0; i < Max; i++)//Với mỗi thành phố chưa được ghé thăm,tìm thành phố có khoảng cách đã biết ngắn nhất.
        {
            if (Vertices[i] != null && !Visited[i] && Distance[i] < min)
            {
                min = Distance[i];
                index = i;
            }
        }
        return index;//Trả về đỉnh tiếp theo để xử lý trong vòng lặp Dijkstra.
    }

    public string GetPath(int target)
    {
        if (Distance[target] == double.MaxValue)//Nếu khoảng cách đến mục tiêu vẫn vô hạn, không tìm thấy đường đi nào.
            return "Không có đường đi";

        string path = "";
        int current = target;
        while (current != -1)
        {
            path = Vertices[current].Name + " → " + path;  //Bắt đầu từ mục tiêu, quay ngược lại qua mảng Previous[] và xây dựng đường dẫn. Trả về chuỗi có dạng lại như sau: A → B → C
                        current = Previous[current];
        }
        return path.TrimEnd('→', ' ');
    }
}
