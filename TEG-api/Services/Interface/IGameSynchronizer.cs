namespace TEG_api.Services.Interface
{
    public interface IGameSynchronizer
    {
        public Task<bool> Synchronize();
    }
}
