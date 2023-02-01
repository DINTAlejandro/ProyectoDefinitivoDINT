using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using ProyectoDefinitivoDINT.Clases;
using ProyectoDefinitivoDINT.Mensajes;
using ProyectoDefinitivoDINT.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.VistasModelo
{
    class EditarAutorVM : ObservableRecipient
    {
        //Propiedades
        private Autor autorActual;
        public Autor AutorActual
        {
            get { return autorActual; }
            set { SetProperty(ref autorActual, value); }
        }

        private ObservableCollection<string> listaRedesSociales;
        public ObservableCollection<string> ListaRedesSociales
        {
            get { return listaRedesSociales; }
            set { SetProperty(ref listaRedesSociales, value); }
        }

        //Servicios
        CargarRedesSocialesServicio cargarRedesSocialesServicio;
        
        
        //Comandos
        public RelayCommand SeleccionarImagenCommand { get; }
        
        public EditarAutorVM()
        {
            //Servicios
            cargarRedesSocialesServicio = new CargarRedesSocialesServicio();

            //Comandos
            SeleccionarImagenCommand = new RelayCommand(SeleccionarImagenAutor);

            //Propiedades
            ListaRedesSociales = cargarRedesSocialesServicio.CargarRedesSociales();
            AutorActual = WeakReferenceMessenger.Default.Send<AutorRequestMessage>();
        }

        public void SeleccionarImagenAutor()
        {
            AbrirImagenesServicio servicioAbrir = new AbrirImagenesServicio();
            AutorActual.Image = servicioAbrir.ObtenerImagen();
        }
    }
}
