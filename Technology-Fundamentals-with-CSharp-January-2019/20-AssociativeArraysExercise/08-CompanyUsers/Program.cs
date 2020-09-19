using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfCompanies = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] partsOfCommand = command.Split(" -> ");
                string companyName = partsOfCommand[0];
                string employeeId = partsOfCommand[1];

                if (listOfCompanies.ContainsKey(companyName))
                {
                    if (!listOfCompanies[companyName].Contains(employeeId))
                    {
                        listOfCompanies[companyName].Add(employeeId);
                    }
                }
                else
                {
                    listOfCompanies.Add(companyName, new List<string>());
                    listOfCompanies[companyName].Add(employeeId);
                }
            }

            foreach (var company in listOfCompanies.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{company.Key}");

                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
