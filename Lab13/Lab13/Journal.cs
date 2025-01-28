using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class Journal
    {
        private List<JournalEntry> entries;

        public Journal()
        {
            entries = new List<JournalEntry>();
        }

        public void CollectionCountChanged(object source, CollectionHandlerEventArgs e)
        {
            if (e.ModifiedObject is IEnumerable<Car> modifiedCars)
            {
                foreach (Car car in modifiedCars)
                {
                    JournalEntry je = new JournalEntry(e.CollectionName, e.ChangeType, car.ToString());
                    entries.Add(je);
                }
            }
            else if (e.ModifiedObject is Car modifiedCar)
            {
                JournalEntry je = new JournalEntry(e.CollectionName, e.ChangeType, modifiedCar.ToString());
                entries.Add(je);
            }
        }

        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs e)
        {
            if (e.ModifiedObject is Car modifiedCar)
            {
                JournalEntry je = new JournalEntry(e.CollectionName, e.ChangeType, modifiedCar.ToString());
                entries.Add(je);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var entry in entries)
            {
                sb.AppendLine(entry.ToString());
            }
            return sb.ToString();
        }
    }
}
