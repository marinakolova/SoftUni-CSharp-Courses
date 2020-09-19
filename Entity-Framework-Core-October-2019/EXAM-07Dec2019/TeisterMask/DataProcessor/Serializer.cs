namespace TeisterMask.DataProcessor
{
    using Data;
    using ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            //Export all projects that have at least one task.
            //For each project, export its name, tasks count, and if it has end(due) date which is represented like "Yes" and "No".
            //For each task, export its name and label type.
            //Order the tasks by name(ascending).
            //Order the projects by tasks count(descending), then by name(ascending).

            var projects = context
                .Projects
                .Where(p => p.Tasks.Count > 0)
                .OrderByDescending(p => p.Tasks.Count)
                .ThenBy(p => p.Name)
                .Select(p => new ExportProjectDto
                {
                    ProjectName = p.Name,
                    TasksCount = p.Tasks.Count,
                    HasEndDate = HasEndDate(p.DueDate),
                    Tasks = p.Tasks
                        .OrderBy(t => t.Name)
                        .Select(t => new ExportProjectTasksDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                        .ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            //Select the top 10 employees who have at least one task that its open date is after or equal to the given date
            //with their tasks that meet the same requirement(to have their open date after or equal to the giver date).
            //For each employee, export their username and their tasks.
            //For each task, export its name and open date(must be in format "d"), due date(must be in format "d"), label and execution type.
            //Order the tasks by due date(descending), then by name(ascending).
            //Order the employees by all tasks count(descending), then by username(ascending).
            //    NOTE: Do not forget to use CultureInfo.InvariantCulture

            var employees = context
                .Employees
                .Where(e => e.EmployeesTasks.Any(x => x.Task.OpenDate >= date))
                .OrderByDescending(e => e.EmployeesTasks.Count(x => x.Task.OpenDate >= date))
                .ThenBy(e => e.Username)
                .Take(10)
                .Select(e => new ExportEmployeeDto
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(et => et.Task.OpenDate >= date)
                        .OrderByDescending(et => et.Task.DueDate)
                        .ThenBy(et => et.Task.Name)
                        .Select(et => new ExportEmployeeTasksDto
                    {
                            TaskName = et.Task.Name,
                            OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = et.Task.LabelType.ToString(),
                            ExecutionType = et.Task.ExecutionType.ToString()
                    })
                        .ToArray()
                })
                .ToList();

            var jsonString = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return jsonString;
        }

        private static string HasEndDate(DateTime? date)
        {
            if (date == null)
            {
                return "No";
            }

            return "Yes";
        }
    }
}