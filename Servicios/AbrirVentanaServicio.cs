using ProyectoDefinitivoDINT.Ventanas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.Mensajes
{
    class AbrirVentanaServicio
    {
        public bool? AbrirEditarAutor()
        {
            EditarAutorVentana nuevaVentana = new EditarAutorVentana();
            return nuevaVentana.ShowDialog();
        }

        public bool? AbrirCrearAutor()
        {
            NuevoAutorVentana nuevaVentana = new NuevoAutorVentana();
            return nuevaVentana.ShowDialog();
        }

        public bool? AbrirVerAutor()
        {
            VerAutorVentana nuevaVentana = new VerAutorVentana();
            return nuevaVentana.ShowDialog();
        }

        internal bool? AbrirEditarArticulo()
        {
            EditarArticuloVentana nuevaVentana = new EditarArticuloVentana();
            return nuevaVentana.ShowDialog();
        }

        internal bool? AbrirVerArticulo()
        {
            VerArticuloVentana nuevaVentana = new VerArticuloVentana();
            return nuevaVentana.ShowDialog();
        }

        internal bool? AbrirCrearArticulo()
        {
            NuevoArticuloVentana nuevaVentana = new NuevoArticuloVentana();
            return nuevaVentana.ShowDialog();
        }
    }
}
