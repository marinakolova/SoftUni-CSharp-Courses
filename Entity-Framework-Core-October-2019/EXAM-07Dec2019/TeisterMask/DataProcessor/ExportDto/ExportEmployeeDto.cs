namespace TeisterMask.DataProcessor.ExportDto
{
    public class ExportEmployeeDto
    {
        public string Username { get; set; }

        public ExportEmployeeTasksDto[] Tasks { get; set; }
    }
}
