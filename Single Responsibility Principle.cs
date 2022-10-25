/* 
Rule: Class should only have one responsibility.

Example of wrong practice:
    Class Person includes a method for checking the e-mail address. 
    Class Person shouldn't contain attributes to the registered address.
*/
class Person
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int HouseNumber { get; set; }
    public string Email { get; set; }
    
    public Person(string name, string lastname, string email)
    {
        Name = name;
        Lastname = lastname;
        Email = ValidateEmail(email);
    }
    
    private string ValidateEmail(string email) 
    {
        if (!email.Contains("@") || !email.Contains("."))
        {
            throw new FormatException("Email address has a wrong format!");
        }
        return email;
    }
}
/*
To avoid refactoring or code duplication, the structure should look like this:
*/
