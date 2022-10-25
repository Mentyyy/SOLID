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
