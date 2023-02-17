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
    public class EditarAutorVM : ObservableRecipient
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
        private CargarRedesSocialesServicio cargarRedesSocialesServicio;
        private ServicioBD bbddServicio;
        private ControlErroresServicio controlErroresServicio;


        //Comandos
        public RelayCommand SeleccionarImagenCommand { get; }
        public RelayCommand AceptarCommand{ get; }

        public EditarAutorVM()
        {
            //Servicios
            cargarRedesSocialesServicio = new CargarRedesSocialesServicio();
            bbddServicio = new ServicioBD();
            controlErroresServicio = new ControlErroresServicio();

            //Comandos
            SeleccionarImagenCommand = new RelayCommand(SeleccionarImagenAutor);
            AceptarCommand = new RelayCommand(Aceptar);

            //Propiedades
            ListaRedesSociales = cargarRedesSocialesServicio.CargarRedesSociales();
            AutorActual = WeakReferenceMessenger.Default.Send<AutorRequestMessage>();
        }

        public void SeleccionarImagenAutor()
        {
            AbrirImagenesServicio servicioAbrir = new AbrirImagenesServicio();
            AutorActual.Image = servicioAbrir.ObtenerImagen();
        }

        public void Aceptar()
        {
            if (AutorActual.Nombre == "" || AutorActual.Nickname == "" || AutorActual.ImagenRedSocial == "" || AutorActual.Image == "")
                controlErroresServicio.ErrorCamposVacios();
            else
                bbddServicio.UpdateAutor(AutorActual);
        }
    }
}
