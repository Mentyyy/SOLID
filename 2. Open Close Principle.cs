// Rule: Class should be open for extensions but closed for modifications.


//Example below shows that adding any new figure requires modifying the existing class.
class Square
{
    public int A { get; set; }
}

class Rectangle
{
    public int A { get; set; }
    public int B { get; set; }
}

class Calculator
{
    public int Area( object shape )
    {
        if( shape is Square )
        {
            Square square = ( Square )shape;
            return square.A * square.A;
        }
        else if( shape is Rectangle )
        {
            Rectangle rectangle = ( Rectangle )shape;
            return rectangle.A * rectangle.B;
        }
        return 0;
    }
}

// Polymorphism is the basic mechanism that makes our class possible to extend in the future.
// The code will also be much simpler.
abstract class Shape
{
    public abstract int Area();
}

class Square : Shape   
{
    public int A { get; set; }
    
    public override int Area()
    {
        return A * A;
    }
}

class Rectangle : Shape
{
    public int A { get; set; }
    public int B { get; set; }
    
    public override int Area()
    {
        return A * B;
    }
}

class Calculator
{
    public int Area( Shape shape )
    {
        return shape.Area();
    }
}
