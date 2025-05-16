using System;

public class Vertex
{
    public int Id;
    public string Name;
    public int X, Y;
    public Edge[] Edges = new Edge[100]; //Mảng chứa cạnh, tối đa 100 thành phố
    public int EdgeCount = 0;//Đếm số cạnh tồn tại của thành phố

    public Vertex(int id, string name, int x, int y)// khởi tạo đỉnh (thành phố) mới 
    {
        Id = id;// Thứ tự 0,1,2,3,...
        Name = name;//Tên thành phố
        X = x; // Tọa độ X,Y
        Y = y;
    }

    public void AddEdge(int to, double weight)
    {
        for (int i = 0; i < EdgeCount; i++)
            if (Edges[i].To == to) return; //Kiểm tra xem cạnh đến đỉnh mục tiêu đã tồn tại chưa. Nếu có, không làm gì cả (ngăn chặn trùng lặp).
        Edges[EdgeCount++] = new Edge(to, weight);//Thêm một cạnh mới từ đỉnh này đến đỉnh khác ('to' là chỉ số của thành phố cần nối đến ), đồng thời lưu trọng số(khoảng cách)
    }

    public void RemoveEdgeTo(int to)
    {
        for (int i = 0; i < EdgeCount; i++)//Lặp qua các cạnh hiện tại để tìm cạnh đi tới đỉnh đó
        {
            if (Edges[i].To == to)//Nếu tìm thấy cạnh thì tiến hành xóa
            {
                for (int j = i; j < EdgeCount - 1; j++)
                    Edges[j] = Edges[j + 1];//Dịch chuyển phần còn lại của mảng sang trái để lấp đầy khoảng trống của phần tử đã xóa.
                EdgeCount--;
                break;
            }
        }
    }

    public double DistanceTo(Vertex other)
    {
        int dx = X - other.X;
        int dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);//Trả về khoảng cách Euclid đến một thành phố khác bằng cách sử dụng tọa độ của thành phố đó.
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
