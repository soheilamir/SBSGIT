using System;

namespace SBSWebProject.Common
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
    }
}
