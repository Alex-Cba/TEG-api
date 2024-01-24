namespace TEG_api.Services.Interface
{
    public interface ICRUDService
    {
        public Task<T> GetAsync<T>();
        public Task<T> GetByIdAsync<T>(int Id);
        public Task<T> GetByGUIDAsync<T>(Guid Id);
        public Task<T> GetByFirstNameOrLastNameAsync<T>(string? FirstName, string? LastName);
        public Task<T> GetByOtherDataStringAsync<T>(string otherString);
        public Task<T> PostAsync<T>();

        public Task<T> PutAsync<T>();

        public Task<T> DeleteAsync<T>();

        public Task<T> PatchAstnc<T>();

        public Task<T> SoftDeleteAsync<T>();
    }
}
