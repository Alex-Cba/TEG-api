using TEG_api.Data;
using TEG_api.Services.Interface;

namespace TEG_api.Services.Imp
{
    public class GameSynchronizer : IGameSynchronizer
    {
        private readonly TEGContext _db;

        public GameSynchronizer(TEGContext db)
        {
            _db = db;
        }

        public async Task<bool> Synchronize()
        {
            throw new NotImplementedException();
        }
    }
}
