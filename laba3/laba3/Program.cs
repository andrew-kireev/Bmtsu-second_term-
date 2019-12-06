using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Geom_fig_;

namespace laba3
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(2, 2);
            Square square = new Square (5);
            Circle circle = new Circle(5);

            ArrayList fl = new ArrayList();
            fl.Add(circle);
            fl.Add(square);
            fl.Add(rect);            fl.Sort();            List<Geom_fig> f2 = new List<Geom_fig>
            {
                circle,
                rect,
                square
            };
            Console.WriteLine("\nПеред сортировкой:");
            foreach (var x in fl) Console.WriteLine(x);
            //сортировка
            fl.Sort();
            Console.WriteLine("\nПосле сортировки:");
            foreach (var x in fl) Console.WriteLine(x);            Console.WriteLine("\nМатрица");
            Matrix<Geom_fig> matrix = new Matrix<Geom_fig>(3, 3,
             new FigureMatrixCheckEmpty());
            matrix[0, 0] = rect;
            matrix[1, 1] = square;
            matrix[2, 2] = circle;
            Console.WriteLine(matrix.ToString());            SimpleList<Geom_fig> list = new SimpleList<Geom_fig>();
            list.Add(circle);
            list.Add(rect);
            list.Add(square);
            Console.WriteLine("\nПеред сортировкой:");
            foreach (var x in list) Console.WriteLine(x);
            //сортировка
            list.Sort();
            Console.WriteLine("\nПосле сортировки:");
            foreach (var x in list) Console.WriteLine(x);            Console.ReadLine();
        }
    }
}
