using System;

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;
    private string _postalCode;

    public Address(string streetAddress, string city, string stateProvince, string country, string postalCode)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
        _postalCode = postalCode;
    }

    public bool IsUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince} {_postalCode}\n{_country}";
    }
}