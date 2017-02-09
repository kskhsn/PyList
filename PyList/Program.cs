using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyList
{
    class Program
    {
        static void Main(string[] args)
        {
            //0,1,2,3,4]
            var intArray = Enumerable.Range(0, 5).ToArray();

            var i_1 = intArray.AsPyGet(-1);//4
            var i_2 = intArray.AsPyGet(-2);//3
            var i_3 = intArray.AsPyGet(-3);//2
            var i_4 = intArray.AsPyGet(-4);//1
            var i_5 = intArray.AsPyGet(-5);//0
            var i_6 = intArray.AsPyGet(0);//0
            var i_7 = intArray.AsPyGet(1);//1
            var i_8 = intArray.AsPyGet(2);//2
            var i_9 = intArray.AsPyGet(3);//3
            var i_10 = intArray.AsPyGet(4);//4

            var pyArray = new PyArray<int>(4)
            {
                [0] = 10,
                [1] = 11,
                [2] = 12,
                [3] = 13,
            };

            var pyArray1 = pyArray[-1];//13
            var pyArray2 = pyArray[0];//10
            var pyArray3 = pyArray[1];//11
            Console.WriteLine("pyarray");
            foreach (var v in pyArray)
                Console.WriteLine(v);
            Console.WriteLine("slice");
            foreach (var v in pyArray.Slice(1, 2))
                Console.WriteLine(v);
          
            var pyList = new PyList<int>();
            pyList.Add(100);
            pyList.Add(101);
            pyList.Add(102);
            pyList.Add(103);
            pyList.Add(104);

            var pyList3pyList1 = pyList[-1];//104
            var pyList2 = pyList[0];//100
            var pyList3 = pyList[1];//101
            var pyList4 = pyList[1,3];//[101,102,103]
            var pyList5 = pyList[2,ListIndex.Empty];//[102,103,104]
            var pyList6 = pyList[ListIndex.Empty, 1];//[100]
            pyList[2, 4] = 1;
            pyList[ListIndex.Empty, 2] = 88;
            pyList[ListIndex.Empty, 99] = 123;
            pyList[3,ListIndex.Empty] = 99;

            var ppp = new PyList<int>(new int[] { 10, 99 });

            var ppp2 = ppp * 3;

            var ppp3 = PyList<int>.Empty();//[0]とどっちがいいのだろうか？
            var ppp4 = PyList<int>.Empty()*10;

            var a = ppp4.ToArray();
          

            Console.WriteLine("pylist");
            foreach (var v in pyList)
                Console.WriteLine(v);
            Console.WriteLine("slice");
            foreach (var v in pyList.Slice(1, 2))
                Console.WriteLine(v);
            


        }
    }
}
