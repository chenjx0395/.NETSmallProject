using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using Common.Attribute;
using DAL;
using Model;

namespace Common
{
    public class PermissionLoggingProxy<T> : RealProxy
    {
        
        private readonly T _target;

        public PermissionLoggingProxy(T decorated) : base(typeof(T))
        {
            _target = decorated;
        }

        public override IMessage Invoke(IMessage msg)
        {
            //获得被代理方法的信息
            var methodCall = msg as IMethodCallMessage;
            if (methodCall != null)
            {
                var method = (MethodInfo)methodCall.MethodBase;

                try
                {
                    // 执行原方法
                    var result = method.Invoke(_target, methodCall.InArgs);

                    // 获取实际方法上的特性
                    var targetMethod = _target.GetType().GetMethod(method.Name,
                        method.GetParameters().Select(p => p.ParameterType).ToArray());
                    var attribute = targetMethod?.GetCustomAttribute<PermissionOperationLogAttribute>();

                    if (attribute != null)
                    {
                        //构造日志对象
                        var permissionChangeLog = new PermissionChangeLog
                        {
                            FromUserId = GlobalContext.CurrentUser.UserId,
                            TargetType = attribute.TargetType,
                            ActionType = attribute.ActionType,
                            // 删除空白
                            Details = $@"用户ID：{GlobalContext.CurrentUser.UserId}；
                                        用户名:{GlobalContext.CurrentUser.Name}
                                        对{attribute.TargetType}表
                                        执行了{attribute.ActionType}操作。
                                        方法的参数：{string.Join(",", methodCall.InArgs)}
                                        ".Replace("\r\n", ""),
                            UpdateTime = DateTime.Now
                        };
                        LogToDatabase(permissionChangeLog);
                    }

                    return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
                }
                catch (Exception e)
                {
                    return new ReturnMessage(e, methodCall);
                }
            }
            return null;
        }

        private void LogToDatabase(PermissionChangeLog permissionChangeLog)
        {
            var permissionChangeLogDAL = new PermissionChangeLogDAL();
            permissionChangeLogDAL.AddPermissionChangeLog(permissionChangeLog);
        }
    }
}