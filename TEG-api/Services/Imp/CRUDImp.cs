using TEG_api.Data;
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
        public Task<T> GetAsync<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync<T>()
        {
            throw new NotImplementedException();
        }


        public Task<T> PatchAstnc<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> PostAsync<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> PutAsync<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> SoftDeleteAsync<T>()
        {
            throw new NotImplementedException();
        }
    }
}
