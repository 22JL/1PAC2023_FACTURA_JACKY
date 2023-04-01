using System;

namespace Entidades
{
    public class Tickets
    {
        public int CodigoTicket { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Cliente { get; set; }
        public string TipoSoporte { get; set; }
        public string DescripcionSolicitud { get; set; }
        public string DescripcionRespuesta { get; set; }
        public decimal Precio { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }


        public Tickets()
        {
        }

        public Tickets(int codigoTicket, DateTime fechaCreacion, string cliente, string tipoSoporte, string descripcionSolicitud, string descripcionRespuesta, decimal precio, decimal impuesto, decimal descuento, decimal total)
        {
            CodigoTicket = codigoTicket;
            FechaCreacion = fechaCreacion;
            Cliente = cliente;
            TipoSoporte = tipoSoporte;
            DescripcionSolicitud = descripcionSolicitud;
            DescripcionRespuesta = descripcionRespuesta;
            Precio = precio;
            Impuesto = impuesto;
            Descuento = descuento;
            Total = total;
        }
    }








}


