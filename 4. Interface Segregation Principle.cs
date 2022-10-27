/*
Rule: Many dedicated interfaces are better than one too general.
IOW: Interfaces should be specific and as small as possible. Don't create interface with unused methods.

    If we look at the interfaces built into C#, we'll see that most of them implement one or two methods:
        IEquatable - 1 method
        ICloneable - 1 method
        IComparable - 1 method
        IEnumerable - 1 method
        IIterator - 2 methods

    However in C++ programming there is no built-in concept of interfaces. In order to create an interface, 
    we need to create an abstract class which is having only pure virtual methods. 
    In C++, Interfaces are also called pure abstract classes.
*/

// The code below is incorrect because not every interface-defined method is used in derived classes.
interface IRaportable
{
    void PrintPdf();
    void PrintExcel();
}

class SalaryRaport : IRaportable
{
    public void PrintPdf()
    {
        // print pdf
    }
    
    public void PrintExcel()
    {
        // print excel
    }
}

class HighSchoolExam : IRaportable
{
    public void PrintPdf()
    {
        // print Pdf here
    }
    
    public void PrintExcel()
    {
        throw new NotImplementedException();
    }
}

// Besides of the main IRaportable interface we should've create multiple smaller interfaces.
interface IPrintablePdf
{
    void PrintPdf();
}

interface IPrintableExcel
{
    void PrintExcel();
}

class SalaryRaport : IPrintablePdf, IPrintableExcel
{
    public void PrintPdf()
    {
        // print pdf
    }
    
    public void PrintExcel()
    {
        // print excel
    }
}

class HighSchoolExam : IPrintablePdf
{
    public void PrintPdf()
    {
        // print Pdf here
    }
}
