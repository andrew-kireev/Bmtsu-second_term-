using System;
namespace Geom_fig
{
    public class Circle : Geom_fig, IPrint
    {
        protected double radius;

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public Circle(double _radius) { this.radius = _radius; }
        public override double Area()
        {
            return radius * radius * Math.PI;
        }
        public Circle() { }
        public override string ToString()
        {
            double sq = Area();
            string s = ("Radius, radius = " + radius.ToString()
                        + ", S = " + sq.ToString());
            return s;
        }
        public int Plus(int x, int y)
        {
            return (x + y);
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
