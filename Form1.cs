using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DijkstraWinform
{
    public partial class Form1 : Form
    {
        int dembien = 0;
        static string kq1 = "";
        static string kq2 = "";
        static Dictionary<string, int> inkq = new Dictionary<string, int>();
        // Create points that define line.
        static Point point1 = new Point(85, 370);
        static Point point2 = new Point(252, 370);
        static Point point3 = new Point(330, 250);
        static Point point4 = new Point(475, 250);
        static Point point5 = new Point(626, 250);
        static Point point6 = new Point(330, 74);
        static Point point7 = new Point(555, 160);
        static Point point8 = new Point(168, 160);
        static Point point9 = new Point(626, 370);
        static Point point10 = new Point(723, 18);

        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            doimau();
            if (DIEMA.BackColor == Color.Yellow)
            {
                DIEMA.BackColor = Color.White;
                dembien--;
            }
            else if (dembien < 2)
            {
                DIEMA.BackColor = Color.Yellow;
                dembien++;
            }
            else if (dembien == 2) MessageBox.Show("Vui lòng chỉ chọn 2 điểm");
        }
         
        private void button2_Click(object sender, EventArgs e)
        {
            doimau();
            if (DIEMB.BackColor == Color.Yellow)
            {
                DIEMB.BackColor = Color.White;
                dembien--;
            }
            else if (dembien < 2)
            {
                DIEMB.BackColor = Color.Yellow;
                dembien++;
            }
            else if (dembien == 2) MessageBox.Show("Vui lòng chỉ chọn 2 điểm");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics gra = this.panel1.CreateGraphics();
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);


            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, point1, point2);
            inkq["1 1 3 1"] = 1;
            inkq["3 1 1 1"] = 1;
            e.Graphics.DrawLine(blackPen, point2, point3);
            inkq["3 1 4 3"] = 2;
            inkq["4 3 3 1"] = 2;
            e.Graphics.DrawLine(blackPen, point3, point4);
            inkq["4 3 6 3"] = 3;
            inkq["6 3 4 3"] = 3;
            e.Graphics.DrawLine(blackPen, point2, point4);
            inkq["3 1 6 3"] = 4;
            inkq["6 3 3 1"] = 4;
            e.Graphics.DrawLine(blackPen, point4, point5);
            inkq["6 3 8 3"] = 5;
            inkq["8 3 6 3"] = 5;
            e.Graphics.DrawLine(blackPen, point1, point6);
            inkq["1 1 4 7"] = 6;
            inkq["4 7 1 1"] = 6;
            e.Graphics.DrawLine(blackPen, point6, point5);
            inkq["8 3 4 7"] = 7;
            inkq["4 7 8 3"] = 7;
            e.Graphics.DrawLine(blackPen, point6, point7);
            inkq["7 5 4 7"] = 8;
            inkq["4 7 7 5"] = 8;
            e.Graphics.DrawLine(blackPen, point1, point8);
            inkq["1 1 2 5"] = 9;
            inkq["2 5 1 1"] = 9;
            e.Graphics.DrawLine(blackPen, point3, point8);
            inkq["4 3 2 5"] = 10;
            inkq["2 5 4 3"] = 10;
            e.Graphics.DrawLine(blackPen, point2, point9);
            inkq["3 1 8 1"] = 11;
            inkq["8 1 3 1"] = 11;
            e.Graphics.DrawLine(blackPen, point4, point9);
            inkq["6 3 8 1"] = 12;
            inkq["8 1 6 3"] = 12;
            e.Graphics.DrawLine(blackPen, point7, point10);
            inkq["7 5 9 8"] = 13;
            inkq["9 8 7 5"] = 13;
            e.Graphics.DrawLine(blackPen, point5, point10);
            inkq["8 3 9 8"] = 14;
            inkq["9 8 8 3"] = 14;
        }
        class Edge
        {
            public string u;
            public string v;
            public double w;
            public Edge(string _u, string _v, string _w)
            {
                u = _u;
                v = _v;
                w = double.Parse(_w);
            }
        }
        class Graph
        {
            List<Edge> edges;
            List<string> vertices;
            Dictionary<string, string> aa = new Dictionary<string, string>();
            public Graph(string path)
            {
                edges = new List<Edge>();
                vertices = new List<string>();
                string[] data = System.IO.File.ReadAllLines(path);
                foreach (var line in data)
                {
                    string[] s = line.Split(' ');
                    aa[s[0] + " " + s[1]] = "";
                    aa[s[2] + " " + s[3]] = "";
                }
                int dem = 1;
                foreach (var line in data)
                {
                    string[] s = line.Split(' ');
                    if (aa[s[0] + " " + s[1]] == "")
                    {
                        aa[s[0] + " " + s[1]] = dem.ToString();
                        dem++;
                    }
                    if (aa[s[2] + " " + s[3]] == "")
                    {
                        aa[s[2] + " " + s[3]] = dem.ToString();
                        dem++;
                    }
                    int a = int.Parse(s[0]);
                    int b = int.Parse(s[1]);
                    int c = int.Parse(s[2]);
                    int d = int.Parse(s[3]);
                    double kc = Math.Round(Math.Sqrt((a - c) * (a - c) + (d - b) * (d - b)), 5);
                    edges.Add(new Edge(aa[s[0] + " " + s[1]], aa[s[2] + " " + s[3]], kc.ToString()));
                    edges.Add(new Edge(aa[s[2] + " " + s[3]], aa[s[0] + " " + s[1]], kc.ToString()));
                    if (!vertices.Contains(aa[s[0] + " " + s[1]]))
                        vertices.Add(aa[s[0] + " " + s[1]]);
                    if (!vertices.Contains(aa[s[2] + " " + s[3]]))
                        vertices.Add(aa[s[2] + " " + s[3]]);
                }
            }
            public void Dijkstra(string source1, string source2, string den1, string di1)
            {
                //Console.Write("Nhap diem bat dau ");
                //string source1 = Console.ReadLine();
                //Console.Write("Nhap diem ket thuc ");
                //string source2 = Console.ReadLine();

                string source = aa[source1];
                List<string> Q = new List<string>();
                Dictionary<string, double> dist = new Dictionary<string, double>();
                Dictionary<string, string> prev = new Dictionary<string, string>();
                double INFINITY = edges.Max(p => p.w) + 100;
                foreach (var v in vertices)
                {
                    dist.Add(v, INFINITY);
                    prev.Add(v, null);
                    Q.Add(v);
                }
                dist[source] = 0;
                while (Q.Count != 0)
                {
                    var t = dist.Where(p => Q.Contains(p.Key));
                    double min = t.Min(p => p.Value);
                    string u = t.Where(p => p.Value == min).Select(p => p.Key).First();
                    Q.Remove(u);
                    List<Edge> dsCanhKeU = edges.Where(p => p.u == u && Q.Contains(p.v)).ToList();
                    foreach (Edge canhKeu in dsCanhKeU)
                    {
                        double alt = dist[u] + canhKeu.w;
                        if (alt < dist[canhKeu.v])
                        {
                            dist[canhKeu.v] = alt;
                            prev[canhKeu.v] = u;
                        }
                    }

                }
                kq1 = "Khoảng cách ngắn nhất từ " + den1 + " đến " + di1 + ": " + dist[aa[source2]];
                string d = aa[source2];
                Dictionary<string, string> aaa = new Dictionary<string, string>();
                foreach (var list in aa)
                    aaa[list.Value] = list.Key;
                string[] dinh = new string[1000];
                int dem = 0;
                while (d != source)
                {
                    d = prev[d];
                    dinh[dem] = d;
                    dem++;
                }
                for (int i = dem - 1; i >= 0; i--)
                {
                    kq2 += aaa[dinh[i]] + " ";
                }
            }
        }

        private void DIEMC_Click(object sender, EventArgs e)
        {
            doimau();
            if (DIEMC.BackColor == Color.Yellow)
            {
                DIEMC.BackColor = Color.White;
                dembien--;
            }
            else if (dembien < 2)
            {
                DIEMC.BackColor = Color.Yellow;
                dembien++;
            }
            else if (dembien == 2) MessageBox.Show("Vui lòng chỉ chọn 2 điểm");
        }

        private void DIEMD_Click(object sender, EventArgs e)
        {
            doimau();
            if (DIEMD.BackColor == Color.Yellow)
            {
                DIEMD.BackColor = Color.White;
                dembien--;
            }
            else if (dembien < 2)
            {
                DIEMD.BackColor = Color.Yellow;
                dembien++;
            }
            else if (dembien == 2) MessageBox.Show("Vui lòng chỉ chọn 2 điểm");
        }

        private void DIEME_Click(object sender, EventArgs e)
        {
            doimau();
            if (DIEME.BackColor == Color.Yellow)
            {
                DIEME.BackColor = Color.White;
                dembien--;
            }
            else if (dembien < 2)
            {
                DIEME.BackColor = Color.Yellow;
                dembien++;
            }
            else if (dembien == 2) MessageBox.Show("Vui lòng chỉ chọn 2 điểm");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            doimau();
            if (DIEMF.BackColor == Color.Yellow)
            {
                DIEMF.BackColor = Color.White;
                dembien--;
            }
            else if (dembien < 2)
            {
                DIEMF.BackColor = Color.Yellow;
                dembien++;
            }
            else if (dembien == 2) MessageBox.Show("Vui lòng chỉ chọn 2 điểm");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string den = "", di = "", den1 = "", di1 = "";
            if (DIEMA.BackColor == Color.Yellow && den == "")
            {
                den = DIEMA.Text[2] + " " + DIEMA.Text[4];
                den1 = "A";
            }
            else if (DIEMA.BackColor == Color.Yellow && den != "")
            {
                di= DIEMA.Text[2] + " " + DIEMA.Text[4];
                di1 = "A";
            }
            if (DIEMB.BackColor == Color.Yellow && den == "")
            {
                den = DIEMB.Text[2] + " " + DIEMB.Text[4];
                den1 = "B";
            }
            else if (DIEMB.BackColor == Color.Yellow && den != "")
            {
                di = DIEMB.Text[2] + " " + DIEMB.Text[4];
                di1 = "B";
            }
            if (DIEMC.BackColor == Color.Yellow && den == "")
            {
                den = DIEMC.Text[2] + " " + DIEMC.Text[4];
                den1 = "C";
            }
            else if (DIEMC.BackColor == Color.Yellow && den != "")
            {
                di = DIEMC.Text[2] + " " + DIEMC.Text[4];
                di1 = "C";
            }
            if (DIEMD.BackColor == Color.Yellow && den == "")
            {
                den = DIEMD.Text[2] + " " + DIEMD.Text[4];
                den1 = "D";
            }
            else if (DIEMD.BackColor == Color.Yellow && den != "")
            {
                di = DIEMD.Text[2] + " " + DIEMD.Text[4];
                di1 = "D";
            }
            if (DIEME.BackColor == Color.Yellow && den == "")
            {
                den = DIEME.Text[2] + " " + DIEME.Text[4];
                den1 = "E";
            }
            else if (DIEME.BackColor == Color.Yellow && den != "")
            {
                di = DIEME.Text[2] + " " + DIEME.Text[4];
                di1 = "E";
            }
            if (DIEMF.BackColor == Color.Yellow && den == "")
            {
                den = DIEMF.Text[2] + " " + DIEMF.Text[4];
                den1 = "F";
            }
            else if (DIEMF.BackColor == Color.Yellow && den != "")
            {
                di = DIEMF.Text[2] + " " + DIEMF.Text[4];
                di1 = "F";
            }
            if (DIEMG.BackColor == Color.Yellow && den == "")
            {
                den = DIEMG.Text[2] + " " + DIEMG.Text[4];
                den1 = "G";
            }
            else if (DIEMG.BackColor == Color.Yellow && den != "")
            {
                di = DIEMG.Text[2] + " " + DIEMG.Text[4];
                di1 = "G";
            }
            if (DIEMH.BackColor == Color.Yellow && den == "")
            {
                den = DIEMH.Text[2] + " " + DIEMH.Text[4];
                den1 = "H";
            }
            else if (DIEMH.BackColor == Color.Yellow && den != "")
            {
                di = DIEMH.Text[2] + " " + DIEMH.Text[4];
                di1 = "H";
            }
            if (DIEMH.BackColor == Color.Yellow && den == "")
            {
                den = DIEMI.Text[2] + " " + DIEMI.Text[4];
                den1 = "I";
            }
            else if (DIEMI.BackColor == Color.Yellow && den != "")
            {
                di = DIEMI.Text[2] + " " + DIEMI.Text[4];
                di1 = "I";
            }
            if (DIEMH.BackColor == Color.Yellow && den == "")
            {
                den = DIEMK.Text[2] + " " + DIEMK.Text[4];
                den1 = "K";
            }
            else if (DIEMK.BackColor == Color.Yellow && den != "")
            {
                di = DIEMK.Text[2] + " " + DIEMK.Text[4];
                di1 = "K";
            }
            if (den == "" || di == "") MessageBox.Show("Vui lòng kiểm tra lại điểm đi và điểm đến");
            else
            {
                Graph g = new Graph("graph.txt");
                g.Dijkstra(den, di, den1, di1);
                string bieninkq = "";
                bieninkq += kq1 + "\n" + "Đường đi: ";
                for (int i = 0; i < kq2.Length; i += 4)
                {
                    bieninkq += "("+kq2[i] + "," + kq2[i + 2] + ") -> ";
                }
                bieninkq += "(" + di[0] + "," + di[2] + ")"; 
                label1.Text = bieninkq;
                kq2 += di;
                Graphics gra = panel1.CreateGraphics();
                // Create pen.
                Pen redPen = new Pen(Color.Red, 3);
                Pen blackPen = new Pen(Color.Black, 3);

                //bieninkq = "";
                for (int i = 0; i < kq2.Length - 6; i += 4)
                {
                    if (inkq[kq2.Substring(i, 7)] == 1) gra.DrawLine(redPen, point1, point2);
                    if (inkq[kq2.Substring(i, 7)] == 2) gra.DrawLine(redPen, point2, point3);
                    if (inkq[kq2.Substring(i, 7)] == 3) gra.DrawLine(redPen, point3, point4);
                    if (inkq[kq2.Substring(i, 7)] == 4) gra.DrawLine(redPen, point2, point4);
                    if (inkq[kq2.Substring(i, 7)] == 5) gra.DrawLine(redPen, point4, point5);
                    if (inkq[kq2.Substring(i, 7)] == 6) gra.DrawLine(redPen, point1, point6);
                    if (inkq[kq2.Substring(i, 7)] == 7) gra.DrawLine(redPen, point6, point5);
                    if (inkq[kq2.Substring(i, 7)] == 8) gra.DrawLine(redPen, point6, point7);
                    if (inkq[kq2.Substring(i, 7)] == 9) gra.DrawLine(redPen, point1, point8);
                    if (inkq[kq2.Substring(i, 7)] == 10) gra.DrawLine(redPen, point3, point8);
                    if (inkq[kq2.Substring(i, 7)] == 11) gra.DrawLine(redPen, point2, point9);
                    if (inkq[kq2.Substring(i, 7)] == 12) gra.DrawLine(redPen, point4, point9);
                    if (inkq[kq2.Substring(i, 7)] == 13) gra.DrawLine(redPen, point7, point10);
                    if (inkq[kq2.Substring(i, 7)] == 14) gra.DrawLine(redPen, point5, point10);
                    //bieninkq += kq2.Substring(i, 7) + "   ";
                }
                //label1.Text = bieninkq;
                bieninkq = "";
                kq1 = "";
                kq2 = "";
            }
            
        }
        //1 2 3 4 5 6 7 8
        private void doimau()
        {
            Graphics gra = panel1.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 3);
            gra.DrawLine(blackPen, point1, point2);
            gra.DrawLine(blackPen, point2, point3);
            gra.DrawLine(blackPen, point3, point4);
            gra.DrawLine(blackPen, point2, point4);
            gra.DrawLine(blackPen, point4, point5);
            gra.DrawLine(blackPen, point1, point6);
            gra.DrawLine(blackPen, point6, point5);
            gra.DrawLine(blackPen, point6, point7);
            gra.DrawLine(blackPen, point1, point8);
            gra.DrawLine(blackPen, point3, point8);
            gra.DrawLine(blackPen, point2, point9);
            gra.DrawLine(blackPen, point4, point9);
            gra.DrawLine(blackPen, point7, point10);
            gra.DrawLine(blackPen, point5, point10);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DIEMG_Click(object sender, EventArgs e)
        {
            doimau();
            if (DIEMG.BackColor == Color.Yellow)
            {
                DIEMG.BackColor = Color.White;
                dembien--;
            }
            else if (dembien < 2)
            {
                DIEMG.BackColor = Color.Yellow;
                dembien++;
            }
            else if (dembien == 2) MessageBox.Show("Vui lòng chỉ chọn 2 điểm");
        }

        private void DIEMH_Click(object sender, EventArgs e)
        {
            doimau();
            if (DIEMH.BackColor == Color.Yellow)
            {
                DIEMH.BackColor = Color.White;
                dembien--;
            }
            else if (dembien < 2)
            {
                DIEMH.BackColor = Color.Yellow;
                dembien++;
            }
            else if (dembien == 2) MessageBox.Show("Vui lòng chỉ chọn 2 điểm");
        }

        private void DIEMI_Click(object sender, EventArgs e)
        {
            doimau();
            if (DIEMI.BackColor == Color.Yellow)
            {
                DIEMI.BackColor = Color.White;
                dembien--;
            }
            else if (dembien < 2)
            {
                DIEMI.BackColor = Color.Yellow;
                dembien++;
            }
            else if (dembien == 2) MessageBox.Show("Vui lòng chỉ chọn 2 điểm");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            doimau();
            if (DIEMK.BackColor == Color.Yellow)
            {
                DIEMK.BackColor = Color.White;
                dembien--;
            }
            else if (dembien < 2)
            {
                DIEMK.BackColor = Color.Yellow;
                dembien++;
            }
            else if (dembien == 2) MessageBox.Show("Vui lòng chỉ chọn 2 điểm");
        }
    }

}
