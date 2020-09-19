namespace SoftJail.DataProcessor.ExportDto
{
    using System.Collections.Generic;

    public class ExportPrisonerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CellNumber { get; set; }

        public ICollection<ExportPrisonerOfficersDto> Officers { get; set; }

        public decimal TotalOfficerSalary { get; set; }
    }
}
