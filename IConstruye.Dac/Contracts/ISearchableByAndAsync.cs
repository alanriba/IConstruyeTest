namespace IConstruye.Catalogos.Dac.Contracts
{
    public interface ISearchableByAndAsync<Filter, Entity>
    {
        public Task<IEnumerable<Entity>> SearchListByAndAsync(Filter filters);
        public Task<Entity> FirstByAndAsync(Filter filters);
    }
}
