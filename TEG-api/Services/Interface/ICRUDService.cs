using System.Linq.Expressions;

namespace TEG_api.Services.Interface
{
    public interface ICRUDService
    {
        public Task<List<T>> GetAsync<T>() where T : class;

        public Task CheckValidator<T>(T requestCommand) where T : class;

        public Task<T> GetByIdAsync<T>(string id) where T : class;

        public Task<T> PostAsyncNotDuplicate<T>(T entity) where T : class;
        
        public Task<T> PostAsyncDuplicate<T>(T entity) where T : class;

        public Task<T> PutAsync<T>(T entity) where T : class;

        public Task<bool> DeleteAsync<T>(string id) where T : class;

        public Task<bool> SoftDeleteAsync<T>(T entityWithId) where T : class;

        public Task<bool> PatchAsync<T>(Expression<Func<T, bool>> predicate, string fieldName, object newValue) where T : class;

        public Task<bool> CheckNotExists<T>(string id) where T : class;
        public Task<bool> CheckExists<T>(string id) where T : class;

    }
}
