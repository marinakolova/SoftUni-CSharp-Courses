using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string SuccessfulImportDepartmentsCells = "Imported {0} with {1} cells";
        private const string SuccessfulImportPrisonersMails = "Imported {0} {1} years old";
        private const string SuccessfulImportOfficersPrisoners = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            var departmentsToAdd = new List<Department>();

            var sb = new StringBuilder();

            foreach (var departmentDto in departmentDtos)
            {
                var isValidDto = IsValid(departmentDto);

                if (!isValidDto)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hasInvalidCell = false;
                var cellsToAdd = new List<Cell>();

                foreach (var cellDto in departmentDto.Cells)
                {
                    var isValidCellDto = IsValid(cellDto);

                    if (!isValidCellDto)
                    {
                        sb.AppendLine(ErrorMessage);
                        hasInvalidCell = true;
                        break;
                    }

                    cellsToAdd.Add(new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    });
                }

                if (hasInvalidCell)
                {
                    continue;
                }

                Department department = new Department
                {
                    Name = departmentDto.Name
                };

                foreach (var cell in cellsToAdd)
                {
                    department.Cells.Add(cell);
                }

                departmentsToAdd.Add(department);

                sb.AppendLine(string.Format(SuccessfulImportDepartmentsCells, department.Name, department.Cells.Count));
            }

            context.Departments.AddRange(departmentsToAdd);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonerDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            var prisonersToAdd = new List<Prisoner>();

            var sb = new StringBuilder();

            foreach (var prisonerDto in prisonerDtos)
            {
                var isValidDto = IsValid(prisonerDto);

                if (!isValidDto)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hasInvalidMail = false;
                var mailsToAdd = new List<Mail>();

                foreach (var mailDto in prisonerDto.Mails)
                {
                    var isValidMailDto = IsValid(mailDto);

                    if (!isValidMailDto)
                    {
                        sb.AppendLine(ErrorMessage);
                        hasInvalidMail = true;
                        break;
                    }

                    mailsToAdd.Add(new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    });
                }

                if (hasInvalidMail)
                {
                    continue;
                }

                Prisoner prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                if (prisonerDto.ReleaseDate != null)
                {
                    prisoner.ReleaseDate = DateTime.ParseExact(prisonerDto.ReleaseDate, @"dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                }

                foreach (var mail in mailsToAdd)
                {
                    prisoner.Mails.Add(mail);
                }

                prisonersToAdd.Add(prisoner);

                sb.AppendLine(string.Format(SuccessfulImportPrisonersMails, prisoner.FullName, prisoner.Age));
            }

            context.Prisoners.AddRange(prisonersToAdd);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));

            var officersDto = (ImportOfficerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var officers = new List<Officer>();
            var sb = new StringBuilder();

            foreach (var officerDto in officersDto)
            {
                if (!IsValid(officerDto)
                    || !Enum.IsDefined(typeof(Position), officerDto.Position)
                    || !Enum.IsDefined(typeof(Weapon), officerDto.Weapon))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hasInvalidPrisoner = false;
                var officerPrisoners = new List<OfficerPrisoner>();

                foreach (var officerPrisonersDto in officerDto.OfficerPrisoners)
                {
                    if (!IsValid(officerPrisonersDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        hasInvalidPrisoner = true;
                        break;
                    }

                    officerPrisoners.Add(new OfficerPrisoner
                    {
                        PrisonerId = officerPrisonersDto.PrisonerId
                    });
                }

                if (hasInvalidPrisoner)
                {
                    continue;
                }

                Officer officer = new Officer
                {
                    FullName = officerDto.FullName,
                    Salary = officerDto.Salary,
                    Position = Enum.Parse<Position>(officerDto.Position),
                    Weapon = Enum.Parse<Weapon>(officerDto.Weapon),
                    DepartmentId = officerDto.DepartmentId
                };

                foreach (var officerPrisoner in officerPrisoners)
                {
                    officer.OfficerPrisoners.Add(officerPrisoner);
                }

                officers.Add(officer);

                sb.AppendLine(string.Format(SuccessfulImportOfficersPrisoners, officer.FullName, officerPrisoners.Count));
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}