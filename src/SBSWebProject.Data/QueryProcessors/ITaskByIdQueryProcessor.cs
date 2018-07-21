using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.QueryProcessors
{
    public interface ITaskByIdQueryProcessor
    {
        Tasks GetTask(long taskId);
    }
}
