using NHibernate;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.QueryProcessors;

namespace SBSWebProject.Data.SqlServer.QueryProcessors
{
    public class AllTasksQueryProcessor : IAllTasksQueryProcessor
    {
        private readonly ISession _session;
        public AllTasksQueryProcessor(ISession session)
        {
            _session = session;
        }
        public QueryResult<Tasks> GetTasks(PagedDataRequest requestInfo)
        {
            var query = _session.QueryOver<Tasks>();
            var totalItemCount = query.ToRowCountQuery().RowCount();
            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber,
            requestInfo.PageSize);
            var tasks = query.Skip(startIndex).Take(requestInfo.PageSize).List();
            var queryResult = new QueryResult<Tasks>(tasks, totalItemCount, requestInfo.PageSize);
            return queryResult;
        }
    }
}
