using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProyectoDefinitivoDINT.Controles;
using ProyectoDefinitivoDINT.Servicios;
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
        //Propiedades
        private Control vistaActual;

        
        public Control VistaActual
        {
            get { return vistaActual; }
            set { SetProperty(ref vistaActual, value); }
        }

        //Servicios
        private CargarControlServicio cargarControlServicio;

        //Comandos
        public RelayCommand VistaAutoresCommand{ get; }
        public RelayCommand VistaArticulosCommand { get; }

        public MainWindowVM()
        {
            //Comandos
            VistaArticulosCommand = new RelayCommand(VistaArticulos);
            VistaAutoresCommand = new RelayCommand(VistaAutores);

            //Servicios
            cargarControlServicio = new CargarControlServicio();

            VistaActual = cargarControlServicio.ListaAutores();

        }

        private void VistaAutores()
        {
            VistaActual = cargarControlServicio.ListaAutores();
        }

        private void VistaArticulos()
        {
            VistaActual = cargarControlServicio.ListaArticulos();
        }

    }
}
