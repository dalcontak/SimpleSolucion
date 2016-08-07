using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace HostServicioSimpleWorld
{
    [RunInstaller(true)]
    public partial class ServicioSimpleWorldInstaller : System.Configuration.Install.Installer
    {
        //private ServicioSimpleWorldInstaller serviceProcessInstaller1;

        public ServicioSimpleWorldInstaller()
        {
            //InitializeComponent();
            serviceProcessInstaller1 = new ServiceProcessInstaller {Account = ServiceAccount.LocalSystem};
            serviceInstaller1 = new ServiceInstaller
            {
                ServiceName = "WinSvcHostedCalcService",
                DisplayName = "WinSvcHostedCalcService",
                Description = "WCF Calc Service Hosted by Windows NT Service",
                StartType = ServiceStartMode.Automatic
            };
            Installers.Add(serviceProcessInstaller1);
            Installers.Add(serviceInstaller1);
        }
    }
}
