using backend.Domain.Model.Abstract;

namespace backend.Domain.Model
{
    public class Participant : Entity
    {
        public Guid UserId { get; set; }
        public Guid BoardId { get; set; }

        public User User { get; set; }
        public Board Board { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
