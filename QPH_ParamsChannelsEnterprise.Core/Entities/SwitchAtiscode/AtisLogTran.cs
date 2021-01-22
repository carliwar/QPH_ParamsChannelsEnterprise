using System;

namespace QPH_ParamsChannelsEnterprise.Core.Entities.SwitchAtiscode
{
    public class AtisLogTran
    {
        public long IdLogTran { get; set; }
        public string NumeroDocumento { get; set; }
        public string TramaEntrada { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public string Estado { get; set; }
        public string TramaRespuesta { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Tipo { get; set; }
        public string Secuencial { get; set; }
        public string Canal { get; set; }
        public int TipoSolicitud { get; set; }
    }
}
