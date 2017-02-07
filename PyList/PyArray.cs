using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyList
{
    class PyArray<T> : IEnumerable<T>
    {
        public PyArray(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException();

            this.array = new T[size];
        }

        public PyArray(IEnumerable<T> values)
        {
            if (!values.Any())
                throw new ArgumentOutOfRangeException();

            this.array = values.ToArray();
        }

        private T[] array;

        public T GetValue(int index) => this.array[index];

        public bool GetValueSafe(int index, ref T value)
        {
            try
            {
                value = this[index];
                return true;
            }
            catch { return false; }
        }

        public void SetValue(int index, T value) => this.array[index] = value;

        public bool SetValueSafe(int index, T value)
        {
            try
            {
                this.SetValue(index, value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.array)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.array.GetEnumerator();

        public T this[int index]
        {
            get
            {
                if (-1 < index && index < this.array.Length)
                    return this.array[index];
                else if (-this.array.Length <= index && index < 0)
                    return this.array[this.array.Length + index];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (-1 < index && index < this.array.Length)
                    this.array[index] = value;
                else if (-this.array.Length <= index && index < 0)
                    this.array[this.array.Length + index] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        public override string ToString() => $"[{string.Join(",", this.array)}]";


        public PyArray<T> Slice(int start, int end)
        {
            if (-this.array.Length <= start || -this.array.Length <= end || this.array.Length <= start || this.array.Length <= end)
            {
                if (start < 0)
                    start += this.array.Length;
                if (end < 0)
                    end += this.array.Length;

                if (start < end)
                {
                    var length = end - start + 1;
                    var dest = new T[length];
                    Array.Copy(this.array, start, dest, 0, length);
                    return new PyArray<T>(dest);
                }
            }
            throw new ArgumentOutOfRangeException();
        }
        //C#6からの書き方1
        public int Length => this.array.Length;

        //昔からのからの書き方
        //public int Length { get { return this.array.Length; } }
    }
}
