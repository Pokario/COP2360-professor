using System;

class Animal
{
    static void Main()
    {
        Cat myCat = new Cat();
        myCat.Name = "Michu";
        myCat.Age = 5;
        myCat.Breed = "American Shorthair";
        

        Console.WriteLine("Cat information:");
        Console.WriteLine("Name: " + myCat.Name);
        Console.WriteLine("Age: " + myCat.Age + " years old");
        Console.WriteLine("Breed: " + myCat.Breed);

    }
}

public class Cat
{
    public string Name;
    public int Age;
    public string Breed;
    
}
