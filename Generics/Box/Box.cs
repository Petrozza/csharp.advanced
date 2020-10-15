

using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data;
        private int count;

        public Box()
        {
          this.data = new List<T>();
        }
        public int Count
            => data.Count;
                
        public void Add(T item)
        {
            data.Add(item);
        }

        public T Remove()
        {
            var rem = this.data.Last();
            this.data.RemoveAt(this.data.Count-1);
            return rem;
        }
    }
}
