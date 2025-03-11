

namespace Service
{
    public interface IQueryService<in TIn, out TOut>
                     where TIn : IQuery
    {
        TOut Execute(TIn obj);
    }
}
