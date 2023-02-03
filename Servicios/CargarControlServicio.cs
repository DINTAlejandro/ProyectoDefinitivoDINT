using ProyectoDefinitivoDINT.Controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoDefinitivoDINT.Servicios
{
    class CargarControlServicio
    {
        public CargarControlServicio() { }

        public UserControl ListaAutores()
        {
            return new ListaAutoresControl();
        }

        public UserControl ListaArticulos()
        {
            return new ListaArticulosControl();
        }
    }
}
