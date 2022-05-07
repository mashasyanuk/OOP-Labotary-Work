using System;

//Создать абстрактный класс Товар с методами, позволяющими вывести на экран информацию о товаре, а также определить, соответствует ли она искомому типу.
//Создать производные классы: Игрушка (название, цена, производитель, материал, возраст, на который рассчитана),
//Книга(название, автор, цена, издательство, возраст, на который рассчитана),

//Спорт-инвентарь(название, цена, производитель, возраст, на который рассчитана), со своими методами вывода информации на экран, и определения соответствия искомому типу.

//Создать базу(массив) из n товаров, вывести полную информацию из базы на экран, а также организовать поиск товаров определенного типа.
//общее - название цена возраст производитель
// книга + автор, игрушка + материал



public abstract class Product
{
    public abstract string Name { get; set; }
    public abstract int Price { get; set; }
    public abstract string Manufacturer { get; set; }
    public abstract int Age { get; set; }
    public abstract string MoreInfo { get; set; }

    public abstract void Print();
    public abstract bool IsEqual(string name, int price, string manufacturer, int age, string moredata);
    public abstract bool CloseToEqual(string name, int price, string manufacturer, int age, string moredata);


}

public class Toy : Product {
    public Toy(string name, int price, string manufacturer, int age, string material) {
        Name = name;
        Price = price;
        Manufacturer = manufacturer;
        Age = age;
        MoreInfo = material;
    }


    string name;
    int price;
    string manufacturer;
    int age;
    string material;

    public override string MoreInfo {
        get => material;
        set => material = value;
    }

    public override string Name
    {
        get => name;
        set => name = value;
    }

    public override int Price
    {
        get => price;
        set => price = value;
    }
    public override string Manufacturer
    {
        get => manufacturer;
        set => manufacturer = value;
    }
    public override int Age
    {
        get => age;
        set => age = value;
    }

    public override void Print()
    {
        Console.WriteLine("{0} - name\n {1} - price\n {2} - material\n {3} - manufacturer\n {4} - age\n", Name, Price, MoreInfo, Manufacturer, Age);
    }
    public override bool IsEqual(string name, int price, string manufacturer, int age, string moredata)
    {
        if ((this.Name == name) &&
            (this.Price == price) &&
            (this.MoreInfo == moredata) &&
            (this.Manufacturer == manufacturer)&&
            (this.Age == age))
            return true;
        return false;
    }

    public override bool CloseToEqual(string name, int price, string manufacturer, int age, string moredata)
    {
        if ((this.Name == name) ||
            (this.Price == price) ||
            (this.MoreInfo == moredata) ||
            (this.Manufacturer == manufacturer) ||
            (this.Age == age))
            return true;
        return false;
    }

}
//Книга(название, автор, цена, издательство, возраст, на который рассчитана),

public class Book : Product
{

    public Book(string name, int price, string manufacturer, int age, string author)
    {
        Name = name;
        Price = price;
        Manufacturer = manufacturer;
        Age = age;
        MoreInfo = author;
    }

    string name;
    int price;
    string manufacturer; // издательство = производитель
    int age;
    string author;

    public override string MoreInfo {
        get => author;
        set => author = value;
    }

    public override string Name
    {
        get => name;
        set => name = value;
    }

    public override int Price
    {
        get => price;
        set => price = value;
    }
    public override string Manufacturer
    {
        get => manufacturer;
        set => manufacturer = value;
    }
    public override int Age
    {
        get => age;
        set => age = value;
    }

    public override void Print()
    {
        Console.WriteLine("{0} - name\n {1} - price\n {2} - author\n {3} - manufacturer\n {4} - age\n", Name, Price, MoreInfo, Manufacturer, Age);
    }
    public override bool IsEqual(string name, int price, string manufacturer, int age, string moredata)
    {
        if ((this.Name == name) &&
            (this.Price == price) &&
            (this.MoreInfo == moredata) &&
            (this.Manufacturer == manufacturer) &&
            (this.Age == age))
            return true;
        return false;
    }

