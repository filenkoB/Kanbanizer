using backend.Domain.Model.Abstract;

namespace backend.Domain.Model
{
    public class Column : Entity
    {
        public string Name { get; set; }
        public int MaxTasks { get; set; } = 15;
        public int Order { get; set; } = 0;
        public Guid BoardId { get; set; }

        public Board Board { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
