using System;

class Exeptions {
    public void Analyziz() {

        for (int i = -200; i <= 200; i++)
        {
            double current = i / 2.0;
            Check(current);
        }

    }

    public class SqrtException : Exception
    {
        public void Print()
        {
            Console.WriteLine("Корень меньше нуля");
        }
    }

    public class InfinityException : Exception
    {
        public void Print()
        {
            Console.WriteLine("Бесконечность");
        }
    }


    public void Check(double x){

        try
        {
            double y = (x+4)/(Math.Pow(x, 2)-2) + Math.Pow((Math.Pow(x, 3)-1),0.5);
            
            if ((Math.Pow(x, 3) - 1) < 0)
            {
                throw new SqrtException();
            }
            if ((Math.Pow(x, 2)-1)<0)
            {
                throw new InfinityException();
            }
            Console.WriteLine($"x={x}, y={y}");

        }
        catch
        {
            Console.WriteLine("Возникло исключение!");
        }
    }

}

class Checking_Out {
    public static void Main(string[] args)
    {
        Exeptions func = new Exeptions();
        func.Analyziz();
    }

}
