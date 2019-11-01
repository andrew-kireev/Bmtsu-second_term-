using System;

namespace Geom_fig
{

    class Program
    {
        static void Main(string[] args)
        {
            Square sq = new Square(2);
            sq.Print();
            Rectangle rec = new Rectangle(3, 4);
            rec.Print();
            Circle cir = new Circle(5);
            cir.Print();
        }
    }
}