using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.QueryProcessors
{
    public interface IAllTasksQueryProcessor
    {
        QueryResult<Tasks> GetTasks(PagedDataRequest requestInfo);
    }
}
