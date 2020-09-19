using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using SoftJail.DataProcessor.ExportDto;
using Formatting = Newtonsoft.Json.Formatting;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .Where(p => ids.Contains(p.Id))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .Select(p => new ExportPrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(op => new ExportPrisonerOfficersDto
                    {
                        OfficerName = op.Officer.FullName,
                        Department = op.Officer.Department.Name
                    })
                        .OrderBy(o => o.OfficerName)
                        .ToList(),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(op => op.Officer.Salary)
                })
                .ToList();

            var jsonString = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return jsonString;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var prisoners = context
                .Prisoners
                .Where(p => names.Contains(p.FullName))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .Select(p => new ExportPrisonerMailsDto()
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString(@"yyyy-MM-dd"),
                    EncryptedMessages = p.Mails.Select(m => new ExportEncryptedMessageDto
                        {
                            Description = Reverse(m.Description)
                        })
                        .ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportPrisonerMailsDto[]), new XmlRootAttribute("Prisoners"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), prisoners, namespaces);

            return sb.ToString().TrimEnd();
        }

        private static string Reverse(string description)
        {
            char[] charArray = description.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}