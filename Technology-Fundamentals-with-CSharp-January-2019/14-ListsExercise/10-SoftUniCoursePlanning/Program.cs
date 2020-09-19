using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "course start")
                {
                    break;
                }

                string[] partsOfCommand = command.Split(':').ToArray();
                string lessonTitle = partsOfCommand[1];

                switch (partsOfCommand[0])
                {
                    case "Add":
                        if (!schedule.Contains(lessonTitle))
                        {
                            schedule.Add(lessonTitle);
                        }
                        break;

                    case "Insert":
                        int index = int.Parse(partsOfCommand[2]);
                        if (!schedule.Contains(lessonTitle))
                        {
                            schedule.Insert(index, lessonTitle);
                        }
                        break;

                    case "Remove":
                        if (schedule.Contains(lessonTitle))
                        {
                            schedule.Remove(lessonTitle);
                            string exerciseToRemove = lessonTitle + "-Exercise";
                            if (schedule.Contains(exerciseToRemove))
                            {
                                schedule.Remove(exerciseToRemove);
                            }
                        }
                        break;

                    case "Swap":
                        string lessonToSwapWith = partsOfCommand[2];
                        if (schedule.Contains(lessonTitle) && schedule.Contains(lessonToSwapWith))
                        {
                            int indexOfLesson = schedule.IndexOf(lessonTitle);
                            int indexOfLessonToSwapWith = schedule.IndexOf(lessonToSwapWith);
                            schedule[indexOfLesson] = lessonToSwapWith;
                            schedule[indexOfLessonToSwapWith] = lessonTitle;

                            string exerciceOfLesson = lessonTitle + "-Exercise";
                            string exerciseOfLessonToSwapWith = lessonToSwapWith + "-Exercise";

                            if (schedule.Contains(exerciceOfLesson))
                            {
                                int indexOfExerciseOfLesson = schedule.IndexOf(exerciceOfLesson);
                                schedule.RemoveAt(indexOfExerciseOfLesson);
                                schedule.Insert(indexOfLessonToSwapWith + 1, exerciceOfLesson);
                                
                            }
                            if (schedule.Contains(exerciseOfLessonToSwapWith))
                            {
                                int indexOfExerciseOfLessonToSwapWith = schedule.IndexOf(exerciseOfLessonToSwapWith);
                                schedule.RemoveAt(indexOfExerciseOfLessonToSwapWith);
                                schedule.Insert(indexOfLesson + 1, exerciseOfLessonToSwapWith);                                
                            }
                        }
                        break;

                    case "Exercise":
                        string exersiceToAdd = lessonTitle + "-Exercise";
                        if (schedule.Contains(lessonTitle) && !schedule.Contains(exersiceToAdd))
                        {
                            int indexOfLessonToAddExercise = schedule.IndexOf(lessonTitle);
                            schedule.Insert(indexOfLessonToAddExercise + 1, exersiceToAdd);
                        }
                        else if (!schedule.Contains(lessonTitle))
                        {
                            schedule.Add(lessonTitle);
                            schedule.Add(exersiceToAdd);
                        }
                        break;
                }
            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }
    }
}
