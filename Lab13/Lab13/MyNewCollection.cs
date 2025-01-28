using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class MyNewCollection : ItemLinkedList<Car>
    {
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public string CollectionName { get; set; }

        public MyNewCollection(string collectionName) : base()
        {
            CollectionName = collectionName;
        }

        public bool Remove(int index)
        {
            if (index < 0 || index >= Count)
                return false;

            Car removedItem = this[index];
            Remove(removedItem);

            OnCollectionCountChanged(CollectionName, "Удаление", removedItem);
            return true;
        }

        public void AddDefaults()
        {
            Car[] cars = new Car[3];
            cars[0] = new Car(0, 0, "");
            cars[0].RandomInit();
            cars[1] = new Car(0, 0, "");
            cars[1].RandomInit();
            cars[2] = new Car(0, 0, "");
            cars[2].RandomInit();
            AddRange(cars);
            OnCollectionCountChanged(CollectionName, "Добавление", cars);
        }

        public void Add(object[] items)
        {
            Car[] convertedItems = Array.ConvertAll(items, item => (Car)item);
            AddRange(convertedItems);
            OnCollectionCountChanged(CollectionName, "Добавление", convertedItems);
        }

        public new Car this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                //Car oldValue = base[index];
                base[index] = value;
                OnCollectionReferenceChanged(CollectionName, $"Замена", value);
            }
        }

        protected virtual void OnCollectionCountChanged(string nameCollection, string changeDescription, object modifiedObject)
        {
            CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(CollectionName, changeDescription, modifiedObject));
        }

        protected virtual void OnCollectionReferenceChanged(string nameCollection, string changeDescription, object modifiedObject)
        {
            CollectionReferenceChanged?.Invoke(this, new CollectionHandlerEventArgs(CollectionName, changeDescription, modifiedObject));
        }
    }
}

