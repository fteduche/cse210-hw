using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.words = new List<Word>();
        string[] wordsArray = text.Split(' ');
        foreach (string word in wordsArray)
        {
            this.words.Add(new Word(word));
        }
    }

    public Reference GetReference()
    {
        return reference;
    }

    public List<Word> GetWords()
    {
        return words;
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(words.Count);
            if (!words[index].GetIsHidden())
            {
                words[index].Hide();
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
        foreach (Word word in words)
        {
            text += word.GetDisplayText() + " ";
        }
        return text.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in words)
        {
            if (!word.GetIsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
