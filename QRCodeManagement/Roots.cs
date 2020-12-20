using System;
using System.Collections.Generic;

namespace QRCodeManagement
{
    public class Symbol
    {
        public int seq { get; set; }
        public string data { get; set; }
        public object error { get; set; }
    }
    public class Root
    {
        public string type { get; set; }
        public List<Symbol> symbol { get; set; }
    }

}
