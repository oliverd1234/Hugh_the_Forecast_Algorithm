using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Forecast_Algorithm.Library
{
    public class BatchEnum : IEnumerator
    {
        public Batch[] Batches;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public BatchEnum(Batch[] list)
        {
            Batches = list;
        }

        public bool MoveNext()
        {
            
            position++;
            if(position >= Batches.Length)
            {
                return false;
            }
            
            if (Batches[position]!=null && position < Batches.Length)
            {
                return true;
            }
            return (false);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Batch Current
        {
            get
            {
                try
                {
                    return Batches[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    
}
