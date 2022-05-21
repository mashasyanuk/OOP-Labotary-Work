using System;
//11
public abstract class Mammalia
{
    public abstract string Weight { get; set; }
    public abstract int Age { get; set; }
}
public class People : Mammalia
{
    public string Name { get; set; }
    public override string Weight { get; set; }
    public override int Age { get; set; }
    public virtual void Feed()
    {
        Console.WriteLine("Сегодня животных кормит " + Name);
    }
}
public class Animal : Mammalia
{
    public string Form { get; set; }
    public override string Weight { get; set; }
    public override int Age { get; set; }
}
public class Dog : Animal
{
    public string Name { get; set; }
    public string Breed { get; set; }
    public virtual void Feed()
    {
        Console.WriteLine("Вы накормили собаку " + Name);
    }
}
public class Cow : Animal
{
    public string Name { get; set; }
    public virtual void Feed()
    {
        Console.WriteLine("Вы накормили корову");
    }
}

class Program
{
    static void Main()
    {
        Dog taksa = new Dog();
        taksa.Name = "Марс";
        taksa.Age = 10;
        taksa.Breed = "taksa";
        taksa.Feed();

        Cow mumu = new Cow();
        mumu.Name = "Муму";
        mumu.Age = 5;
        mumu.Feed();

        People Dasha = new People();
        Dasha.Name = "Даша";
        Dasha.Age = 19;
        Dasha.Feed();


    }
}
