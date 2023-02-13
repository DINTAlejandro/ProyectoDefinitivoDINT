using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using ProyectoDefinitivoDINT.Clases;
using ProyectoDefinitivoDINT.Mensajes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.VistasModelo
{
    public class ListaAutoresControlVM : ObservableObject
    {
        //Propiedades
        private Autor autorActual;

        public Autor AutorActual
        {
            get { return autorActual; }
            set { SetProperty(ref autorActual, value); }
        }

        private ObservableCollection<Autor> autores;

        public ObservableCollection<Autor> Autores
        {
            get { return autores; }
            set { SetProperty(ref autores, value); }
        }

        //Comandos
        public RelayCommand EditarAutorCommand { get; }
        public RelayCommand EliminarAutorCommand { get; }
        public RelayCommand VerAutorCommand { get; }
        public RelayCommand NuevoAutorCommnad { get; }

        //Servicios
        private AbrirVentanaServicio abrirVentanaServicio;
        private ServicioBD bbddServicio;

        public ListaAutoresControlVM()
        {
            //Servicios
            abrirVentanaServicio = new AbrirVentanaServicio();
            bbddServicio = new ServicioBD();

            //Mensajería
            WeakReferenceMessenger.Default.Register<ListaAutoresControlVM, AutorRequestMessage>
                (this, (r, m) =>
                {
                    m.Reply(AutorActual);
                }
            );

            //Comandos
            EditarAutorCommand = new RelayCommand(EditarAutor);
            EliminarAutorCommand = new RelayCommand(EliminarAutor);
            VerAutorCommand = new RelayCommand(VerAutor);
            NuevoAutorCommnad = new RelayCommand(NuevoAutor);

            //Propiedades
            AutorActual = null;
            Autores = new ObservableCollection<Autor>();
            Autores = bbddServicio.GetAutors();

        }

        //Funciones comandos
        public void EditarAutor()
        {
            abrirVentanaServicio.AbrirEditarAutor();
            Autores = bbddServicio.GetAutors();
        }

        public void EliminarAutor()
        {
            //Remove consulta
            bbddServicio.DeleteAutor(AutorActual);
            Autores = bbddServicio.GetAutors();
        }

        public void VerAutor()
        {
            abrirVentanaServicio.AbrirVerAutor();
        }

        public void NuevoAutor()
        {
            abrirVentanaServicio.AbrirCrearAutor();
            Autores = bbddServicio.GetAutors();
        }
    }
}