    public override bool CloseToEqual(string name, int price, string manufacturer, int age, string moredata)
    {
        if ((this.Name == name) ||
            (this.Price == price) ||
            (this.MoreInfo == moredata) ||
            (this.Manufacturer == manufacturer) ||
            (this.Age == age))
            return true;
        return false;
    }

}
//Спорт-инвентарь(название, цена, производитель, возраст, на который рассчитана)

public class Sport : Product
{
    public Sport(string name, int price, string manufacturer, int age)
    {
        Name = name;
        Price = price;
        Manufacturer = manufacturer;
        Age = age;
        MoreInfo = "";
    }

    string name;
    int price;
    string manufacturer; // издательство = производитель
    int age;
    string nothing;

    public override string MoreInfo {
        get => nothing;
        set => nothing = value;
    }

    public override string Name
    {
        get => name;
        set => name = value;
    }

    public override int Price
    {
        get => price;
        set => price = value;
    }
    public override string Manufacturer
    {
        get => manufacturer;
        set => manufacturer = value;
    }
    public override int Age
    {
        get => age;
        set => age = value;
    }

    public override void Print()
    {
        Console.WriteLine("{0} - name\n {1} - price\n {2} - manufacturer\n {3} - age\n", Name, Price, Manufacturer, Age);
    }
    public override bool IsEqual(string name, int price, string manufacturer, int age, string moredata)
    {
        if ((this.Name == name) &&
            (this.Price == price) &&
            (this.Manufacturer == manufacturer) &&
            (this.Age == age))
            return true;
        return false;
    }

    public override bool CloseToEqual(string name, int price, string manufacturer, int age, string moredata)
    {
        if ((this.Name == name) ||
            (this.Price == price) ||
            (this.Manufacturer == manufacturer) ||
            (this.Age == age))
            return true;
        return false;
    }


}

//Создать базу(массив) из n товаров, вывести полную информацию из базы на экран, а также организовать поиск товаров определенного типа.
//string name, int price, string manufacturer, int age, string material

public class Program
{
    public static void Main(string[] args)
    {
        const int n = 6;
        Product[] pro_list = new Product[n];
        pro_list[0] = new Toy("Кукла", 1200, "TrixCorporation", 10, "Пластик");
        pro_list[1] = new Toy("Зайка", 1200, "МирИгрушек", 10, "Мех");
        //Книга(название, автор, цена, издательство, возраст, на который рассчитана),
        pro_list[2] = new Book("Война и мир", 400, "Л.Н.Толстой", 16, "Plastic");
        pro_list[3] = new Book("Гордость и предубеждение", 650, "Джейн Остин", 10, "Plastic");
        //Спорт-инвентарь(название, цена, производитель, возраст, на который рассчитана)
        pro_list[4] = new Sport("Гантели", 800, "МТМ", 16);
        pro_list[5] = new Sport("Велосипед", 23000, "ЗдоровьеИСила", 10);

        for (int i = 0; i < n; i++)
        {
            pro_list[i].Print();
        }

        string name = Convert.ToString(Console.ReadLine());
        int price = Convert.ToInt32(Console.ReadLine());
        string manufacturer = Convert.ToString(Console.ReadLine());
        int age = Convert.ToInt32(Console.ReadLine());
        string moredata = Convert.ToString(Console.ReadLine());
        bool flag = false;

        for (int i = 0; i < n; i++)
        {
            if (pro_list[i].IsEqual(name, price, manufacturer, age, moredata))
            {
                Console.WriteLine("Полное совпадение найдено: ");
                pro_list[i].Print();
                flag = true;
            }
        }

        if (flag == false)
        {
            Console.WriteLine("Совпадения не найдены.");
        }

        for (int i = 0; i < n; i++)
        {
            if (pro_list[i].CloseToEqual(name, price, manufacturer, age, moredata))
            {
                Console.WriteLine("Частичное совпадение найдено: ");
                pro_list[i].Print();

            }
        } 
    }
}
