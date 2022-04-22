using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;

class Exeptions
{
    public void TextFile(string pathToFile) {
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

    public void BinFile(string currentString, char letter) {
        currentString = currentString.ToLower();
        Console.WriteLine("Данный файл\n {0}", currentString);

        string[] lineArray = currentString.Split(' ');

        FileStream f = new FileStream("BinFileWork.dat", FileMode.Create);
        StreamWriter writer = new StreamWriter(f);
        Console.WriteLine("Что записано в файл\n");

        for (int i = 0; i < lineArray.Length; ++i)
        {
            if (lineArray[i][0] == letter)
            {
                writer.Write(lineArray[i] + " ");
                Console.WriteLine(lineArray[i]);
            }
                
        }
        writer.Close();
  
    }

    public void OneTime(string currentString)
    {
        currentString = currentString.ToLower();
        string[] words = currentString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var result = words.GroupBy(x => x)
                          .Where(x => x.Count() == 1)
                          .Select(x => new { Word = x.Key, Frequency = x.Count() });

        foreach (var item in result)
        {
            Console.WriteLine("{0};  ", item.Word, item.Frequency);
        }
    }

    public void AfterSign(string currentString)
    {
        int lastIndx = currentString.LastIndexOf(':');
        currentString = currentString.Remove(0, lastIndx + 1);
        Console.WriteLine(currentString);
    }


    public void Regular(string currentString)
    {
        Match match = Regex.Match(currentString, @"\d\d[.]\d\d[.]\d\d\d\d");

        while (match.Success)
        {
            string currentDate = Convert.ToString(match.Value);
            int day = Convert.ToInt32(currentDate.Substring(0, 2));
            int month = Convert.ToInt32(currentDate.Substring(3, 2));
            int year = Convert.ToInt32(currentDate.Substring(6, 4));
            if (month == 12 && day == 31)
            {
                Console.WriteLine("01.01.{0}", year + 1);
            }
            else if (day == 31)
            {
                Console.WriteLine("01.{0}.{1}", month + 1, year);
            }
            else
            {
                Console.WriteLine("{2}.{0}.{1}", month, year, day + 1);
            }
            match = match.NextMatch();
        }

    }

    public void Analyziz()
    {

        for (int i = -10; i <= 10; i++)
        {
            double current = i / 2.0;
            Check(current);
        }

    }



    public void Check(double x)
    {
        double y=0;
        try
        {
            y = ((x + 4) / (Math.Pow(x, 2) - 2)) + Math.Pow(Math.Pow(x, 3) - 1, 0.5);

        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine("An Exception has occurred : {0}", e.Message);
        }
        catch (IndexOutOfRangeException e) {
            Console.WriteLine("An Exception has occurred : {0}", e.Message);
        }
        finally
        {
            Console.WriteLine("x= {0} , y= {1} ", x, y);

        }
    }

}

class Checking_Out
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Задание 1: поймать исключения. \n");
        Exeptions func = new Exeptions();
        func.Analyziz();

        Console.WriteLine("Задание 2: вывести на экран последовательность символов, расположенных после последнего двоеточия. \n");
        string currentString = "21.04.2001 dnwkwkwn enwksnw sneodnwkd jdkwne 16.09.1002 newkw enqkskdn ";
        func.Regular(currentString);

        Console.WriteLine("Задание 3: Вывести только те слова, которые встречаются в тексте ровно один раз. \n");
        currentString = "Два раз два три восемь пятнадцать три восемьнадцать ла ла трала ла";
        func.OneTime(currentString);

        Console.WriteLine("Задание 4: Замените каждую дату сообщения на дату следующего дня. \n");
        currentString = "Baby stop baby stop baby lalala: i'm motherfucking real baby lalala";
        func.AfterSign(currentString);

        Console.WriteLine("Задание 5: создать файл(bin), состоящий из слов. Вывести на экран все слова, которые начинаются на заданную букву.  \n");
        currentString = "Слава что ты сделал, как вы можете ненавидеть чувака, который открыл ресторан, дал вам место, чтобы вы покушали";
        char letter = 'с';
        func.BinFile(currentString, letter);

        Console.WriteLine("Задание 6: переписать в новый файл(txt) все его строки, вставив в конец каждой строки количество символов в ней. \n");
        string pathToFile = "/Users/emc2/Projects/OOP-Labotary_work_1/OOP-Labotary_work_1/text.txt";
        func.TextFile(pathToFile);




    }

}
