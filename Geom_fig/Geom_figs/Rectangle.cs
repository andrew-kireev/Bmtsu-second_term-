using System;
namespace Geom_fig
{
    public class Rectangle : Geom_fig, IPrint
    {
        private double height;
        private double lon;

        public Rectangle(double _height, double _lon)
        {
            height = _height;
            lon = _lon;
        }


        public double Height
        {
            get { return height; }
            set { height = value; }

        }
        public double Lon
        {
            get { return lon; }
            set { lon = value; }
        }

        public override double Area()
        {
            return height * lon;
        }
        public override string ToString()
        {
            string s = "Rectangle, height = " + height.ToString() + ", length = " +
                        lon.ToString() + ", S = " + Area().ToString();
            return s;
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
