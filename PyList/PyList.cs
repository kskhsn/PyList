using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyList
{


    static public class PyListHelper
    {
        static public PyList<T> ToPyList<T>(this IEnumerable<T> values) => new PyList<T>(values);
        
    }

    public enum ListIndex { Empty }

    public class PyList<T> :IList<T>
    {
        static public PyList<T> Empty() => new PyList<T>();


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
            get { return this.list[this.CalcIndex(index)]; }
            set { this.list[this.CalcIndex(index)] = value; }
        }

        public PyList<T> this[int start, int end]
        {
            get
            {
                start = this.CalcIndexSafe(start);
                end = this.CalcIndexSafe(end);

                if (start < end)
                {
                    return new PyList<T>(this.list.Skip(start).Take(end - start + 1));
                }
                else
                    return PyList<T>.Empty();
            }
            set
            {
                start = this.CalcIndexSafe(start);
                end = this.CalcIndexSafe(end);
                for (int i = start; i < end; i++)
                {
                    this.list[i] = value[0];
                }
            }

        }

        public PyList<T> this[ListIndex start, int end]
        {
            get { return new PyList<T>(this.list.Take(this.CalcIndexSafe(end))); }
            set { this[0, end] = value; }
        }

        public PyList<T> this[int start, ListIndex end]
        {
            get { return new PyList<T>(this.list.Skip(this.CalcIndexSafe(start))); }
            set { this[start, this.list.Count] = value; }
        }


        private int CalcIndex(int index)
        {
            if (-1 < index && index < this.list.Count)
                return index;
            else if (index < 0 && -this.list.Count <= index)
                return this.list.Count + index;
            else
                throw new ArgumentOutOfRangeException();
        }

        private int CalcIndexSafe(int index)
        {
            if (index < -this.list.Count)
                return 0;
            else if (index < 0)
                return this.list.Count + index;
            else if (index < this.list.Count)
                return index;
            else
                return this.list.Count;
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
                    var length = end - start;
                    return new PyList<T>(this.list.Skip(start).Take(length));
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        public override string ToString() => $"[{string.Join(",", this.list)}]";

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// <para>この定義によりで無理やり代入を実装</para>
        /// <para>これによりlist[3,5]=5のような書き方が可能</para>
        /// </summary>
        /// <param name="value"></param>
        static public implicit operator PyList<T>(T value)
        {
            return new PyList<T>() { value };
        }

        static public PyList<T> operator *(PyList<T> list, int rate)
        {
            var temp = new PyList<T>(list);
            if (temp.Count != 0)
            {
                for (int i = 0; i < rate; i++)
                    foreach (var item in list)
                        temp.Add(item);
            }
            else
            {
                for (int i = 0; i < rate; i++)
                {
                    temp.Add(default(T));
                }

            }
            return temp;
        }




    }
}
