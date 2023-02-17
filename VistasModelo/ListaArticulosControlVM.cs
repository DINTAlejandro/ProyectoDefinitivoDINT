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
    public class ListaArticulosControlVM : ObservableRecipient
    {

        //Propiedades
        private Articulo articuloActual;

        public Articulo ArticuloActual
        {
            get { return articuloActual; }
            set { SetProperty(ref articuloActual, value); }
        }

        private ObservableCollection<Articulo> articulos;

        public ObservableCollection<Articulo> Articulos
        {
            get { return articulos; }
            set { SetProperty(ref articulos, value); }
        }

        //Comandos
        public RelayCommand PublicarArticuloCommand { get; }
        public RelayCommand EliminarArticuloCommand { get; }
        public RelayCommand VerArticuloCommand { get; }
        public RelayCommand NuevoArticuloCommnad { get; }

        //Servicios
        private AbrirVentanaServicio abrirVentanaServicio;
        private ServicioBD bbddServicio;
        private ServicioPdf servicioPdf;
        private ServicioAzure servicioAzure;

        public ListaArticulosControlVM()
        {
            //Mensajería
            WeakReferenceMessenger.Default.Register<ListaArticulosControlVM, ArticuloRequestMessage>
                (this, (r, m) =>
                {
                    m.Reply(ArticuloActual);
                }
            );

            //Servícios
            abrirVentanaServicio = new AbrirVentanaServicio();
            bbddServicio = new ServicioBD();
            servicioPdf = new ServicioPdf();
            servicioAzure = new ServicioAzure();

            //Propiedades
            ArticuloActual = null;
            Articulos = new ObservableCollection<Articulo>();

            //Comandos
            PublicarArticuloCommand = new RelayCommand(PublicarArticulo);
            EliminarArticuloCommand = new RelayCommand(EliminarArticulo);
            VerArticuloCommand = new RelayCommand(VerArticulo);
            NuevoArticuloCommnad = new RelayCommand(NuevoArticulo);


            //
            Articulos = bbddServicio.GetArticulos();
        }

        //public ObservableCollection<Articulo> PilaArticulos()
        //{
        //    ObservableCollection<Articulo> ejemploAutores = new ObservableCollection<Articulo>();
        //    ejemploAutores.Add(new Articulo("Articulo 1", null, "Artúclo de prueba", "Sección 1", new Autor("Pepe", "@Pepito", "", "Twitter", null), true));
        //    ejemploAutores.Add(new Articulo("Articulo 2", null, "Artúclo de prueba", "Sección 2", new Autor("Juan", "@Juanito", "", "Instagram", null), false));
        //    ejemploAutores.Add(new Articulo("Articulo 3", null, "Artúclo de prueba", "Sección 3", new Autor("Luis", "@Luisito", "", "Facebook", null), true));

        //    return ejemploAutores;
        //}

        //Funciones comandos
        public void PublicarArticulo()
        {
            if(ArticuloActual != null)
            {
                ArticuloActual.Autor.Image = servicioAzure.SubirFoto(ArticuloActual.Autor.Image);
                ArticuloActual.Imagen = servicioAzure.SubirFoto(ArticuloActual.Imagen);
                ArticuloActual.Pdf = servicioPdf.GenerarPDF(ArticuloActual);
                ArticuloActual.Pdf = servicioAzure.SubirPdf(ArticuloActual.Pdf);
            }
        }

        public void EliminarArticulo()
        {
            //Remove consulta
            bbddServicio.DeleteArticulo(ArticuloActual);
        }

        public void VerArticulo()
        {
            abrirVentanaServicio.AbrirVerArticulo();
        }

        public void NuevoArticulo()
        {
            abrirVentanaServicio.AbrirCrearArticulo();
            Articulos = bbddServicio.GetArticulos();
        }
    }
}
