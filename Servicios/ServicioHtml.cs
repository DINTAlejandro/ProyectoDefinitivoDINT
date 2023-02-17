using ProyectoDefinitivoDINT.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.Servicios
{
    class ServicioHtml
    {
        public void GenerarHTML(ObservableCollection<Articulo> articulos)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<html><head><title>Artículos</title></head><body>");

            var secciones = articulos.GroupBy(a => a.Seccion);
            foreach (var seccion in secciones)
            {
                html.AppendLine($"<h1>Sección: {seccion.Key}</h1>");
                foreach (var articulo in seccion)
                {
                    html.AppendLine($"<h2><a href='{articulo.Pdf}'>{articulo.Titulo}</a></h2>");
                    html.AppendLine($"<p>{articulo.Texto}</p>");
                }
            }

            html.AppendLine("</body></html>");
            System.IO.File.WriteAllText("articulos.html", html.ToString());
        }
    }
}
