using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mylibrary
{
    public class Mylibrary
    {
        public bool ISValidPath(string shapeFilePath)
        {
            string extention = System.IO.Path.GetExtension(shapeFilePath);
            string filenameNoExtension = System.IO.Path.GetFileNameWithoutExtension(shapeFilePath);

            if (extention == "" || extention == ".shp" || extention == ".shx")
            {
                string directory = System.IO.Path.GetDirectoryName(shapeFilePath);
                if (Directory.Exists(directory))
                {
                    string[] allMathingFiles = Directory.GetFiles(directory, filenameNoExtension + ".*");
                    string[] allMathingExtentions = new string[allMathingFiles.Length];
                    for (int i = 0; i < allMathingFiles.Length; i++)
                    {
                        allMathingExtentions[i] = System.IO.Path.GetExtension(allMathingFiles[i]);
                    }
                    if (allMathingExtentions.Contains(".shp") && allMathingExtentions.Contains(".shx"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
    }
}
