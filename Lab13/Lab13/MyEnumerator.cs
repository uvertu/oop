using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class MyEnumerator<T> : IEnumerator<T>
    {
        public Item<T> current;
        public Item<T> head;

        public MyEnumerator(ItemLinkedList<T> c)
        {
            head = c.Head;
            current = null;
        }
        public T Current
        {
            get
            {
                return current.Data;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public bool MoveNext()
        {
            if (current == null)
            {
                current = head;
                return true;
            }

            if (current.Next == null)
            {
                Reset();
                return false;
            }
            else
            {
                current = current.Next;
                return true;
            }
        }

        public void Reset()
        {
            current = null;
        }

        public void Dispose() { }
    }
}
