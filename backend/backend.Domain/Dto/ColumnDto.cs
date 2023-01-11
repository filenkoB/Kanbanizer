namespace backend.Domain.Dto
{
    public class ColumnDto : EntityDto
    {
        public string Name { get; set; }
        public int MaxTasks { get; set; }
        public int Order { get; set; }
    }
}
