namespace TeisterMask.DataProcessor
{
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectWithTasksDto[]), 
                new XmlRootAttribute("Projects"));

            var projectsDto = (ImportProjectWithTasksDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var projects = new List<Project>();
            var sb = new StringBuilder();

            foreach (var projectDto in projectsDto)
            {
                if (!IsValid(projectDto)
                    || !IsValidDate(projectDto.OpenDate, false)
                    || !IsValidDate(projectDto.DueDate, true))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var tasks = new List<Task>();

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto)
                        || !IsValidDate(taskDto.OpenDate, false)
                        || !IsValidDate(taskDto.DueDate, false)
                        || !Enum.IsDefined(typeof(ExecutionType), taskDto.ExecutionType)
                        || !Enum.IsDefined(typeof(LabelType), taskDto.LabelType))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = DateTime.ParseExact(taskDto.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture),
                        DueDate = DateTime.ParseExact(taskDto.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };

                    if (task.OpenDate < DateTime.ParseExact(projectDto.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)
                        || (projectDto.DueDate != null 
                         && task.DueDate > DateTime.ParseExact(projectDto.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    tasks.Add(task);
                }

                Project project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = DateTime.ParseExact(projectDto.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)
                };

                if (projectDto.DueDate == null)
                {
                    project.DueDate = null;
                }
                else
                {
                    project.DueDate =
                            DateTime.ParseExact(projectDto.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                foreach (var task in tasks)
                {
                    project.Tasks.Add(task);
                }

                projects.Add(project);

                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var employees = new List<Employee>();

            var sb = new StringBuilder();

            foreach (var employeeDto in employeesDto)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var taskIds = new List<int>();

                foreach (var taskId in employeeDto.Tasks)
                {
                    var isValidTask = true;
                    
                    if (context.Tasks.FirstOrDefault(t => t.Id == taskId) == null)
                    {
                        isValidTask = false;
                    }

                    if (isValidTask && !taskIds.Contains(taskId))
                    {
                        taskIds.Add(taskId);
                    }
                    else if (!isValidTask)
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                }

                Employee employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (var taskId in taskIds)
                {
                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        TaskId = taskId
                    });
                }

                employees.Add(employee);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static bool IsValidDate(string dateString, bool canBeNull)
        {
            if (canBeNull == true && dateString == null)
            {
                return true;
            }

            try
            {
                var tryToParse = DateTime.ParseExact(dateString, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}