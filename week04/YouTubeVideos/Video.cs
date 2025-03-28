using System;
using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;
    private int _views;
    private int _likes;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
        _views = 0;
        _likes = 0;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentsCount()
    {
        return _comments.Count;
    }

    public void DisplayComments()
    {
        foreach (var comment in _comments)
        {
            Console.WriteLine($"Comment by {comment.GetName()} on {comment.GetDate()}: {comment.GetText()}");
        }
    }

    public void View()
    {
        _views++;
        Console.WriteLine($"You are watching: {_title}");
    }

    public void Like()
    {
        _likes++;
        Console.WriteLine($"You liked: {_title}");
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Views: {_views}");
        Console.WriteLine($"Likes: {_likes}");
        Console.WriteLine($"Comment Count: {GetCommentsCount()}");
        DisplayComments();
    }
}
