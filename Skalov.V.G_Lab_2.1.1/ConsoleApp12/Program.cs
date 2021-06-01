using System;

namespace ind_2._._
{
    class Program
    {
        public static double GetSeriesValue(double a, double eps, int N)
        {
            double n = a;
            double sum = 0.0;
            int i = 0;
            do
            {
                sum += n;
                n *= 2 * (Math.Pow(a - 1, 2 * n + 1) / ((2 * n + 1) * (Math.Pow(a + 1, 2 * n + 1))));
                i++;
            }
            while (Math.Abs(n) >= eps);

            return sum;
        }
        public static double Func(double a, double b, double c, double e)
        {
            if ((e == 0) && (b != 0))
                return a * (e + c) * (e + c);

            if ((e == 0) && (b == 0))
            {
                return (e - a) / (-c);
            }
            return a + (e / c);

        }
        public static void Main(string[] args)
        {
            int N = 1000, countforFunc = -1, countForGets = -1;

            object[] arFunc = new object[81];
            object[] arGets = new object[81];
            double a, b, c, xn, xk, e, x, w;
            double dx = 0.1;
            double eps = 0.001;
            Console.Write("a=");
            a = double.Parse(Console.ReadLine());
            Console.Write("b=");
            b = double.Parse(Console.ReadLine());
            Console.Write("c=");
            c = double.Parse(Console.ReadLine());
            Console.Write("xn=");
            xn = double.Parse(Console.ReadLine());
            Console.Write("xk=");
            xk = double.Parse(Console.ReadLine());
            Console.Write("x=");
            x = double.Parse(Console.ReadLine());
            e = x;
            for (e = xn; xk >= e; e += dx)
            {
                w = Func(a, b, c, e);
                countforFunc++;
                arFunc[countforFunc] = w;
                // Console.WriteLine("|F ={0}|", arFunc [countforFunc]);
                double v = countforFunc * dx;
                arFunc[countforFunc] = (double)arFunc[0] + v;
                Console.WriteLine("{0}", arFunc[countforFunc]);

            }
            Console.WriteLine();
            for (; a < x; a += 0.5)
            {
                w = GetSeriesValue(a, eps, N);
                countForGets++;
                arGets[countForGets] = w;
                // Console.WriteLine("F({0})", arGets [countForGets]);
                object v = arGets[0];
                arGets[countForGets] = (double)v + (countForGets * dx);
                Console.WriteLine("{0}", arGets[countForGets]);
            }
            Console.ReadKey(true);
        }
    }
}