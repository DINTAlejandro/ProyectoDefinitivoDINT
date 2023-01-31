using Microsoft.Toolkit.Mvvm.ComponentModel;
using ProyectoDefinitivoDINT.Controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoDefinitivoDINT.VistasModelo
{
    class MainWindowVM : ObservableObject
    {
        private Control vistaActual;

        
        public Control VistaActual
        {
            get { return vistaActual; }
            set { SetProperty(ref vistaActual, value); }
        }

        public MainWindowVM()
        {
            VistaActual = ListaAutoresControl();
        }
    }
}
