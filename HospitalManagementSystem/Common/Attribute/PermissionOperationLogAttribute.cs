using System;

namespace Common.Attribute
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PermissionOperationLogAttribute : System.Attribute
    {
        public string ActionType { get; }
        public string TargetType { get; }

        public PermissionOperationLogAttribute(string actionType, string targetType)
        {
            ActionType = actionType;
            TargetType = targetType;
        }
    }
}