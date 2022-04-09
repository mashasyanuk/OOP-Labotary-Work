using System;

    public partial class Calculation
    {
        double x = 0.1722;
        double y = 6.33;
        double z = 3.24 * Math.Pow(10, -4);

    }

    public partial class Calculation {
        public Calculation(double x, double y, double z)
        {
            Set(x, y, z);
        }

        protected void Set(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

        }

        public double Run()
        {
            Console.WriteLine("Результат вычисляется...");
            return (5 * Math.Atan(x) - 0.25 * Math.Acos(x) * (x * Math.Abs(x - y) + Math.Pow(x, 2)) / ((Math.Abs(x - y)) * z + Math.Pow(x, 2)));

        }

        public void Print(){
            double result = Run();

            Console.WriteLine("Выражение при данных x={0}, y={1}, z={2} равно {3}", x, y, z, result);
        }
    }

    public class Program{
        public static void Main(string[] args)
        {
            Calculation calc = new Calculation(0.1722, 6.33, 0.000324);
            calc.Print();
        }

    }