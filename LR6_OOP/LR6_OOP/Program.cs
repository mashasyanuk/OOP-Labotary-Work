//18

/*
 * Напишите программу, содержащую абстрактный класс и два интерфейса.
 * Класс должен содержать объявление абстрактного свойства (с двумя аксессорами),
 * абстрактного индексатора (с двумя аксессорами) и абстрактного метода.
 * Такое же свойство, индексатор и метод должны быть в интерфейсах.
 * На основе абстрактного класса и интерфейсов необходимо создать класс.
 * В этом классе необходимо выполнить явную реализацию для свойства, индексатора и метода
 * для каждого из интерфейсов. Проверьте работу свойства, индексатора и метода, получив доступ к
 * объекту класса через объектную переменную и через интерфейсные переменные.
 */

using System; //объектную переменную и через интерфейсные переменные. 

namespace YMA
{
    abstract class BaseClass
    {
        public abstract char symbol {get;set;}
        public abstract int this[int k] { get; set; }
        public abstract void print();
    }

    interface IFirst
    {
        char symbol { get; set; }
        int this[int k] { get; set; }
        void print();
    }

    interface ISecond
    {
        char symbol { get; set; }
        int this[int k] { get; set; }
        void print();
    }

    class MyClass : BaseClass, IFirst, ISecond
    {
        private char current_sumbol;
        public MyClass(char s) : base()
        {
            current_sumbol = s;
        }
        public override char symbol
        {
            get
            {
                return current_sumbol;
            }
            set
            {
                current_sumbol = value;
            }

        }

        char IFirst.symbol
        {
            get
            {
                return (char)(current_sumbol + 1);
            }
            set
            {
                current_sumbol = (char)(value + 1);
            }
        }

        char ISecond.symbol
        {
            get
            {
                return (char)(current_sumbol + 2);
            }
            set
            {
                current_sumbol = (char)(value + 2);
            }
        }

        public override int this[int k]
        {
            get
            {
                return current_sumbol + k;
            }
            set
            {
                current_sumbol = (char)(value + k % 2);
            }
        }

        int IFirst.this[int k]
        {
            get
            {
                return current_sumbol + k / 2;
            }
            set
            {
                current_sumbol = (char)(value - k % 2);
            }
        }

        int ISecond.this[int k]
        {
            get
            {
                return current_sumbol + k / 2 + 1;
            }
            set
            {
                current_sumbol = (char)(value - k % 2 + 1);
            }
        }

        public override void print()
        {
            Console.WriteLine("Базовый класс :\t\'{0}\'", symbol);
        }

        void IFirst.print()
        {
            Console.WriteLine("Интерфейс 1:\t\'{0}\'", symbol);
        }

        void ISecond.print()
        {
            Console.WriteLine("Интерфейс 2:\t\'{0}\'", symbol);
        }
    }


    class Program
    {
        static void Main()
        {
            MyClass obj = new MyClass('A');
 
            IFirst A = obj;
            ISecond B = obj;

            obj.print();
            A.print();
            B.print();


            Console.WriteLine("obj.symbol = \'{0}\'", obj.symbol);
            Console.WriteLine("  A.symbol = \'{0}\'", A.symbol);
            Console.WriteLine("  B.symbol = \'{0}\'", B.symbol);


            Console.WriteLine("obj[10] = {0}", obj[10]);
            Console.WriteLine("  A[10] = {0}", A[10]);
            Console.WriteLine("  B[10] = {0}", B[10]);


            obj[10] = 5;
            A[10] = 2;
            B[10] = 3;


            Console.WriteLine("obj[10] = {0}", obj[10]);
            Console.WriteLine("  A[10] = {0}", A[10]);
            Console.WriteLine("  B[10] = {0}", B[10]);
        }
    }
}

/*
Базовый класс :	'A'
Интерфейс 1:	'A'
Интерфейс 2:	'A'
obj.symbol = 'A'
  A.symbol = 'B'
  B.symbol = 'C'
obj[10] = 75
  A[10] = 70
  B[10] = 71
obj[10] = 14
  A[10] = 9
  B[10] = 10
  */