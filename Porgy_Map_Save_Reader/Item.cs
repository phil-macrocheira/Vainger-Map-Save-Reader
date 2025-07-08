using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porgy_Map_Save_Reader
{
    public class Item
    {
        public string room { get; set; }
        public string type { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string item_id { get; set; }
        public bool collected { get; set; } = false;
    }
}
