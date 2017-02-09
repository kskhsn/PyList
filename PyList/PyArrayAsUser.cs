using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyList
{
    static class PyArrayAsUse
    {
        static public T AsPyGet<T>(this T[] array, int index)
        {
            if (-1 < index && index < array.Length)
                return array[index];
            else if (-array.Length <= index && index < 0)
                return array[array.Length + index];
            else
                throw new IndexOutOfRangeException();
        }

        static public T AsPyGet<T>(this IList<T> list, int index)
        {
            if (-1 < index && index < list.Count)
                return list[index];
            else if (-list.Count <= index && index < 0)
                return list[list.Count + index];
            else
                throw new IndexOutOfRangeException();
        }

        static public void AsPySet<T>(this IList<T> list, int index, T value)
        {
            if (-1 < index && index < list.Count)
                list[index] = value;
            else if (index < 0 && -list.Count <= index)
                list[list.Count + index] = value;
            else
                throw new ArgumentOutOfRangeException();
        }
        static public void AsPySet<T>(this T[] array, int index, T value)
        {
            if (-1 < index && index < array.Length)
                array[index] = value;
            else if (-array.Length <= index && index < 0)
                array[array.Length + index] = value;
            else
                throw new IndexOutOfRangeException();
        }


        static public IEnumerable<T> GetEnumerable<T>(this IEnumerable<T> values, int start, int end)
        {
            var inputLength = values.Count();
            if (-inputLength <= start || -inputLength <= end || inputLength <= start || inputLength <= end)
            {
                if (start < 0)
                    start += inputLength;
                if (end < 0)
                    end += inputLength;

                if (start < end)
                {
                    return values.Skip(start).Take(end - start + 1);
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        static public T[] ToArray<T>(this IEnumerable<T> values, int start, int end) => values.GetEnumerable(start, end).ToArray();


        static public List<T> ToList<T>(this IEnumerable<T> values, int start, int end) => values.GetEnumerable(start, end).ToList();

    }

}
