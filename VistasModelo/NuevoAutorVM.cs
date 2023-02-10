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
    public class NuevoAutorVM : ObservableObject
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }

        private string nickname;
        public string Nickname
        {
            get { return nickname; }
            set { SetProperty(ref nickname, value); }
        }

        private string redSocial;
        public string RedSocial
        {
            get { return redSocial; }
            set { SetProperty(ref redSocial, value); }
        }

        private string imagen;
        public string Imagen
        {
            get { return imagen; }
            set { SetProperty(ref imagen, value); }
        }

        //Servicios
        private CargarRedesSocialesServicio cargarRedesSocialesServicio;
        private ControlErroresServicio controlErroresServicio;

        //Comandos
        public RelayCommand SeleccionarImagenCommand { get; }
        public RelayCommand AceptarCommand { get; }

        private ObservableCollection<string> listaRedesSociales;
        public ObservableCollection<string> ListaRedesSociales
        {
            get { return listaRedesSociales; }
            set { SetProperty(ref listaRedesSociales, value); }
        }

        public NuevoAutorVM()
        {
            //Servicios
            cargarRedesSocialesServicio = new CargarRedesSocialesServicio();
            controlErroresServicio = new ControlErroresServicio();

            //Comandos
            SeleccionarImagenCommand = new RelayCommand(SeleccionarImagenAutor);
            AceptarCommand = new RelayCommand(ErrorVacio);

            //Propiedades
            ListaRedesSociales = cargarRedesSocialesServicio.CargarRedesSociales();
            //Mensajería
            //WeakReferenceMessenger.Default.Register<NuevoAutorVM, AutorRequestMessage>
            //    (this, (r, m) =>
            //    {
            //        m.Reply(new Autor(Nombre, Nickname, Imagen, RedSocial));
            //    }
            //);
        }

        public void SeleccionarImagenAutor()
        {
            AbrirImagenesServicio servicioAbrir = new AbrirImagenesServicio();
            Imagen = servicioAbrir.ObtenerImagen();
        }

        public void ErrorVacio()
        {
            if(Nombre == "" || Nickname == "" || RedSocial == "" || Imagen == "")
                controlErroresServicio.ErrorCamposVacios();
        }


    }
}
