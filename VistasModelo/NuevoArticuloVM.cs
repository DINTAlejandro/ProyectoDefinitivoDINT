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
        
        private string nickNameActual;
        public string NickNameActual
        {
            get { return nickNameActual; }
            set { SetProperty(ref nickNameActual, value); }
        }
        private ObservableCollection<string> listaCategorias;
        public ObservableCollection<string> ListaCategorias
        {
            get { return listaCategorias; }
            set { SetProperty(ref listaCategorias, value); }
        }

        private ObservableCollection<Autor> listaAutores;

        private ObservableCollection<string> listaAutoresNickname;
        public ObservableCollection<string> ListaAutoresNickname
        {
            get { return listaAutoresNickname; }
            set { SetProperty(ref listaAutoresNickname, value); }
        }


        //Servicios
        private CargarCategoriasServicio cargarCategoriasServicio;
        private ServicioBD bbddServicio;

        //Comandos
        public RelayCommand AceptarCommand { get; }
        
        public RelayCommand SeleccionarImagenCommand { get; }
        public RelayCommand NuevaSeccionCommand { get; }

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
            ListaCategorias = bbddServicio.GetSecciones();
            listaAutores = bbddServicio.GetAutors();
            ListaAutoresNickname = new ObservableCollection<string>();

            foreach(Autor a in listaAutores)
            {
                ListaAutoresNickname.Add(a.Nickname);
            }
        }

        public void Aceptar()
        {
            ArticuloActual.Pdf = "";
            ArticuloActual.Autor = bbddServicio.GetAutorByNickname(NickNameActual);
            bbddServicio.InsertArticles(ArticuloActual);
        }

        public void NuevaSeccion()
        {

        }

        public void SeleccionarImagenAutor()
        {
            AbrirImagenesServicio servicioAbrir = new AbrirImagenesServicio();
            ArticuloActual.Imagen = servicioAbrir.ObtenerImagen();
        }

    }
}
