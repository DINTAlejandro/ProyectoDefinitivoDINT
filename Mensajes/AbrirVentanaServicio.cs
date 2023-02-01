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
            NuevoAutorVentana nuevaVentana = new NuevoAutorVentana();
            return nuevaVentana.ShowDialog();
        }
    }
}
