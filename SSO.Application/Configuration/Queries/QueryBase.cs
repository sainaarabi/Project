namespace SSO.Application.Configuration.Queries
{
    public abstract class QueryBase
    {
        public Guid Id { get; }

        protected QueryBase()
        {
        }
    }

    public abstract class QueryBase<TResult> : IQuery<TResult>
    {
        public int Page { get; set; } = 1;
        public int Count { get; set; } = 15;

        protected QueryBase(int page = 1, int count = 15)
        {
            if (page >= 1)
                page--;
            if (page <= 0)
                page = 0;
            Page = page;
            if (count <= 0)
                count = 15;
            if (count >= 200)
                count = 200;
            Count = count;
            Page = Page * Count;
        }
    }
}
