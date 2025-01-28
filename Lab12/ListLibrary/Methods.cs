using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab12
{
    public static class ItemLinkedListExtensions
    {
        public static void SortBySpeed<T>(this ItemLinkedList<T> list) where T : Vehicle
        {
            var sortedItems = list.OrderBy(item => item.Speed).ToList();
            list.Clear();
            list.AddRange(sortedItems);
        }

        public static void SortByYear<T>(this ItemLinkedList<T> list) where T : Vehicle
        {
            var sortedItems = list.OrderBy(item => item.Year).ToList();
            list.Clear();
            list.AddRange(sortedItems);
        }
        public static ItemLinkedList<T> FilterByField<T>(this ItemLinkedList<T> list, Func<T, bool> predicate) where T : Vehicle
        {
            var filteredItems = list.Where(predicate).ToList();
            var sortedList = new ItemLinkedList<T>();
            sortedList.AddRange(filteredItems);
            return sortedList;
        }
    }
}
