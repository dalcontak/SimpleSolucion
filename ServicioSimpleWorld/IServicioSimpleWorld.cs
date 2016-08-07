using System.ServiceModel;

namespace ServicioSimpleWorld
{
    [ServiceContract]
    public interface IServicioSimpleWorld
    {
        [OperationContract]
        string SaludosInicial();
    }
}
