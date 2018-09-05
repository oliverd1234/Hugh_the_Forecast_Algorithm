using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Forecast_Algorithm.Library
{
    public class Worksite : IList<Batch>
    {
        private Batch[] Batches = new Batch[8];
        private int _count;
        private int _Agg_count;
        private int maximum;
        public Worksite(int max)
        {
            _count = 0;
            _Agg_count = 0;
            maximum = max;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public BatchEnum GetEnumerator()
        {
            return new BatchEnum(Batches);
        }

        // IList Members
        public void Add(Batch value)
        {
            if (_count < Batches.Length)
            {
                Batches[_count] = value;
                _count++;
                _Agg_count += value.Batchsize;
                
               
            }
            else
            {
                int size = Batches.Length;
                var temp_contents = new Batch[size*2];
               for(int i = 0; i < Batches.Length; i++)
                {
                    temp_contents[i] = Batches[i];
                }
                Batches = temp_contents;
                Batches[size] = value;
                _count++;
            }
        }
        public int get_Agg()
        {
            return _Agg_count;
        }
        public void Clear()
        {
            _count = 0;
            Batches = new Batch[8];
        }

        public bool Contains(Batch value)
        {
            bool inList = false;
            for (int i = 0; i < Count; i++)
            {
                if (Batches[i] == value)
                {
                    inList = true;
                    break;
                }
            }
            return inList;
        }

        public int IndexOf(Batch value)
        {
            int itemIndex = -1;
            for (int i = 0; i < Count; i++)
            {
                if (Batches[i] == value)
                {
                    itemIndex = i;
                    break;
                }
            }
            return itemIndex;
        }

        public void Insert(int index, Batch value)
        {
            if ((_count + 1 <= Batches.Length) && (index < Count) && (index >= 0))
            {
                _count++;

                for (int i = Count - 1; i > index; i--)
                {
                    Batches[i] = Batches[i - 1];
                }
                Batches[index] = value;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public Boolean Remove(Batch value)
        {
            _Agg_count -= value.Batchsize;
           return( B_RemoveAt(IndexOf(value)));
            
        }

        public Boolean B_RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    Batches[i] = Batches[i + 1];
                }
                _count--;
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    Batches[i] = Batches[i + 1];
                }
                _count--;
            }
        }


        public Batch this[int index]
        {
            get
            {
                return Batches[index];
            }
            set
            {
                Batches[index] = value;
            }
        }

        // ICollection Members

        public void CopyTo(Batch array, int index)
        {
            //int j = index;
            //for (int i = 0; i < Count; i++)
            //{
            //    array.SetValue(_contents[i], j);
            //    j++;
            //}

        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        // Return the current instance since the underlying store is not
        // publicly available.
        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        // IEnumerable Members

        //public IEnumerator GetEnumerator()
        //{
        //    // Refer to the IEnumerator documentation for an example of
        //    // implementing an enumerator.
        //    return 
        //    throw new Exception("The method or operation is not implemented.");
        //}

        public void PrintContents()
        {
            Console.WriteLine("List has a capacity of {0} and currently has {1} elements.", Batches.Length, _count);
            Console.Write("List contents:");
            for (int i = 0; i < Count; i++)
            {
                Console.Write(" {0}", Batches[i]);
            }
            Console.WriteLine();
        }

        public void CopyTo(Batch[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        IEnumerator<Batch> IEnumerable<Batch>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
