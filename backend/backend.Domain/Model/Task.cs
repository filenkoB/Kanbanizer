using backend.Domain.Model.Abstract;

namespace backend.Domain.Model
{
    public class Task : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Guid ColumnId { get; set; }
        public Guid OwnerId { get; set; }

        public Column Column { get; set; }
        public Participant Owner { get; set; }
    }
}
