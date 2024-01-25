using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TEG_api.Data;
using TEG_api.Middleware.Exceptions;
using TEG_api.Services.Interface;

namespace TEG_api.Services.Imp
{
    public class CRUDImp : ICRUDService
    {
        private readonly TEGContext _db;

        public CRUDImp(TEGContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckExists<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var checkExists = await _db.Set<T>().AnyAsync(predicate);

            if (checkExists)
            {
                throw new ExceptionBadRequestClient("Already exists");
            }
            return false;
        }

        public async Task<bool> DeleteAsync<T>(T id) where T : class
        {
            var entity = await _db.Set<T>().FindAsync(id);

            if(entity != null)
            {
                _db.Set<T>().Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new KeyNotFoundException($"Not found entity to delete, with {id}");
            }
        }

        public async Task<T> GetAsync<T>() where T : class
        {
            var entity = await _db.Set<T>().FirstOrDefaultAsync();

            if (entity != null)
            {
                return entity;
            }
            else
            {
                throw new KeyNotFoundException("Not found entity");
            }
        }

        public async Task<T> GetByIdAsync<T>(T id) where T : class
        {
            var entity = await _db.Set<T>().FindAsync(id);

            if (entity != null)
            {
                return entity;
            }
            else
            {
                throw new KeyNotFoundException($"Not found entity with ID {id}");
            }
        }

        public async Task<bool> PatchAsync<T>(Expression<Func<T, bool>> predicate, string fieldName, object newValue) where T : class
        {
            var entity = await _db.Set<T>().FirstOrDefaultAsync(predicate);

            if (entity != null)
            {
                var propertyInfo = typeof(T).GetProperty(fieldName);

                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(entity, Convert.ChangeType(newValue, propertyInfo.PropertyType));

                    await _db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new ArgumentException($"Not found entity with name {fieldName} in entity {typeof(T).Name}");
                }
            }
            else
            {
                throw new ArgumentException($"No entity was found that meets the specified predicate");
            }
        }

        public async Task<T> PostAsyncNotDuplicate<T>(T entity) where T : class
        {
            await CheckExists<T>(e => e.Equals(entity));

            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<T> PostAsyncDuplicate<T>(T entity) where T : class
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<T> PutAsync<T>(T entity) where T : class
        {
            var entityToUpdate = await _db.Set<T>().Where(e => e.Equals(entity)).FirstOrDefaultAsync();

            if(entityToUpdate != null)
            {
                _db.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                await _db.SaveChangesAsync();
                return entityToUpdate;
            }
            else
            {
                throw new KeyNotFoundException($"Entity not found with the provided key values.");
            };
        }

        public async Task<bool> SoftDeleteAsync<T>(T id) where T : class
        {
            var entity = await _db.Set<T>().FindAsync(id);

            if (entity != null)
            {

                Type entityType = entity.GetType();

                var propertyInfo = entityType.GetProperty("IsActive");

                if (propertyInfo != null && propertyInfo.PropertyType == typeof(bool))
                {
                    var value = (bool)propertyInfo.GetValue(entity);

                    propertyInfo.SetValue(entity, !value);

                    await _db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new ArgumentException($"The entity cannot be deactivated or activated");
                }
            }
            else
            {
                throw new ArgumentException($"No found entity with ID {id}");
            }
        }
    }
}
