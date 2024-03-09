namespace SuperMarket.BL
{
    public interface IGenricService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);

        Task delete(int id);

    }
}