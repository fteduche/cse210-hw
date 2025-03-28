using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var video1 = new Video("Video 1", "Author 1", 300);
        video1.AddComment(new Comment("John Doe", "Great video!"));
        video1.AddComment(new Comment("Jane Doe", "I agree, very informative."));

        var video2 = new Video("Video 2", "Author 2", 240);
        video2.AddComment(new Comment("Alice Johnson", "Love the music!"));
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