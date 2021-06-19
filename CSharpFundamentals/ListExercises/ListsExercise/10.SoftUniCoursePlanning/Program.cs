using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine().Split(", ").ToList();

            string command = Console.ReadLine();

            while (command!="course start")
            {
                string[] arguments = command.Split(":");

                string action = arguments[0];
                string lessonTitle = arguments[1];

                switch (action)
                {
                    case "Add":
                        if (!schedule.Contains(lessonTitle))
                        {
                            schedule.Add(lessonTitle);
                        }
                        break;

                    case "Insert":
                        int index = int.Parse(arguments[2]);
                        if (!schedule.Contains(lessonTitle))
                        {
                            schedule.Insert(index,lessonTitle);
                        }
                        break;

                    case "Remove":
                        if (schedule.Contains(lessonTitle))
                        {
                            schedule.RemoveAll(x=>x.Contains(lessonTitle));
                        }
                        break;

                    case "Swap":
                        string secondLessonTitle = arguments[2];

                        if (schedule.Contains(lessonTitle) && schedule.Contains(secondLessonTitle))
                        {
                            int indexOfFirst = schedule.IndexOf(lessonTitle);
                            int indexOfSecond = schedule.IndexOf(secondLessonTitle);

                            List<string> firstLessonHelper = schedule.Where(x => x.Contains(lessonTitle)).ToList();
                            List<string> secondLessonHelper = schedule.Where(x => x.Contains(secondLessonTitle)).ToList();

                            schedule.RemoveAll(x => x.Contains(lessonTitle));
                            schedule.InsertRange(indexOfSecond, firstLessonHelper);

                            schedule.RemoveAll(x => x.Contains(secondLessonTitle));
                            schedule.InsertRange(indexOfFirst, secondLessonHelper);
                        }
                        break;

                    case "Exercise":
                        string exercise = $"{lessonTitle}-Exercise";

                        if (schedule.Contains(lessonTitle) && !schedule.Contains(exercise))
                        {
                            int indexOfLesson = schedule.IndexOf(lessonTitle);

                            schedule.Insert(indexOfLesson + 1, exercise);
                        }
                        else if(!schedule.Contains(lessonTitle) && !schedule.Contains(exercise))
                        {
                            schedule.Add(lessonTitle);
                            schedule.Add(exercise);
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i+1}.{schedule[i]}");
            }
        }
    }
}
