using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.QueryProcessors
{
    public interface IAddTaskQueryProcessor
    {
        void AddTask(Tasks task);
    }
}
