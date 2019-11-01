using System;
namespace Laborotornya_rabota1
{
    class Program
    {
        static void Change_color(int i)
        {
            if (i == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (i == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (i == 3)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }


        static void input(ref double a, ref double b, ref double c)
        {
            try
            {
                Console.Write("Введите коэффицент a:");
                a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите коэффицент b:");
                b = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите коэффицент c:");
                c = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Change_color(1);
                Console.WriteLine("Введены некорректные данные");
                Change_color(3);
                input(ref a, ref b, ref c);
            }
        }





        static int Main(string[] args)
        {
            double a, b, c;     //коэф
            double x1, x2, x3, x4;      //Корни 

            a = b = c = 0;

            Console.Title = ("Киреев Андрей Сергеевич ИУ5-33Б");

            if (args.Length == 3)
            {
                try
                {
                    a = Convert.ToDouble(args[0]);
                    b = Convert.ToDouble(args[1]);
                    c = Convert.ToDouble(args[2]);
                }
                catch (Exception)
                {
                    Change_color(1);
                    Console.WriteLine("Введены неверные параметры командной строки");
                    return -1;
                }

            }
            else
            {
                input(ref a, ref b, ref c);
            }
            if (a != 0 && b != 0 && c != 0)
            {
                if (b * b - (4 * a * c) < 0)
                {
                    Change_color(1);
                    Console.WriteLine("Корней нет");
                    return 0;
                }
                else
                {
                    if ((b * b) - (4 * a * c) == 0)           
                    {
                        if (-b / 2 * a < 0)               
                        {
                            Change_color(1);
                            Console.WriteLine("Корней нет");
                            return 0;
                        }
                        else
                        {
                            x1 = Math.Sqrt(-b / (2 * a));
                            x2 = -Math.Sqrt(-b / (2 * a));
                            Console.WriteLine(x1 + ' ' +x2);
                            return 0;
                        }
                    }
                    else
                    {
                        if ((-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a) < 0)
                        {
                            Change_color(1);
                            Console.Write("Нет корня x1 и x2");

                        }
                        else
                        {
                            x1 = Math.Sqrt((-b - Math.Sqrt(b * b - 4 * a * c)) 
                            / (2 * a));
                            x2 = -Math.Sqrt((-b - Math.Sqrt(b * b - 4 * a * c)) 
                            / (2 * a));
                            Change_color(2);
                            Console.Write("x1 = " + x1.ToString() + " x2 = " + x2.ToString());
                        }
                        if ((-b + Math.Sqrt(b * b - 4 * a * c))
                        / (2 * a) < 0)
                        {  
                            Change_color(1);
                            Console.Write("Нет корня x3 и x4");

                        }
                        else
                        {
                            x3 = Math.Sqrt((-b + Math.Sqrt(b * b - 4 * a * c)) 
                            / (2 * a));
                            x4 = -Math.Sqrt((-b + Math.Sqrt(b * b - 4 * a * c)) 
                            / (2 * a));
                            Change_color(2);
                            Console.WriteLine(" x3 = " + x3.ToString() + " x4 = "
                                + x4.ToString());
                        }
                        return 0;
                    }
                }
            }
            else
            {
                if (a != 0 && b != 0 && c == 0)
                {
                    if (b * a > 0)
                    {
                        x1 = Math.Sqrt(b / a);
                        Change_color(2);
                        Console.WriteLine("x1 = 0");
                    }
                    else
                    {
                        x1 = Math.Sqrt(-b / a);
                        Change_color(2);
                        Console.WriteLine("x1 = 0 x2 = " + x1.ToString() +
                            " x3 = " + (-x1).ToString());
                    }
                }
                else
                {
                    if (a != 0 && b == 0 && c != 0)
                    {
                        if (c * a > 0)
                        {
                            x1 = Math.Sqrt(c / a);
                            Change_color(1);
                            Console.WriteLine("Корней нет");
                        }
                        else
                        {
                            x1 = Math.Sqrt(Math.Sqrt(-c / a));
                            Change_color(2);
                            Console.WriteLine("x1 = " + x1.ToString() +
                                " x2 = " + (-x1).ToString());
                        }
                    }
                    else
                    {
                        if (a != 0 && b == 0 && c == 0)
                        {
                            Change_color(2);
                            Console.WriteLine("Все 4 корня равны нулю");
                        }
                        else
                        {
                            if (a == 0 && b != 0 && c == 0)
                            {
                                Change_color(2);
                                Console.WriteLine("Два корня равны нулю");

                            }
                            else
                            {
                                if (a == 0 && b != 0 && c != 0)
                                {
                                    if (c * b > 0)
                                    {
                                        x1 = Math.Sqrt(c / b);
                                        Change_color(1);
                                        Console.WriteLine("Корней нет");
                                    }
                                    else
                                    {
                                        x1 = Math.Sqrt(-c / b);
                                        Change_color(2);
                                        Console.WriteLine("x1 = " + x1.ToString() +
                                            " x2 = " + (-x1).ToString());
                                    }
                                }
                                else
                                {
                                    Change_color(2);
                                    Console.WriteLine("бесконечное количество");
                                }
                            }
                        }

                    }
                }

            }
            return 0;
        }
    }
}