using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.QueryProcessors
{
    public interface IUpdateTaskStatusQueryProcessor
    {
        void UpdateTaskStatus(Tasks taskToUpdate, string statusName);
    }
}
