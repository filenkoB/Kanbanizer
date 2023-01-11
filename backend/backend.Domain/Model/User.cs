using backend.Domain.Model.Abstract;

namespace backend.Domain.Model
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime RegisteredOn { get; set; }

        public Credential Credential { get; set; }
        public ICollection<Participant> Participants { get; set; }
    }
}
