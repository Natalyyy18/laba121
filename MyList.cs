using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary10;

namespace лаба12
{
    public class MyList<T> where T : IInit, ICloneable, new()
    {
        Point<T> beg = null;
        Point<T> end = null;

        int count = 0;

        public int Count => count;

        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            var milliseconds = 300;
            Thread.Sleep(milliseconds);
            return new Point<T>(data);
        }

        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        

        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Pred = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (beg != null) //hz
            {
                beg.Pred = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public MyList() { }
        public MyList(int size)
        {
            if (size <= 0) throw new Exception(); //dopisat
            beg = MakeRandomData();
            end = beg;
            for (int i =1; i < size; i++)
            {
                T newItem = MakeRandomItem();
                var milliseconds = 300;
                Thread.Sleep(milliseconds);
                AddToEnd(newItem);
            }
            count = size;
        }

        public MyList(T[] collection)
        {
            if(collection == null) throw new Exception(); //dopisat
            if (collection.Length == 0) throw new Exception(); //dopisat
            T newData = (T)collection[0].Clone();
            beg = new Point<T> (newData);
            end = beg;
            for (int i = 1; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }

        public void PrintList()
        {
            if (count == 0)
                Console.WriteLine("пустой");
            Point<T> current = beg;
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }

        public Point<T> FindItem(int number)
        {
            Point<T> current = beg;
            while (current != null)
            {
                if (current.Data is BankCard m && m.Number.Equals(number))
                    return current;
                current = current.Next;
            }
            return null;
        }

        public bool AddAfterPos(int foundItem, T addItem)
        {
            if (beg == null) throw new Exception("Коллекция пуста.");

            Point<T> pos = FindItem(foundItem);
            if (pos == null)
                return false;

            if (pos == beg) // Если искомый в начале
            {
                T newData1 = (T)addItem.Clone();
                Point<T> newItem1 = new Point<T>(newData1);
                count++;

                newItem1.Pred = pos;
                newItem1.Next = pos.Next;
                pos.Next.Pred = newItem1;
                pos.Next = newItem1;
                //AddToBegin(addItem);
                return true;
            }

            if (pos == end) // Если искомый в конце
            {
                
                AddToEnd(addItem);
                return true;
            }

            // Если искомый между началом и концом
            T newData = (T)addItem.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;

            newItem.Pred = pos;
            newItem.Next = pos.Next;
            pos.Next.Pred = newItem;
            pos.Next = newItem;

            return true;
        }

        //public void AddAfterPos(T item)
        //{
        //    if (beg == null) throw new Exception("the empty list");
        //    Point<T> pos = FindItem(item);
        //    if (pos == null) throw new Exception("не найден"); ;
        //    T newData = (T)item.Clone();
        //    Point<T> newItem = new Point<T>(newData);
        //    count++;
        //    if (beg != null) //hz
        //    {
        //        pos.Next = newItem;
        //        newItem.Next = beg;
        //        beg = newItem;
        //    }
        //    else
        //    {
        //        beg = newItem;
        //        end = beg;
        //    }
        //}

        //public bool Remove(T item) 
        //{ 
        //    if(beg == null) throw new Exception("the empty list");
        //    Point<T> pos = FindItem(item);
        //    if(pos == null) return false;
        //    count--;
        //    //one element
        //    if(beg == end)
        //    {
        //        beg = end = null;
        //        return true;               
        //    }
        //    //the first
        //    if(pos.Pred == null)
        //    {
        //        beg = beg.Next;
        //        beg.Pred = null;
        //        return true;
        //    }
        //    //last
        //    if(pos.Next == null)
        //    {
        //        end = end.Pred;
        //        end.Next = null;
        //        return true;
        //    }
        //    Point<T> next = pos.Next;
        //    Point<T> pred = pos.Pred;
        //    pos.Next.Pred = pred;
        //    pos.Pred.Next = next;
        //    return true;
        //}

        public void RemoveNodesWithEvenIndexes()
        {
           
            Point<T> current = beg;
            int index = 1; // начинаем с индекса 1 (т.е., первый элемент имеет индекс 1)

            while (current != null)
            {
                if (index % 2 == 0) // проверяем четность индекса
                {
                    Point<T> predNode = current.Pred;
                    Point<T> nextNode = current.Next;

                    if (predNode != null)
                    {
                        predNode.Next = nextNode;
                    }
                    else
                    {
                        // если удаляем первый элемент списка
                        beg = nextNode;
                    }

                    if (nextNode != null)
                    {
                        nextNode.Pred = predNode;
                    }
                    else
                    {
                        // если удаляем последний элемент списка
                        end = predNode;
                    }

                    // удаление текущего узла
                    current = nextNode;
                }
                else
                {
                    current = current.Next;
                }

                index++;
            }
        }

        //Сделать глубокую копию списка
        public MyList<T> MakeDeepCopy(MyList<T> listForCopy)
        {
            MyList<T> newList = new MyList<T>();
            Point<T> currentForCopy = listForCopy.beg;
            if (listForCopy.Count > 0)
            {
                for (int i = 0; i < listForCopy.Count; i++)
                {
                    newList.AddToEnd(currentForCopy.Data);
                    currentForCopy = currentForCopy.Next;
                }
            }
            return newList;
        }


    }
}
