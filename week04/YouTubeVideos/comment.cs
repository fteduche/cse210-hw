using System;

public class Comment
{
    private string _name;
    private string _text;
    private DateTime _date;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
        _date = DateTime.Now;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetText()
    {
        return _text;
    }

    public DateTime GetDate()
    {
        return _date;
    }
}