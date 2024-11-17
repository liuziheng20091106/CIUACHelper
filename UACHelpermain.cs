using ClassIsland.Core;
using ClassIsland.Core.Abstractions;
using ClassIsland.Core.Abstractions.Services;
using ClassIsland.Core.Attributes;
using ClassIsland.Core.Controls.CommonDialog;
using ClassIsland.Core.Services;
using ClassIsland.Shared.IPC.Protobuf.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Windows;

namespace uachelper;

[PluginEntrance]
public class Plugin : PluginBase
{
    public override void Initialize(HostBuilderContext context, IServiceCollection services)
    {
        
        // 获取 ClassIsland 应用程序实例
        var app = AppBase.Current;

        Console.WriteLine("UACHelper开始加载");
        /*
         * 当前用户是管理员的时候，直接启动应用程序
         * 如果不是管理员，则使用启动对象启动程序，以确保使用管理员身份运行
         */

        // 获得当前登录的Windows用户标示
        System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();

        System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);

        if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
        {
            //如果是管理员，则直接运行
            Console.WriteLine("UACHelper检测到已是管理员");
            return;
        }
        else
        {
            Console.WriteLine("UACHelper开始工作");
            
            // 创建启动对象
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
            startInfo.Arguments = "-m";
            //设置启动动作,确保以管理员身份运行
            startInfo.Verb = "runas";
            
            
            System.Diagnostics.Process.Start(startInfo);
            app.Stop();
            //退出

        }
        Console.WriteLine("UACHelper结束");
    }

    

}