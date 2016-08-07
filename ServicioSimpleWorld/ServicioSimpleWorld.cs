using SimpleWorld;

namespace ServicioSimpleWorld
{
    public class ServicioSimpleWorld : IServicioSimpleWorld
    {
        public string SaludosInicial()
        {
            var logica = new Saludos();

            return logica.HolaMundo();
        }
    }
}
