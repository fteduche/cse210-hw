using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }
    public int Views { get; set; }
    public int Likes { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
        Views = 0;
        Likes = 0;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayComments()
    {
        foreach (var comment in Comments)
        {
            Console.WriteLine($"Comment by {comment.Name} on {comment.Date}: {comment.Text}");
        }
    }

    public void View()
    {
        Views++;
        Console.WriteLine($"You are watching: {Title}");
    }

    public void Like()
    {
        Likes++;
        Console.WriteLine($"You liked: {Title}");
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Views: {Views}");
        Console.WriteLine($"Likes: {Likes}");
        Console.WriteLine($"Comment Count: {GetCommentCount()}");
        DisplayComments();
    }
}