using System;
namespace IConstruye.Dac.Contracts
{

    public interface IWriteOnlyDataContract<T>
    {
            Task<T> CreateAsync(T entity);
            Task<T> UpdateAsync(T entity);
        }
   
}

