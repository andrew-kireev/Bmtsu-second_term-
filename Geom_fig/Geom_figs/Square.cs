using System;
namespace Geom_fig
{
    public class Square : Rectangle, IPrint
    {
        public Square(double _lonn) : base(_lonn, _lonn) { }


        public override double Area()
        {
            return Height * Height;
        }
        public override string ToString()
        {
            double sq = Area();
            string s = "Rectangle, side length = " + Height.ToString() +
                        ", S = " + sq.ToString();
            return s;
        }
        public new void Print()
        {
            Console.WriteLine(this.ToString());
        }


    }
}
