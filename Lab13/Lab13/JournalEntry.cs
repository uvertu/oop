using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class JournalEntry
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public string ModifiedData { get; set; }

        public JournalEntry(string collectionName, string changeType, string modifiedData)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ModifiedData = modifiedData;
        }

        public override string ToString()
        {
            return $"Имя коллекции: {CollectionName}, Тип изменения: {ChangeType}, Объект: {ModifiedData}";
        }
    }
}
