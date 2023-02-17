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
        private UserControl listaArticulos;
        private UserControl listaAutores;

        public CargarControlServicio() {
            listaAutores = new ListaAutoresControl();
            listaArticulos = new ListaArticulosControl();
        }

        public UserControl ListaAutores()
        {
            return listaAutores;
        }

        public UserControl ListaArticulos()
        {
            return listaArticulos;
        }
    }
}
