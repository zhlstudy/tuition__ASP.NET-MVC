using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXGL.OA.Common
{
    public class JsonMessager
    {
        public int Type { get; set; }
        public string Message { get; set; }
        public JsonMessager() { }
        public JsonMessager(int ptype,string pmessage) { Type = ptype;Message = pmessage; }
    }
}
