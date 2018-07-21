using System.Collections.Generic;
using SBSWebProject.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace SBSWebProject.Data.QueryProcessors
{
    public interface IUpdateTaskQueryProcessor
    {
        Tasks GetUpdatedTask(long taskId, PropertyValueMapType updatedPropertyValueMap);
        Tasks ReplaceTaskUsers(long taskId, IEnumerable<long> userIds);
        Tasks DeleteTaskUsers(long taskId);
        Tasks AddTaskUser(long taskId, long userId);
        Tasks DeleteTaskUser(long taskId, long userId);
    }
}
