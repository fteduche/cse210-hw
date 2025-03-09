using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Job job3 = new Job();
        job3._jobTitle = "Developer";
        job3._company = "OUF";
        job3._startYear = 2023;
        job3._endYear = 2024;

        Job job4 = new Job();
        job4._jobTitle = "Junior Developer";
        job4._company = "Repsunny";
        job4._startYear = 2024;
        job4._endYear = 2025;

        Resume resume = new Resume();
        resume._name = "Allison Rose";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume._jobs.Add(job3);
        resume._jobs.Add(job4);

        resume.Display();
    }
}