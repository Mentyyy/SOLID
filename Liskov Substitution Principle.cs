/*
Rule: "Functions that use pointers or references to base classes must be able to use objects of derived classes without knowing it."
IOW: We can always use any derived class in place of the base class
or: Inheritance should be planned so that each derived class can use the functions of the base class

In the example below, we've created the Animal abstraction, but there is a poorly thought inheritance mechanism. 
The fish is an animal, but has the implementation of the Run() method. 
A fish like a fish cannot run and this is a break of Liskov's substitution rule. 
*/
abstract class Animal
{
    public string Name { get; set; }
    public abstract void Run();
}

class Dog : Animal
{
    public override void Run()
    {
        Console.WriteLine("Dog runs");
    }
}

class Fish : Animal
{
    public override void Run()
    {
        throw new NotImplementedException("Fish can not run!"); 
    }
}

class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();
        
        animals.Add(new Dog());
        animals.Add(new Fish());
        
        animals.ForEach(o => o.Run());
    }
}

