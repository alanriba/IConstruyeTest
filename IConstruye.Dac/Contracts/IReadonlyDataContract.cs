namespace IConstruye.Catalogos.Dac.Contracts
{
    public interface IReadOnlyDataContract<T>
    {
        Task<IEnumerable<T>> ListAsync();
        Task<T> ReadAsync(int id);
    }
}
