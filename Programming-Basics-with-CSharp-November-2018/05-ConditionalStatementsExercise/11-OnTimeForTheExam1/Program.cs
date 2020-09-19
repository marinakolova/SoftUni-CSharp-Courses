using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_OnTimeForTheExam1
{
    class Program
    {
        static void Main(string[] args)
        {
                int hourForExam = int.Parse(Console.ReadLine());
                int minutesForExam = int.Parse(Console.ReadLine());
                int hourWhenWeAreThere = int.Parse(Console.ReadLine());
                int minutesWhenWeAreThere = int.Parse(Console.ReadLine());

                int totalMinutesForExam = hourForExam * 60;
                totalMinutesForExam += minutesForExam;

                int totalMinutesWhenWeAreThere = hourWhenWeAreThere * 60;
                totalMinutesWhenWeAreThere += minutesWhenWeAreThere;

                int timeDiffInMinutes = 0;

                string result = string.Empty;
                string totalResult = string.Empty;

                timeDiffInMinutes = Math.Abs(totalMinutesWhenWeAreThere - totalMinutesForExam);

                if (totalMinutesForExam < totalMinutesWhenWeAreThere)
                {
                    result = "Late";

                    if (timeDiffInMinutes <= 59)
                    {
                        totalResult = $"{timeDiffInMinutes} minutes after the start";
                    }

                    else
                    {
                        int hours = timeDiffInMinutes / 60;
                        int mins = timeDiffInMinutes % 60;

                        totalResult = $"{hours}:{mins:D2} hours after the start";
                    }
                }

                else if (totalMinutesForExam >= totalMinutesWhenWeAreThere)
                {
                    if (timeDiffInMinutes > 30)
                    {
                        result = "Early";
                        if (timeDiffInMinutes <= 59)
                        {
                            totalResult = $"{timeDiffInMinutes} minutes before the start";
                        }

                        else
                        {
                            int hours = timeDiffInMinutes / 60;
                            int mins = timeDiffInMinutes % 60;

                            totalResult = $"{hours}:{mins:D2} hours before the start";
                        }
                    }

                    else
                    {
                        result = "On time";

                        totalResult = $"{timeDiffInMinutes} minutes before the start";
                    }
                }

                Console.WriteLine(result);
                Console.WriteLine(totalResult);
           
        }
    }
}
