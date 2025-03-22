using System;

public class Reference
{
    private string book;
    private int chapter;
    private int verse;
    private int endVerse;

    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.verse = verse;
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.verse = verse;
        this.endVerse = endVerse;
    }

    public string GetBook()
    {
        return book;
    }

    public int GetChapter()
    {
        return chapter;
    }

    public int GetVerse()
    {
        return verse;
    }

    public int GetEndVerse()
    {
        return endVerse;
    }

    public string GetDisplayText()
    {
        if (endVerse == 0)
        {
            return $"{book} {chapter}:{verse}";
        }
        else
        {
            return $"{book} {chapter}:{verse}-{endVerse}";
        }
    }
}
