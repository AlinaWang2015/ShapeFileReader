using System;
using Mylibrary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapeFileReader
{
    public partial class Form1 : Form
    {
        string path;
        public int numCollection;
        public static Color gColor = Color.White;
        public static int gLineWidth;
        Graphics tu = null;
        ReadShape readshape = new ReadShape();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tu = this.panel.CreateGraphics();
        }

        // open the file and show its property
        private void btnopen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openflg = new OpenFileDialog();
            openflg.Filter = "*.shp|*.SHP";
            openflg.Multiselect = false;
            if (openflg.ShowDialog() == DialogResult.OK)
            {
                path = openflg.FileName;
                txtaddress.Text = path;
            }
            string show = readshape.showhead(path);
            txtshow.Text = show;
        }

        public void draw()
        {
            //Pen pen1 = new Pen(gColor, gLineWidth);
            
                if (readshape.Shapetype ==3)
                {
                   Polyline[] polylines = readshape.CollPolyline;
                   for (int i = 0; i < polylines.Count(); i++)
                   {
                        PointF[] points = new PointF[polylines[i].Points.Count];
                        for (int j = 0; j < polylines[i].Points.Count; j++)
                        {
                            Mylibrary.Point point = polylines[i].Points[j];
                            PointF ps = new PointF();
                            ps.X = (float)polylines[i].Points[j].X;
                            ps.Y = (float)polylines[i].Points[j].Y;
                            points[j] = ps;
                         }
                        tuxiang(points);
                        tu.DrawPolygon(Pens.Red, points);
                    }
                }
        }

        public void tuxiang(params PointF[] pt)
        {
            for (int i = 0; i < pt.Length; i++)
            {
                pt[i].X = (float)((pt[i].X - readshape.BoundBox[0]) / (readshape.BoundBox[2] - readshape.BoundBox[0]) * this.panel.Width);
                pt[i].Y = (float)((readshape.BoundBox[3] - pt[i].Y) / (readshape.BoundBox[3] - readshape.BoundBox[1]) * this.panel.Height);
            }
        }

        // draw it on image
        private void button2_Click(object sender, EventArgs e)
        {
            if(txtaddress.Text==null)
            {
                string aa = "请选择文件！";
                txtshow.Text = aa;
            }
            draw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tu.Clear(gColor);
        }
    }
}
