using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Geom_fig_;

namespace laba3
{
    class FigureMatrixCheckEmpty : IMatrixCheckEmpty<Geom_fig>
    {
        /// <summary>
        /// В качестве пустого элемента возвращается null
        /// </summary>
        /// 
        public Geom_fig getEmptyElement()
        {
            return null;
        }
        /// <summary>
        /// Проверка что переданный параметр равен null
        /// </summary>
        public bool checkEmptyElement(Geom_fig element)
        {
            bool Result = false;
            if (element == null)
            {
                Result = true;
            }
            return Result;
        }
    }
}

