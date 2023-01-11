using backend.Domain.Model;

namespace backend.Service.Interfaces.Repository.Read
{
    public interface IAuthReadRepository
    {
        public Task<User> ReadUserByCredentials(string login, string password);
    }
}
