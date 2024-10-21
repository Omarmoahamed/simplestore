namespace Jsb_Test.DAL
{
    public interface Irepository<T> where T : class
    {
        public Task Addasync(T entity);

        public void Delete(T entity);

        public Task<T?> Findasync(int id);

        public void  update(T entity);

        public Task saveasync();

    }
}
