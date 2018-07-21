using NHibernate;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.QueryProcessors;

namespace SBSWebProject.Data.SqlServer.QueryProcessors
{
    public class TaskByIdQueryProcessor : ITaskByIdQueryProcessor
    {
        private readonly ISession _session;
        public TaskByIdQueryProcessor(ISession session)
        {
            _session = session;
        }
        public Tasks GetTask(long taskId)
        {
            var task = _session.Get<Tasks>(taskId);
            return task;
        }
    }
}
