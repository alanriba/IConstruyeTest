﻿namespace IConstruye.Catalogos.Dac.Contracts
{
    public interface IDataContract<T>
    {
        Task<IEnumerable<T>> ListAsync();
        Task<IEnumerable<T>> ListQueryAsync(T obj);
        Task<IEnumerable<T>> ListQueryAsync(int id);
        Task<int> CreateAsync(T obj);
        Task<bool> CreateMultipleAsync(IEnumerable<T> list);
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(T obj);
        Task<T> ReadAsync(int id);
        Task<T> ReadAsync(T obj);
        Task<bool> ExistsAsync(T obj);
    }
}
