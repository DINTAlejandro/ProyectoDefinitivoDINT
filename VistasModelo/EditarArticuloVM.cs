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
    public class EditarArticuloVM : ObservableRecipient
    {
        //Propiedades
        private Articulo articuloActual;
        public Articulo ArticuloActual
        {
            get { return articuloActual; }
            set { SetProperty(ref articuloActual, value); }
        }

        private ObservableCollection<string> categorias;
        public ObservableCollection<string> Categorias
        {
            get { return categorias; }
            set { SetProperty(ref categorias, value); }
        }


        //Servicios
        private CargarCategoriasServicio cargarCategoriasServicio;


        //Comandos
        public RelayCommand AceptarCommand { get; }
        public RelayCommand SeleccionarImagenCommand { get; }

        public EditarArticuloVM()
        {
            //Servicios
            cargarCategoriasServicio = new CargarCategoriasServicio();

            //Comandos
            AceptarCommand = new RelayCommand(Aceptar);
            SeleccionarImagenCommand = new RelayCommand(SeleccionarImagenAutor);

            //Propiedades
            Categorias = cargarCategoriasServicio.CargarCategorias();
            ArticuloActual = WeakReferenceMessenger.Default.Send<ArticuloRequestMessage>();
        }

        public void Aceptar()
        {
            
        }
        public void SeleccionarImagenAutor()
        {
            AbrirImagenesServicio servicioAbrir = new AbrirImagenesServicio();
            ArticuloActual.Imagen = servicioAbrir.ObtenerImagen();
        }

    }
}
