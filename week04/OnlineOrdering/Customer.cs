using System;

public class Customer
{
    private string _name;
    private Address _address;
    private string _email;
    private string _phoneNumber;

    public Customer(string name, Address address, string email, string phoneNumber)
    {
        _name = name;
        _address = address;
        _email = email;
        _phoneNumber = phoneNumber;
    }

    public bool IsUSACustomer()
    {
        return _address.IsUSA();
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public string GetEmail()
    {
        return _email;
    }

    public string GetPhoneNumber()
    {
        return _phoneNumber;
    }
}
