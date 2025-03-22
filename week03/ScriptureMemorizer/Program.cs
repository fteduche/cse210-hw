using System;
using System.Collections.Generic;

public class Reference
{
    public string Book { get; set; }
    public int Chapter { get; set; }
    public int Verse { get; set; }
    public int EndVerse { get; set; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        Verse = verse;
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        Verse = verse;
        EndVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (EndVerse == 0)
        {
            return $"{Book} {Chapter}:{Verse}";
        }
        else
        {
            return $"{Book} {Chapter}:{Verse}-{EndVerse}";
        }
    }
}

public class Word
{
    public string Text { get; set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public void Show()
    {
        IsHidden = false;
    }

    public string GetDisplayText()
    {
        if (IsHidden)
        {
            return new string('_', Text.Length);
        }
        else
        {
            return Text;
        }
    }
}

public class Scripture
{
    public Reference Reference { get; set; }
    public List<Word> Words { get; set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = new List<Word>();
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            Words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(Words.Count);
            if (!Words[index].IsHidden)
            {
                Words[index].Hide();
            }
            else
            {
                i--;
            }
        }
    }

    public string GetDisplayText()
    {
        string text = "";
        foreach (Word word in Words)
        {
            text += word.GetDisplayText() + " ";
        }
        return text.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in Words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life");
        Console.WriteLine(scripture.Reference.GetDisplayText());
        Console.WriteLine(scripture.GetDisplayText());
        scripture.HideRandomWords(5);
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine(scripture.IsCompletelyHidden());
    }
}

