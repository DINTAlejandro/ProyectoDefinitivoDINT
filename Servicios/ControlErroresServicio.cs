using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoDefinitivoDINT.Servicios
{
    class ControlErroresServicio
    {
        public ControlErroresServicio() { }

        public void ErrorCamposVacios()
        {
            MessageBox.Show("Error campos vacíos...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
