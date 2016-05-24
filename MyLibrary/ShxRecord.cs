using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mylibrary
{
    public class ShxRecord : ShapeFile
    {
        private int offset;

        internal int Offset
        {
            get
            {
                return offset;
            }

            private set
            {
                offset = value;
            }
        }
    }
}
