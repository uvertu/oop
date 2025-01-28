using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab12
{
    [Serializable]
    public class Item <T>
    {
        public T Data { get; set; }
        public Item<T> Previous { get; set;  }
        public Item<T> Next { get; set; }
        public Item(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
