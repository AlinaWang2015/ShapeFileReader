using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mylibrary
{
    public class MainRecord : ShapeFile
    {
        private int recordNumber;
        private byte[] recordContents;

        public int RecordNumber
        {
            get
            {
                return recordNumber;
            }

            set
            {
                recordNumber = value;
            }
        }

        public byte[] RecordContents
        {
            get
            {
                return recordContents;
            }

            set
            {
                recordContents = value;
            }
        }

        internal int GetNumRecords(string pathToShapefile)
        {
            string filepath = System.IO.Path.HasExtension(pathToShapefile) ? pathToShapefile.Substring(0, pathToShapefile.Length - (System.IO.Path.GetExtension(pathToShapefile).Length)) : pathToShapefile;
            string shxfilepath = filepath + ".shx";
            if (shxfilepath == "")
            {
                Console.WriteLine("索引文件打开出错");
            }
            else
            {
                //文件流形式 
                FileStream fs = new FileStream(shxfilepath, FileMode.Open, FileAccess.Read);
                //二进制读取文件的对象
                BinaryReader binaryFile = new BinaryReader(fs);
                //得到文件的字节总长 
                long BytesSum = fs.Length;
                //得以总记录数目= 
                RecordNumber = (int)(BytesSum - 100) / 8;
                binaryFile.Close();
                fs.Close();
            }
            return RecordNumber;
        }

        public string RecordsToString()
        {
            string records = "the records number are:" + RecordNumber;
            return records;
        }
    }
}
