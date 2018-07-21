using System;

namespace SBSWebProject.Common
{
    public class BusinessRuleViolationException : Exception
    {
        public BusinessRuleViolationException(string incorrectTaskStatus) :
        base(incorrectTaskStatus)
        {
        }
    }
}
