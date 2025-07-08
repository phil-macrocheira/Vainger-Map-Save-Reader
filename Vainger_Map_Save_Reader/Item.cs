using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vainger_Map_Save_Reader
{
    public class Item
    {
        public string Room { get; set; }
        public string Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Collected { get; set; } = false;
    }
}
