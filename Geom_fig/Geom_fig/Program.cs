using System;

namespace Geom_fig
{

    abstract class Geom_fig 
    {
        public abstract double Area();
    }

    class Rectangle : Geom_fig, IPrint
    {
        public Rectangle(double _height, double _lon)
        { 
            this.height = _height;
            this.lon = _lon;
        }
        private double height;
        private double lon;
        public override double Area () 
        {
            return height * lon;
        }
        public override string Object.ToString() 
        {
            string s = ("Rectangle, S = " + Area().ToString);
            return s;
        }
    }

    class Square : Rectangle, IPrint
    {
        private double lonn;
        public Square (double _lonn) { this.lonn = _lonn; }
        public override double Area()
        {
            return lonn * lonn;
        }

    }

    class Circle : Geom_fig, IPrint
    {
        private double radius;
        public Circle(double _radius) { this.radius = _radius; }
        public override double Area()
        {
            return radius * radius * 3.14;
        }
    }

    interface IPrint 
    {
         void Print();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
