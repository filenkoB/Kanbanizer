using backend.DBEngine;
using backend.Domain.Model.Abstract;
using backend.Service.Interfaces.Repository.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace backend.Service.Repository.Write
{
    public class EntityWriteRepository<T> : IEntityWriteRepository<T> where T : Entity
    {
        private readonly CanbanDbContext _db;

        public EntityWriteRepository(CanbanDbContext db) {
            _db = db;
        }

        public async Task<T> AddEntity(T entity) {
            EntityEntry<T> insertedEntity = await _db.Set<T>().AddAsync(entity);
            return insertedEntity.Entity;
        }

        public async Task<T> UpdateEntity(T entity) {
            var updatedEntity = await Task.Run<EntityEntry<T>>(() => {
                return _db.Set<T>().Update(entity);
            });
            return updatedEntity.Entity;
        }

        public async Task<bool> DeleteEntity(Guid entityId) {
            return await Task.Run<bool>(async () => {
                T? entity = await _db.Set<T>().FirstOrDefaultAsync(e => e.Id == entityId);
                if (entity == null) {
                    return false;
                }
                _db.Set<T>().Remove(entity);
                return true;
            });
        }
    }
}
