/*
Rule: "Functions that use pointers or references to base classes must be able to use objects of derived classes without knowing it."
IOW: We can always use any derived class in place of the base class.
or: Inheritance should be planned so that each derived class can use the functions of the base class.


The Liskov substitution principle is most often broken in the following cases:
    - when the developer has mismanaged the inheritance mechanism, the polymorphic interface is too general,
    - inheritance without polymorphism
    - derived classes override the base class's methods by replacing its mismatched logic
        - In a well-planned inheritance mechanism, derived classes should extent, not override the methods of the base classes. 
          
          
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


// The example below follows the Liskov substitution method perfectly. 
// Not only can the derived class object be used in place of the base class, but in addition to the use of polymorphism, 
// we do not overwrite the base class methods, we only use them.
class CoffeeMachine
{
    public virtual void Brew()
    {
        Console.WriteLine("Pour coffee to the cup");
        Console.WriteLine("Pour water to the cup");
    }
}

class CoffeeLatteMachine : CoffeeMachine
{
    public override void Brew()
    {
        base.Brew();
        Console.WriteLine("Pour milk to the cup");
    }
}

class Program
{
    static void Main()
    {
        CoffeeMachine coffee;
        
        Console.WriteLine("Making normal coffee");
        coffee = new CoffeeMachine();
        coffee.Brew();
        
        Console.WriteLine("Making latte coffee");
        coffee = new CoffeeLatteMachine();
        coffee.Brew();
    }
}
