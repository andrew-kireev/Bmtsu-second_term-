using System;

namespace laba6_part1
{

    delegate int PlusOrMinus(int p1, int p2);

    class Program
    {
        static int Plus(int p1, int p2)
        {
            return p1 + p2;
        }
        static int Minus(int p1, int p2)
        {
            return p1 - p2;
        }

        static void PlusOrMinusMethod(
         string str,
         int i1,
         int i2,
         PlusOrMinus PlusOrMinusParam)
        {
            int Result = PlusOrMinusParam(i1, i2);
            Console.WriteLine(str + Result.ToString());
        }

        static void PlusOrMinusMethodFunc(
         string str,
         int i1,
         int i2,
         Func<int, int, int> PlusOrMinusParam)
        {
            int Result = PlusOrMinusParam(i1, i2);
            Console.WriteLine(str + Result.ToString());
        }
        static void Main(string[] args)
        {
            int i1 = 3;
            int i2 = 2;
            PlusOrMinusMethod("Плюс: ", i1, i2, Plus);
            PlusOrMinusMethod("Минус: ", i1, i2, Minus);
            PlusOrMinus pm1 = new PlusOrMinus(Plus);
            PlusOrMinus pm2 = Plus;
            PlusOrMinus pm3 = delegate (int param1, int param2)
            {
                return param1 + param2;
            };

            PlusOrMinus pm4 = (int x, int y) =>
            {
                int z = x + y;
                return z;
            };
            int test = pm4(1, 2);

            PlusOrMinusMethod(
             "Создание экземпляра делегата на основе лямбда-выражения 1: ",
             i1,
             i2,
             (int x, int y) =>
             {
                int z = x + y;
                return z;
             }
            );

            PlusOrMinusMethodFunc(
             "Создание экземпляра делегата на основе метода: ",
             i1,
             i2,
             Plus
            );

            PlusOrMinusMethodFunc(
             "Создание экземпляра делегата на основе лямбда-выражения 3:",
             i1,
             i2,
             (x, y) => x + y
            );


            Action<int, int> a1 = (x, y) =>
            { Console.WriteLine("{0} + {1} = {2}", x, y, x + y); };
            Action<int, int> a2 = (x, y) =>
            { Console.WriteLine("{0} - {1} = {2}", x, y, x - y); };
            Action<int, int> group = a1 + a2;
            group(5, 3);

            Action<int, int> group2 = a1;
            Console.WriteLine("Добавление вызова метода к групповому делегату");
            group2 += a2;
            group2(10, 5);
            Console.WriteLine("Удаление вызова метода из группового делегата");
            group2 -= a1;
            group2(20, 10);

            Console.ReadLine();
        }
    }
}
