/* 
Rule: Class should only have one responsibility.

Example of wrong practice:
    1. Person class shouldn't contain an email address validation method. 
    2. Person class shouldn't contain attributes to the registered address.
*/
class Person
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int HouseNumber { get; set; }
    public string Email { get; set; }
    
    public Person( string name, string lastname, string email )
    {
        Name = name;
        Lastname = lastname;
        Email = ValidateEmail( email );
    }
    
    private string ValidateEmail( string email ) 
    {
        if( !email.Contains( "@" ) || !email.Contains( "." ))
        {
            throw new FormatException( "Email address has a wrong format!" );
        }
        return email;
    }
}

//To avoid refactoring or code duplication the stucture could look like this:

class Address
{
    public string City { get; set; }
    public string Street { get; set; }
    public int HouseNumber { get; set; }
}

class Person
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public Address PersonAddress { get; set; }
    
    public Person( string name, string lastname, string email )
    {
        Name = name;
        Lastname = lastname;
        Email = email;
    }
}

class EmailValidator
{
    public void ValidateEmail(string email)
    {
        return email;
    }
    public void ThrowException(string email)
    {
        if( !email.Contains( "@" ) || !email.Contains( "." ))
        {
            throw new FormatException( "Email address has a wrong format!" );
        }   
    }
}
