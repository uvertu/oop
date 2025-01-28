using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab12
{
    [Serializable]
    public class ItemLinkedList<T> : ICollection<T>
    {
        public Item<T> Head { get; set; }
        public Item<T> Tail { get; set; }
        public int Count { get; set; }
        private int Capacity { get; set; }

        public ItemLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
            Capacity = int.MaxValue;
        }

        public ItemLinkedList(int capacity)
        {

            Head = null;
            Tail = null;
            Count = 0;
            Capacity = capacity;
        }

        public ItemLinkedList(ItemLinkedList<T> c)
        {
            foreach (var item in c)
            {
                Add(item);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();

                Item<T> current = Head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();

                Item<T> current = Head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Data = value;
            }
        }
        public void Add(T data)
        {
            var item = new Item<T>(data);

            if (Count == 0)
            {
                Head = item;
                Tail = item;
                Count = 1;
                return;
            }
            Tail.Next = item;
            item.Previous = Tail;
            Tail = item;
            Count++;
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public bool Remove(T data)
        {
            Item<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        Head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        Tail = current.Previous;
                    }
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Remove(item);
            }
        }

        public void RemoveLast(string data)
        {
            var cur = Tail;

            while (cur != null)
            {
                if (cur.Data is Car c && c.CarMake.Equals(data))
                {
                    if (cur.Previous != null)
                    {
                        cur.Previous.Next = cur.Next;
                    }
                    else
                    {
                        Head = cur.Next;
                    }

                    if (cur.Next != null)
                    {
                        cur.Next.Previous = cur.Previous;
                    }
                    else
                    {
                        Tail = cur.Previous;
                    }

                    Count--;
                    return;
                }

                cur = cur.Previous;
            }
        }


        public bool Contains(T item)
        {
            Item<T> current = Head;

            while(current != null)
            {
                if (current.Data is Car c && item is Car i && c.CarMake.Equals(i.CarMake))
                {
                    return true;
                }
                current = current.Next;
            } 

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in this)
            {
                array[arrayIndex++] = item;
            }
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void Show()
        {
            Console.WriteLine("Items in the list:");
            foreach (var item in this)
            {
                Console.WriteLine(item);
            }
        }

        public ItemLinkedList<T> Clone()
        {
            ItemLinkedList<T> cloneList = new ItemLinkedList<T>(Capacity);

            foreach (var item in this)
            {
                if (item is ICloneable cloneableItem)
                {
                    cloneList.Add((T)cloneableItem.Clone());
                }
                else
                {
                    cloneList.Add(item);
                }
            }

            return cloneList;   
        }

        public ItemLinkedList<T> ShallowCopy()
        {
            return new ItemLinkedList<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }
        public bool IsReadOnly => false;
    }
}