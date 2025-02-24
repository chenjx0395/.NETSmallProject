using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Common.Attribute;
using Model;

namespace HospitalManagementSystem
{
    public class SecureForm : Form
    {
        private readonly Dictionary<Delegate, Delegate> _originalHandlers = new Dictionary<Delegate, Delegate>();

        protected override void OnLoad(EventArgs e)
        {
            HookSecureEvents();
            base.OnLoad(e);
        }

        private void HookSecureEvents()
        {
            // 扫描所有控件
            /*foreach (Control ctrl in GetAllControls(this))
            {
                // 处理按钮类控件
                if (ctrl is Button btn)
                {
                    ProcessButtonClick(btn);
                }
                // 可扩展其他控件类型...
            }*/
            
            
            // foreach (Control ctrl in this.Controls)
            foreach (Control ctrl in GetAllControls(this))
            {
                // 处理按钮类控件
                if (ctrl is Button btn)
                {
                    var clickEvent = btn.GetType().GetEvent("Click");
                    
                    // 获取 Click 事件的静态键（EventClick）
                    FieldInfo eventKeyField = typeof(Control).GetField("EventClick",
                        BindingFlags.Static | BindingFlags.NonPublic);
                    object eventKey = eventKeyField?.GetValue(null);

                    if (eventKey == null) continue;

                    // 获取控件的 EventHandlerList
                    PropertyInfo eventsProperty = typeof(Control).GetProperty("Events",
                        BindingFlags.Instance | BindingFlags.NonPublic);
                    EventHandlerList eventHandlers = (EventHandlerList)eventsProperty?.GetValue(btn);

                    // 获取 Click 事件的委托
                    Delegate clickDelegate = eventHandlers?[eventKey];
                    if (clickDelegate != null)
                    {
                        IEnumerable<Delegate> handlers = clickDelegate.GetInvocationList().ToList();
                        /*foreach (Delegate handler in clickDelegate.GetInvocationList())
                        {
                            var invocationList = handler.GetInvocationList();
                            /*MethodInfo method = handler.Method;
                            Console.WriteLine($"方法名: {method.Name}, 类型: {method.DeclaringType}");#1#
                        }*/
                        foreach (var handler in handlers)
                        {
                            var methodInfo = handler.GetMethodInfo();
                            //判断当前控件是否具有权限检查
                            var permAttr = methodInfo.GetCustomAttribute<PermissionRequiredAttribute>();

                            if (permAttr != null)
                            {
                                // 创建安全代理委托
                                var securedHandler = CreateSecuredHandler(handler, permAttr);
                
                                // 替换原有委托
                                clickEvent.RemoveEventHandler(btn, handler);
                                clickEvent.AddEventHandler(btn, securedHandler);
                                _originalHandlers[securedHandler] = handler;
                            }
                        }
                        
                    }
                    /*else
                    {
                        Console.WriteLine("没有获取到委托");
                    }*/
                }
            }
            
            
            
            
        }

        //处理按钮点击事件
        private void ProcessButtonClick(Button btn)
        {
            
            var clickEvent = btn.GetType().GetEvent("Click");
            //获取到当前控件的订阅的事件
            var handlers = GetEventSubscriptions(btn, clickEvent);

            foreach (var handler in handlers)
            {
                var methodInfo = handler.GetMethodInfo();
                //判断当前控件是否具有权限检查
                var permAttr = methodInfo.GetCustomAttribute<PermissionRequiredAttribute>();

                if (permAttr != null)
                {
                    // 创建安全代理委托
                    var securedHandler = CreateSecuredHandler(handler, permAttr);
                
                    // 替换原有委托
                    clickEvent.RemoveEventHandler(btn, handler);
                    clickEvent.AddEventHandler(btn, securedHandler);
                    _originalHandlers[securedHandler] = handler;
                }
            }
        }

        private Delegate CreateSecuredHandler(Delegate original, PermissionRequiredAttribute attr)
        {
            // 创建带权限检查的委托
            return (EventHandler)delegate (object sender, EventArgs e)
            {
                if (CheckPermission(attr.PermissionId.ToArray()))
                {
                    original.DynamicInvoke(sender, e);
                }
                else
                {
                    HandleUnauthorized();
                }
            };
        }

        private bool CheckPermission(int[] code)
        {
            foreach (var c in code)
            {
                if (GlobalContext.CurrentUser == null ||!GlobalContext.CurrentUser.HasPermission(c)) return false;
            }

            return true;
        }

        private void HandleUnauthorized()
        {
            MessageBox.Show(@"操作未被授权！", @"权限不足", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private IEnumerable<Control> GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                foreach (Control child in GetAllControls(c))
                {
                    yield return child;
                }
                yield return c;
            }
        }

        //获取当前控件的订阅的事件
        private IEnumerable<Delegate> GetEventSubscriptions(object component, EventInfo eventInfo)
        {
            
            var field = component.GetType().GetField(eventInfo.Name, 
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField);

            if (field?.GetValue(component) is Delegate del)
            {
                return del.GetInvocationList();
            }
            return Enumerable.Empty<Delegate>();
        }
    }
}