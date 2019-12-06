using System;
namespace Geom_fig_
{
    public abstract class Geom_fig : IComparable
    {
        public abstract double Area();

        public int CompareTo(object obj)
        {
            //Приведение параметра к типу "фигура"
            Geom_fig p = (Geom_fig)obj;
            //Сравнение
            if (this.Area() < p.Area()) return -1;
                else if (this.Area() == p.Area()) return 0;
                else return 1; //(this.Area() > p.Area())
            }
    }
}
