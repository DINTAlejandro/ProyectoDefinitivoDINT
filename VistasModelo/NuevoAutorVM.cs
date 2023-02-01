using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProyectoDefinitivoDINT.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.VistasModelo
{
    class NuevoAutorVM : ObservableObject
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
        CargarRedesSocialesServicio cargarRedesSocialesServicio;

        //Comandos
        public RelayCommand SeleccionarImagenCommand { get; }

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

            //Comandos
            SeleccionarImagenCommand = new RelayCommand(SeleccionarImagenAutor);

            //Propiedades
            ListaRedesSociales = cargarRedesSocialesServicio.CargarRedesSociales();
        }

        public void SeleccionarImagenAutor()
        {
            AbrirImagenesServicio servicioAbrir = new AbrirImagenesServicio();
            Imagen = servicioAbrir.ObtenerImagen();
        }


    }
}
