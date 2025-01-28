using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

    public class CollectionHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public object ModifiedObject { get; set; }

        public CollectionHandlerEventArgs(string collectionName, string changeType, object modifiedObject)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ModifiedObject = modifiedObject;
        }

        public override string ToString()
        {
            return $"Имя коллекции: {CollectionName}, Тип изменения: {ChangeType}, Объект: {ModifiedObject}";
        }
    }
}
