using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            int hourForExam = int.Parse(Console.ReadLine());
            int minutesForExam = int.Parse(Console.ReadLine());
            int hourWhenWeAreThere = int.Parse(Console.ReadLine());
            int minutesWhenWeAreThere = int.Parse(Console.ReadLine());

            //правим часът на изпита в минути
            int totalMinutesForExam = hourForExam * 60;
            totalMinutesForExam += minutesForExam;

            //правим часът на пристигане за изпита в минути
            int totalMinutesWhenWeAreThere = hourWhenWeAreThere * 60;
            totalMinutesWhenWeAreThere += minutesWhenWeAreThere;

            //променлива да си запазим разликата в минути
            int timeDiffInMinutes = 0;

            //променливи в които да си запишем изхода
            string result = string.Empty;
            string totalResult = string.Empty;

            //абсолютната стойност на разликата в минути (за да не се получава отрицателна стойност)
            timeDiffInMinutes = Math.Abs(totalMinutesWhenWeAreThere - totalMinutesForExam);

            //проверката в която закъсняваме
            if (totalMinutesForExam < totalMinutesWhenWeAreThere)
            {
                result = "Late";
                //ако нямаме цял час
                if (timeDiffInMinutes <= 59)
                {
                    //към totalResult запиваме с колко минути закъсняваме
                    totalResult = $"{timeDiffInMinutes} minutes after the start";
                }
                //ако имаме поне един цял час
                else
                {
                    // присмятаме си колко часа имаме и колко минути
                    int hours = timeDiffInMinutes / 60;
                    int mins = timeDiffInMinutes % 60;

                    //към totalResult запиваме с колко часове и минути закъсняваме
                    totalResult = $"{hours}:{mins:D2} hours after the start";
                }
            }
            //ако сме навреме или подранили
            else if (totalMinutesForExam >= totalMinutesWhenWeAreThere)
            {
                //проверката дали смеподранили
                if (timeDiffInMinutes > 30)
                {
                    //записваме си че сме подранили в променливата result
                    result = "Early";
                    if (timeDiffInMinutes <= 59)
                    {
                        //към totalResult запиваме с колко минути сме подранили
                        totalResult = $"{timeDiffInMinutes} minutes before the start";
                    }
                    //ако имаме поне един цял час
                    else
                    {
                        // присмятаме си колко часа имаме и колко минути
                        int hours = timeDiffInMinutes / 60;
                        int mins = timeDiffInMinutes % 60;

                        //към totalResult запиваме с колко часове и минути сме подранили
                        totalResult = $"{hours}:{mins:D2} hours before the start";
                    }
                }
                else
                {
                    //записваме си че сме навреме в променливата result
                    result = "On time";

                    //към totalResult запиваме с колко минути сме навреме
                    totalResult = $"{timeDiffInMinutes} minutes before the start";

                    //TODO: тук сме сигурни, че няма да имаме повече от 30 минути и не ни е нужно да проверяваме дали имаме цял час
                }
            }

            //принтираме резултатите
            Console.WriteLine(result);
            Console.WriteLine(totalResult);
        }
    }
}
