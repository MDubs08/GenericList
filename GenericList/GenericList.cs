using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class GenericList <T> : IEnumerable<T>
    {
        private T[] items;
        private int size;
        private int length;
        public GenericList()
        {
            items = new T[length];
        }
        public GenericList(int capacity)
        {
            if (capacity < 0)
                throw new Exception("Argument out of range");

            else
                items = new T[capacity];
            length = capacity;
        }
        public void Add(T Item)
        {
            EnsureCapacity(size + 1);
            items[size++] = Item;
        }
        public void Remove(T Item)
        {
            int index = Array.IndexOf(items, Item, 0, size);
            --size;
            if (index < size)
                Array.Copy(items, index + 1, items, index, size = index);
            items[size] = default(T);
        }
        public int Capacity
        {
            get
            {
                return Length;
            }
            set
            {
                if (value < size)
                {
                    throw new Exception("Argument out of range");
                }
                else if (value >= 0)
                {
                    T[] newItems = new T[value];
                    for (int index = 0; index < size; index++)
                    {
                        newItems[index] = items[index];
                    }
                    items = newItems;
                    length = value;
                }
            }
        }
        private void EnsureCapacity(int minCapacity)
        {
            if (Length < minCapacity)
            {
                Capacity = minCapacity * 2;
            }
        }
        private int IndexOf(T Items)
        {
            int itemsIndex = -1;
            for (int index = size -1; index>=0; index--)
            {
                if (Equals(items[index], Items))
                {
                    itemsIndex = index;
                }
            }
            return itemsIndex;
        }
        public static GenericList<T> operator+(GenericList<T> genericlist1, GenericList<T> genericlist2)
        {
            GenericList<T> genericList = new GenericList<T>();
            if (genericlist1 != null && genericlist2 != null)
            {
                foreach (T item in genericlist2)
                {
                    genericList.Add(item);
                }
                foreach (T item in genericlist1)
                {
                    genericList.Add(item);
                }
            }
            return genericList;
            //GenericList<T> newGenericList = new GenericList<T>();
            //newGenericList.items = genericlist1.items + genericlist2.items;
            //newGenericList.size = genericlist1.size + genericlist2.size;
            //return newGenericList;
        }
        public static GenericList<T> operator-(GenericList<T> genericList1, GenericList<T> genericList2)
        {
            GenericList<T> genericList = new GenericList<T>();
            if (genericList1 != null && genericList2 != null)
            {
                foreach (T item in genericList2)
                {
                    genericList.Remove(item);
                }
                foreach (T item in genericList1)
                {
                    genericList.Remove(item);
                }
            }
            return genericList;
            //GenericList<T> newGenericList = new GenericList<T>();
            //newGenericList.items = genericList1 - genericList2.items;
            //newGenericList.size = genericList1.size - genericList2.size;
            //return newGenericList;
        }
        public int Length
        {
            get { return length; }
        }
        public override string ToString()
        {
            string temp = null;

            for (int i = 0; i < size; ++i)
            {
                temp += items[i] + " ";
            }
            return temp;
        }
        public int Count
        {
            get { return size; }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int index = 0; index < size; index++)
            {
                yield return items[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int index = 0; index < size; index++)
            {
                yield return items[index];
            }
        }
        
        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < size; index++)
            {
                yield return items[index];
            }
        }
        public static IEnumerable<T> Zip(GenericList<T> genericList1, GenericList<T> genericList2)
        {
            GenericList<T> genericList = new GenericList<T>();
            for (int index = 0; index < genericList.size; index++)
            {
                foreach (T item in genericList1)
                {
                    genericList.Add(item);
                }
                foreach (T item in genericList2)
                {
                    genericList.Add(item);
                }
                return genericList;
            }
            return genericList;

            //GenericList<T> genericList = genericList1.Zip(genericList2, (first, second) =>
            //for (int index = 0; index < genericList.size; index++)
            //{
                //if (genericList2.size > genericList1.size) ;
                //{
                //    yield return (second, first) => second + " " + first;
                //}
                //else if (genericList1.size > genericList2.size) ;
                //{
                //    yield return (first, second) => first + " " + second;
                //}
            //}
            //yield return genericList;
        }
    }
}
