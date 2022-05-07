using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System.Collections;

class Infix_Stack
{
    public void StackWork(string infix)
    {
        //           string infix = "3 ^ 4 + ( 11 - ( 3 * 2 ) ) / 2";

        //string infix = Console.ReadLine();
        string[] tokens = infix.Split(' ');

        Stack<string> s = new Stack<string>();
        List<string> outputList = new List<string>();
        foreach (string c in tokens)
        {
            if (int.TryParse(c.ToString(), out int n))
            {
                outputList.Add(c);
            }
            if (c == "(")
            {
                s.Push(c);
            }
            if (c == ")")
            {
                while (s.Count != 0 && s.Peek() != "(")
                {
                    outputList.Add(s.Pop());
                }
                s.Pop();
            }
            if (IsOperator(c) == true)
            {
                while (s.Count != 0 && Priority(s.Peek()) >= Priority(c))
                {
                    outputList.Add(s.Pop());
                }
                s.Push(c);
            }
        }
        while (s.Count != 0)
        {
            outputList.Add(s.Pop());
        }
        for (int i = 0; i < outputList.Count; i++)
        {
            Console.Write("{0}", outputList[i]);
        }

        Console.ReadLine();
    }

    static int Priority(string c)
    {
        if (c == "^")
        {
            return 3;
        }
        else if (c == "*" || c == "/")
        {
            return 2;
        }
        else if (c == "+" || c == "-")
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    static bool IsOperator(string c)
    {
        if (c == "+" || c == "-" || c == "*" || c == "/" || c == "^")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    ////Дан файл, содержащий информацию о сотрудниках фирмы: фамилия, имя, отчество, пол, возраст, размер зарплаты.
    //За один просмотр файла напечатать элементы файла в следующем порядке:
    //сначала все данные о сотрудниках, зарплата которых меньше 10000, потом данные об остальных сотрудниках, сохраняя исходный порядок в каждой группе сотрудников.
}


class Files_Queue
{

    public void QueueWork(string pathToFile)
    {
        string readEveryLine = File.ReadAllText(pathToFile);
        string[] sentences = readEveryLine.Split('.', '?', '!');
        Console.WriteLine("Данный файл\n {0}", readEveryLine);
        StreamWriter print = new StreamWriter(pathToFile, false);
        for (int i = 0; i < sentences.Length; i++)
        {
            print.WriteLine("{0}. {1} ", sentences[i], sentences[i].Length);
        }
        print.Close();
        readEveryLine = File.ReadAllText(pathToFile);
        Console.WriteLine("Переделанный файл\n {0}", readEveryLine);
    }

    public void FF(string pathToFile)
    {
        //фамилия, имя, отчество, пол, возраст, размер зарплаты
        string line;
        Queue<Member> all = new Queue<Member>();
        System.IO.StreamReader file = new System.IO.StreamReader(pathToFile);
        while ((line = file.ReadLine()) != null)
        {
            Member m = new Member();
            string[] t = line.Split(',');
            m.surname = t[0];
            m.name = t[1];
            m.patronymic = t[2];
            m.sex = t[3];
            m.age = t[4];
            m.salary = t[5];
            all.Enqueue(m);
        }
        Console.WriteLine("Зарплата меньше 10000\n");
        foreach (Member member in all)
            if (Convert.ToInt32(member.salary.Trim()) < 10000)
                Console.WriteLine(member);
        Console.WriteLine("\nбольше 10000\n");

        foreach (Member member in all)
            if (Convert.ToInt32(member.sex.Trim()) >= 10000)
                Console.WriteLine(member);
        Console.ReadKey();
    }

    struct Member
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string sex { get; set; }
        public string age { get; set; }
        public string salary { get; set; }
        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                surname,
                name,
                patronymic,
                sex,
                age,
                salary);
        }
    }

    class Infix_Array
    {
        public void StackWork(string infix)
        {
            // for example string infix = "3 ^ 4 + ( 11 - ( 3 * 2 ) ) / 2";
            //Доступ к элементам стека осуществляется по принципу LIFO (Last In First Out) — последним пришел, первым вышел.

            string[] tokens = infix.Split(' ');

            var s = new ArrayList();
  
            List<string> outputList = new List<string>();
            int count = -1;
            foreach (string c in tokens)
            {
                count = 0;
                if (int.TryParse(c.ToString(), out int n))
                {
                    outputList.Add(c);
                }
                if (c == "(")
                {

                    s.Remove(c); //  в начало стека
                }
                if (c == ")")
                {
                 //   while (s.Count != 0 && s.Peek() != "(")
                    {
                 //       outputList.Add(s.Pop());
                    }
                    s.Remove(c);
                }
                if (IsOperator(c) == true)
                {
                  //  while (s.Count != 0 && Priority(s.Peek()) >= Priority(c))
                    {
                //        outputList.Add(s.Pop());
                    }
                //    s.(c);
                }
            }
            while (s.Count != 0)
            {
               // outputList.Add();
            }
            for (int i = 0; i < outputList.Count; i++)
            {
                Console.Write("{0}", outputList[i]);
            }

            Console.ReadLine();
        }

        static int Priority(string c)
        {
            if (c == "^")
            {
                return 3;
            }
            else if (c == "*" || c == "/")
            {
                return 2;
            }
            else if (c == "+" || c == "-")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static bool IsOperator(string c)
        {
            if (c == "+" || c == "-" || c == "*" || c == "/" || c == "^")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}


 
