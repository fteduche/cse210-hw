using System;
using System.Collections.Generic;

public class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;
    private string postalCode;

    public Address(string streetAddress, string city, string stateProvince, string country, string postalCode)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
        this.postalCode = postalCode;
    }

    public bool IsUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{streetAddress}\n{city}, {stateProvince} {postalCode}\n{country}";
    }
}

public class Customer
{
    private string name;
    private Address address;
    private string email;
    private string phoneNumber;

    public Customer(string name, Address address, string email, string phoneNumber)
    {
        this.name = name;
        this.address = address;
        this.email = email;
        this.phoneNumber = phoneNumber;
    }

    public bool IsUSACustomer()
    {
        return address.IsUSA();
    }

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }

    public string GetEmail()
    {
        return email;
    }

    public string GetPhoneNumber()
    {
        return phoneNumber;
    }
}

public class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;
    private string description;

    public Product(string name, string productId, decimal price, int quantity, string description)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
        this.description = description;
    }

    public decimal GetTotalCost()
    {
        return price * quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetProductId()
    {
        return productId;
    }

    public string GetDescription()
    {
        return description;
    }
}

public class Order
{
    private List<Product> products;
    private Customer customer;
    private const decimal USA_SHIPPING_COST = 5.00m;
    private const decimal INTERNATIONAL_SHIPPING_COST = 35.00m;
    private decimal taxRate;

    public Order(Customer customer, decimal taxRate)
    {
        this.customer = customer;
        this.taxRate = taxRate;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal GetSubtotal()
    {
        decimal subtotal = 0;
        foreach (var product in products)
        {
            subtotal += product.GetTotalCost();
        }
        return subtotal;
    }

    public decimal GetTax()
    {
        return GetSubtotal() * taxRate / 100;
    }

    public decimal GetTotalCost()
    {
        decimal totalCost = GetSubtotal() + GetTax();
        if (customer.IsUSACustomer())
        {
            totalCost += USA_SHIPPING_COST;
        }
        else
        {
            totalCost += INTERNATIONAL_SHIPPING_COST;
        }
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (var product in products)
        {
            packingLabel += $"Product: {product.GetName()} ({product.GetProductId()})\nDescription: {product.GetDescription()}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Customer: {customer.GetName()}\n{customer.GetAddress().GetFullAddress()}\nEmail: {customer.GetEmail()}\nPhone: {customer.GetPhoneNumber()}";
    }

    public string GetInvoice()
    {
        string invoice = $"Invoice for {customer.GetName()}\n";
        invoice += $"Subtotal: {GetSubtotal():C}\n";
        invoice += $"Tax ({taxRate}%): {GetTax():C}\n";
        invoice += $"Total: {GetTotalCost():C}\n";
        return invoice;
    }
}
class Program
{
    static void Main(string[] args)
    {
        var address1 = new Address("123 leki", "Gwarinpa", "ABJ", "Nigeria", "12345");
        var customer1 = new Customer("Muna Uche", address1, "munauche@example.com", "555-1234");

        var address2 = new Address("1st Street", "Gwarinpa", "ABJ", "Nigeria", "67890");
        var customer2 = new Customer("Nmeso Fred", address2, "nmesofred@example.com", "555-5678");

        var product1 = new Product("Laptop", "ABC123", 10.99m, 2, "A small widget.");
        var product2 = new Product("Mouse", "DEF456", 5.99m, 3, "A handy gadget.");
        var product3 = new Product("Monitor", "GHI789", 7.99m, 1, "A mysterious thingamajig.");

        var order1 = new Order(customer1, 8.25m);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        var order2 = new Order(customer2, 8.25m);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine(order1.GetInvoice());

        Console.WriteLine("\nOrder 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine(order2.GetInvoice());
    }
}