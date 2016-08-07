using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;

namespace HostServicioSimpleWorld
{
    public partial class HostServicioSimpleWorld : ServiceBase
    {
        private ServiceHost m_svcHost = null;

        public HostServicioSimpleWorld()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (m_svcHost != null) m_svcHost.Close();

            string strAdrHTTP = "http://localhost:9001/CalcService";
            string strAdrTCP = "net.tcp://localhost:9002/CalcService";

            Uri[] adrbase = { new Uri(strAdrHTTP), new Uri(strAdrTCP) };
            m_svcHost = new ServiceHost(typeof(ServicioSimpleWorld.ServicioSimpleWorld), adrbase);

            ServiceMetadataBehavior mBehave = new ServiceMetadataBehavior();
            m_svcHost.Description.Behaviors.Add(mBehave);

            BasicHttpBinding httpb = new BasicHttpBinding();
            m_svcHost.AddServiceEndpoint(typeof(ServicioSimpleWorld.IServicioSimpleWorld), httpb, strAdrHTTP);
            m_svcHost.AddServiceEndpoint(typeof(IMetadataExchange),
            MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            NetTcpBinding tcpb = new NetTcpBinding();
            m_svcHost.AddServiceEndpoint(typeof(ServicioSimpleWorld.IServicioSimpleWorld), tcpb, strAdrTCP);
            m_svcHost.AddServiceEndpoint(typeof(IMetadataExchange),
            MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

            m_svcHost.Open();
        }

        protected override void OnStop()
        {
            if (m_svcHost != null)
            {
                m_svcHost.Close();
                m_svcHost = null;
            }
        }
    }
}
