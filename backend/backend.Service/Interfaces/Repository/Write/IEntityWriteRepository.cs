using backend.Domain.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Service.Interfaces.Repository.Write
{
    public interface IEntityWriteRepository<T> where T : Entity
    {
        public Task<T> AddEntity(T entity);
        public Task<T> UpdateEntity(T entity);
        public Task<bool> DeleteEntity(Guid entityId);
    }
}
