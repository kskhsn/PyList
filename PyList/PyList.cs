using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyList
{
    class PyList<T> : IList<T>
    {
        public PyList()
        {
            this.list = new List<T>();
        }

        public PyList(int capacity)
        {
            this.list = new List<T>(capacity);
        }

        public PyList(IEnumerable<T> values)
        {
            this.list = values.ToList();
        }

        private List<T> list;

        public T this[int index]
        {
            get
            {
                if (-1 < index && index < this.list.Count)
                    return this.list[index];
                else if (index < 0 && -this.list.Count <= index)
                    return this.list[this.list.Count + index];
                else
                    throw new ArgumentOutOfRangeException();
            }

            set
            {
                if (-1 < index && index < this.list.Count)
                    this.list[index] = value;
                else if (index < 0 && -this.list.Count <= index)
                    this.list[this.list.Count + index] = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        public int Count => this.list.Count;

        public bool IsReadOnly { get { return false; } }

        public void Add(T item) => this.list.Add(item);

        public void Clear() => this.list.Clear();

        public bool Contains(T item) => this.list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => this.list.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator() => this.list.GetEnumerator();

        public int IndexOf(T item) => this.list.IndexOf(item);


        public void Insert(int index, T item)
        {
            if (index < 0)
                index += this.list.Count;

            this.list.Insert(index, item);
        }

        public bool Remove(T item) => this.list.Remove(item);

        public void RemoveAt(int index)
        {
            if (index < 0)
                index += this.list.Count;

            this.list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.list.GetEnumerator();


        public PyList<T> Slice(int start, int end)
        {
            if (-this.list.Count <= start || -this.list.Count <= end || this.list.Count <= start || this.list.Count <= end)
            {
                if (start < 0)
                    start += this.list.Count;
                if (end < 0)
                    end += this.list.Count;

                if (start < end)
                {
                    var length = end - start + 1;
                    return new PyList<T>(this.list.Skip(start).Take(length));
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        public override string ToString() => $"[{string.Join(",", this.list)}]";

    }
}
