using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProyectoDefinitivoDINT.Clases;
using ProyectoDefinitivoDINT.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.VistasModelo
{
    public class NuevoArticuloVM : ObservableRecipient
    {
        //Propiedades
        private Articulo articuloActual;
        public Articulo ArticuloActual
        {
            get { return articuloActual; }
            set { SetProperty(ref articuloActual, value); }
        }

        private ObservableCollection<string> listaCategorias;
        public ObservableCollection<string> ListaCategorias
        {
            get { return listaCategorias; }
            set { SetProperty(ref listaCategorias, value); }
        }

        private ObservableCollection<Autor> listaAutores;
        public ObservableCollection<Autor> ListaAutores
        {
            get { return listaAutores; }
            set { SetProperty(ref listaAutores, value); }
        }


        //Servicios
        private CargarCategoriasServicio cargarCategoriasServicio;
        private ServicioBD bbddServicio;

        //Comandos
        public RelayCommand AceptarCommand { get; }
        
        public RelayCommand SeleccionarImagenCommand { get; }

        public NuevoArticuloVM()
        {
            //Servicios
            cargarCategoriasServicio = new CargarCategoriasServicio();
            bbddServicio = new ServicioBD();

            //Comandos
            AceptarCommand = new RelayCommand(Aceptar);
            SeleccionarImagenCommand = new RelayCommand(SeleccionarImagenAutor);

            //Propiedades
            ArticuloActual = new Articulo();
            ListaCategorias = cargarCategoriasServicio.CargarCategorias();
            ListaAutores = bbddServicio.GetAutors();


        }

        public void Aceptar()
        {
            bbddServicio.InsertArticles(ArticuloActual);
        }
        public void SeleccionarImagenAutor()
        {
            AbrirImagenesServicio servicioAbrir = new AbrirImagenesServicio();
            ArticuloActual.Imagen = servicioAbrir.ObtenerImagen();
        }

    }
}
