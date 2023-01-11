namespace backend.Domain.Dto
{
    public class BoardDto : EntityDto {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
    }
}
