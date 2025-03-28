using System;
using System.Collections.Generic;

public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
        Date = DateTime.Now;
    }
}

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

class Program
{
    static void Main(string[] args)
    {
        var video1 = new Video("Video 1", "Author 1", 300);
        video1.AddComment(new Comment("Muna Uche", "Great video!"));
        video1.AddComment(new Comment("Nmeso CHim", "I agree, very informative."));

        var video2 = new Video("Video 2", "Author 2", 240);
        video2.AddComment(new Comment("Praise Johnson", "Love the music!"));
        video2.AddComment(new Comment("Mike Davis", "Very engaging video."));

        var video3 = new Video("Video 3", "Author 3", 420);
        video3.AddComment(new Comment("David Lee", "Excellent content!"));
        video3.AddComment(new Comment("Sophia Patel", "Well done!"));

        var videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            video.DisplayDetails();
            video.View();
            video.Like();
            Console.WriteLine();
        }
    }
}
