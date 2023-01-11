using backend.Domain.Model.Abstract;

namespace backend.Domain.Model
{
    public class Board : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }

        public ICollection<Participant> Participants { get; set; }
    }
}
