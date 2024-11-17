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
        
        // ��ȡ ClassIsland Ӧ�ó���ʵ��
        var app = AppBase.Current;

        Console.WriteLine("UACHelper��ʼ����");
        /*
         * ��ǰ�û��ǹ���Ա��ʱ��ֱ������Ӧ�ó���
         * ������ǹ���Ա����ʹ��������������������ȷ��ʹ�ù���Ա�������
         */

        // ��õ�ǰ��¼��Windows�û���ʾ
        System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();

        System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);

        if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
        {
            //����ǹ���Ա����ֱ������
            Console.WriteLine("UACHelper��⵽���ǹ���Ա");
            return;
        }
        else
        {
            Console.WriteLine("UACHelper��ʼ����");
            
            // ������������
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
            startInfo.Arguments = "-m";
            //������������,ȷ���Թ���Ա�������
            startInfo.Verb = "runas";
            
            
            System.Diagnostics.Process.Start(startInfo);
            app.Stop();
            //�˳�

        }
        Console.WriteLine("UACHelper����");
    }

    

}