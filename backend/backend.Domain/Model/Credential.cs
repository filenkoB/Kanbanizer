using backend.Domain.Model.Abstract;

namespace backend.Domain.Model
{
    public class Credential : Entity
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
