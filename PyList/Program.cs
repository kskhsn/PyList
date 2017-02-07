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

            var i_1 = intArray.PyGet(-1);//4
            var i_2 = intArray.PyGet(-2);//3
            var i_3 = intArray.PyGet(-3);//2
            var i_4 = intArray.PyGet(-4);//1
            var i_5 = intArray.PyGet(-5);//0
            var i_6 = intArray.PyGet(0);//0
            var i_7 = intArray.PyGet(1);//1
            var i_8 = intArray.PyGet(2);//2
            var i_9 = intArray.PyGet(3);//3
            var i_10 = intArray.PyGet(4);//4

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

            var pyList1 = pyList[-1];//104
            var pyList2 = pyList[0];//100
            var pyList3 = pyList[1];//101


            Console.WriteLine("pylist");
            foreach (var v in pyList)
                Console.WriteLine(v);
            Console.WriteLine("slice");
            foreach (var v in pyList.Slice(1, 2))
                Console.WriteLine(v);




        }
    }
}
