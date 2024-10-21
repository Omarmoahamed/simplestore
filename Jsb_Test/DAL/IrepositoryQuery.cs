namespace Jsb_Test.DAL
{
    public interface IrepositoryQuery<T> where T : class
    {
        public Task<T> findasync(int id);

        public Task<IEnumerable<T>> findallasync();

    }
}
