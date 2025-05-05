using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        Graph graph = new Graph();
        int source = -1, target = -1;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnAddCity_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên thành phố.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tọa độ X và Y.", "Thiếu tọa độ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox2.Text.Trim(), out int x) || !int.TryParse(textBox3.Text.Trim(), out int y))
            {
                MessageBox.Show("Tọa độ phải là số nguyên!", "Lỗi Định Dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (x < 0 || x > 600 || y < 0 || y > 400)
            {
                MessageBox.Show("Tọa độ vượt quá giới hạn cho phép (x: 0–600, y: 0–400).", "Lỗi Tọa Độ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!graph.AddVertex(name, x, y))
            {
                MessageBox.Show("Tọa độ đã tồn tại! Vui lòng nhập tọa độ khác.", "Trùng Tọa Độ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            panel1.Invalidate();  // Cập nhật lại panel để vẽ thành phố mới
        }

        private void UpdateComboBoxes()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            for (int i = 0; i < Graph.Max; i++)
            {
                if (graph.Vertices[i] != null)
                {
                    string item = $"{i} - {graph.Vertices[i].Name}";
                    comboBox1.Items.Add(item);
                    comboBox2.Items.Add(item);
                }
            }
        }
        private int GetSelectedId(ComboBox cb)
        {
            if (cb.SelectedItem == null) return -1;
            return int.Parse(cb.SelectedItem.ToString().Split('-')[0].Trim());
        }
        private void btnAddEdge_Click(object sender, EventArgs e)
        {
            int from = GetSelectedId(comboBox1);
            int to = GetSelectedId(comboBox2);
            graph.AddEdge(from, to);
            panel1.Invalidate();
        }
        private void btnRemoveEdge_Click(object sender, EventArgs e)
        {
            int from = GetSelectedId(comboBox1);
            int to = GetSelectedId(comboBox2);
            graph.RemoveEdge(from, to);
            panel1.Invalidate();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int id))
            {
                graph.RemoveVertex(id);
                UpdateComboBoxes();
                panel1.Invalidate();
            }
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            int from = GetSelectedId(comboBox1);
            int to = GetSelectedId(comboBox2);
            source = from;
            target = to;
            graph.Dijkstra(from);

            if (graph.Distance[to] == double.MaxValue)
                textBox5.Text = "Không tìm thấy đường đi.\r\nKhoảng cách: Lỗi";
            else
                textBox5.Text = $"Đường đi ngắn nhất: {graph.GetPath(to)}\r\n: {graph.Distance[to]:0.00}";

            panel1.Invalidate();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            graph = new Graph();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            textBox5.Clear();
            panel1.Invalidate();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < Graph.Max; i++)
            {
                var v = graph.Vertices[i];
                if (v != null)
                {
                    for (int j = 0; j < v.EdgeCount; j++)
                    {
                        var to = graph.Vertices[v.Edges[j].To];
                        if (to != null)
                        {
                            g.DrawLine(Pens.Black, v.X, v.Y, to.X, to.Y);
                            int midX = (v.X + to.X) / 2;
                            int midY = (v.Y + to.Y) / 2;
                            g.DrawString(v.Edges[j].Weight.ToString("0.0"), Font, Brushes.Red, midX, midY);
                        }
                    }
                }
            }

            for (int i = 0; i < Graph.Max; i++)
            {
                var v = graph.Vertices[i];
                if (v != null)
                {
                    g.FillEllipse(Brushes.Blue, v.X - 5, v.Y - 5, 10, 10);
                    g.DrawString($"{v.Name} ({i})", Font, Brushes.Black, v.X + 5, v.Y - 5);
                    g.DrawString($"[{v.X},{v.Y}]", Font, Brushes.Gray, v.X + 5, v.Y + 10);
                }
            }
        }
}
}
