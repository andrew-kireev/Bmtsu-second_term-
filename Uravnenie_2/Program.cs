using System;
using System.Numerics;

namespace QuadraticEquations
{






    class Program
    {
        static void Main(string[] args)
        {
            // Ввод данных уравнения - значения a, b и c
            // После ввода данных мы обрезаем лишние пробелы по краям методом Trim()
            // и преобразовываем тип string во float
            Console.Write("Введите значение a = ");
            float a = float.Parse(Console.ReadLine().Trim());
            Console.Write("Введите значение b = ");
            float b = float.Parse(Console.ReadLine().Trim());
            Console.Write("Введите значение c = ");
            float c = float.Parse(Console.ReadLine().Trim());
            // Вычисление дискриминанта
            float d = b * b - 4 * a * c;
            // При дискриминанте меньшим 0 - выводим ошибку
            if (d < 0)
            {
                float dis = (float)System.Math.Sqrt(d);
                Complex c2 = new Complex(-b, dis) / 2;
                Complex c1 = new Complex(-b, -dis) / 2;
            }
            else
            {
                // Объявляем корни уравнения
                float x1, x2;
                float x_1_1, x_1_2, x_2_1, x_2_2;
                // При дискриминанте равным 0 оба корня равны
                if (d == 0)
                {
                    x1 = x2 = -(b / 2 * a);
                }
                else
                {
                    // Извлекаем корень из дискриминанта
                    float dis = (float)System.Math.Sqrt(d);
                    // Высчитываем корни уравнения
                    x1 = (-b + dis) / (2 * a);
                    if (x1 >= 0) {
                         x_1_1 = (float)System.Math.Sqrt(x1);
                         x_1_2 = - (float)System.Math.Sqrt(x1);

                    } else {
                        Complex c_1_1 = new Complex(0, 1);
                        c_1_1 = c_1_1 * x1;
                        Complex c_1_2 = c_1_1;
                    }
                    x2 = (-b - dis) / (2 * a);
                    if (x2 >= 0) {
                         x_2_1 = (float)System.Math.Sqrt(x2);
                         x_2_2 = -(float)System.Math.Sqrt(x2);


                    } else {
                        //Тут очь тонкий момент, нужно будет потом проверить, тк 
                        //хз правльно ли комп числа считаются
                        Complex c_2_1 = new Complex(0, 1);
                        c_2_1 = c_2_1 * x2;
                        Complex c_2_2 = c_2_1;
                    }
                }
                // Выводим результат
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("d = " + d.ToString() + " x1 = " + x1.ToString() +
                              " x2 = " + x2.ToString());
            }
            // Ждем нажатия клавиши, чтобы завершить выполнение программы
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}