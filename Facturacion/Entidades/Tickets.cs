using System;

namespace Entidades
{
    public class Tickets
    {
        public string Codigo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Cliente { get; set; }
        public string DescripcionSolicitud { get; set; }
        public string DescripcionRespuesta { get; set; }
        public decimal precio { get; set; }
        public decimal impuesto { get; set; }
        public decimal descuento { get; set; }
        public decimal total { get; set; }
        public byte[] Foto { get; set; }

        public Tickets()
        {
        }

        public Tickets(string codigo, DateTime fechaCreacion, string cliente, string descripcionSolicitud, string descripcionRespuesta, decimal precio, decimal impuesto, decimal descuento, decimal total, byte[] foto)
        {
            Codigo = codigo;
            FechaCreacion = fechaCreacion;
            Cliente = cliente;
            DescripcionSolicitud = descripcionSolicitud;
            DescripcionRespuesta = descripcionRespuesta;
            this.precio = precio;
            this.impuesto = impuesto;
            this.descuento = descuento;
            this.total = total;
            Foto = foto;
        }
    }








}


