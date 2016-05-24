using System;
using Mylibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
namespace ShapeFileReader
{
     public class ReadShape
    {
        //文件头
        private int filelength;
        private int version;
        private int shapetype;
        private int recordnumber;
        private Polyline[] collpolyline;
        private Polygon[] collpolygon;
        public double[] BoundBox = new double[4];
        ShapeFile shapefile = new ShapeFile();

        public int Filelength
        {
            get
            {
                return filelength;
            }

            set
            {
                filelength = value;
            }
        }

        public int Version
        {
            get
            {
                return version;
            }

            set
            {
                version = value;
            }
        }

        public int Shapetype
        {
            get
            {
                return shapetype;
            }

            set
            {
                shapetype = value;
            }
        }

        public int Recordnumber
        {
            get
            {
                return recordnumber;
            }

            set
            {
                recordnumber = value;
            }
        }

        public Polyline[] CollPolyline
        {
            get
            {
                return collpolyline;
            }

            set
            {
                collpolyline = value;
            }
        }

        public Polygon[] CollPolygon
        {
            get
            {
                return collpolygon;
            }

            set
            {
                collpolygon = value;
            }
        }

        public object[] Readfile(string path)
        {
            shapefile.ShapeFileToString(path);
            Filelength = shapefile.FileLength;
            Version = shapefile.Version;
            Shapetype = shapefile.ShapeType;
            BoundBox = shapefile.Box;

            switch (Shapetype)
            {
                case 3:
                    object polylines = shapefile.CollectionGemotry(path);
                    CollPolyline = (Polyline[]) polylines;
                    return CollPolyline;
                case 5:
                    object polygons = shapefile.CollectionGemotry(path);
                    CollPolygon = (Polygon[]) polygons;
                    return CollPolygon;
                default:
                    return null;
            }
        }
        /// <summary>
        /// 输出文件头
        /// </summary>
        /// <returns></returns>
        public string showhead(string path)
        {
            object[] aa = Readfile(path);
            StringBuilder str = new StringBuilder();
            string s = string.Format("输出文件头：");
            str.AppendLine(s);
            s = string.Format("文件长度：{0}", Filelength);
            str.AppendLine(s);
            s = string.Format("版本：{0}", Version);
            str.AppendLine(s);
            s = string.Format("shape类型：{0}", Shapetype);
            str.AppendLine(s);
            s = string.Format("记录数目：{0}", Recordnumber);
            str.AppendLine(s);
            s = string.Format("头文件的边界盒(Xmin,Ymin,Zmin,Mmin)：({0},{1},{2},{3})", BoundBox[0], BoundBox[1], BoundBox[2], BoundBox[3]);
            str.AppendLine(s);
            return str.ToString();
        }    
    }

}
