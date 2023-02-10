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
        private AbrirVentanaServicio abrirVentanaServicio = new AbrirVentanaServicio();

        public ListaAutoresControlVM()
        {
            //Mensajería
            WeakReferenceMessenger.Default.Register<ListaAutoresControlVM, AutorRequestMessage>
                (this, (r, m) =>
                {
                    m.Reply(AutorActual);
                }
            );
            


            //Propiedades
            AutorActual = null;
            Autores = new ObservableCollection<Autor>();

            //Comandos
            EditarAutorCommand = new RelayCommand(EditarAutor);
            EliminarAutorCommand = new RelayCommand(EliminarAutor);
            VerAutorCommand = new RelayCommand(VerAutor);
            NuevoAutorCommnad = new RelayCommand(NuevoAutor);
            

            //
            Autores = PilaAutores();
        }

        public ObservableCollection<Autor> PilaAutores()
        {
            ObservableCollection<Autor> ejemploAutores = new ObservableCollection<Autor>();
            ejemploAutores.Add(new Autor("Pepe", "@Pepito", "", "Twitter", null));
            ejemploAutores.Add(new Autor("Juan", "@Juan", "", "Facebook", null));
            ejemploAutores.Add(new Autor("Ramón", "@Ramón", "", "Instagram", null));

            return ejemploAutores;
        }

        //Funciones comandos
        public void EditarAutor()
        {
            abrirVentanaServicio.AbrirEditarAutor();
        }

        public void EliminarAutor()
        {
            //Remove consulta
            Autores.Remove(AutorActual);
        }

        public void VerAutor()
        {
            abrirVentanaServicio.AbrirVerAutor();
        }

        public void NuevoAutor()
        {
            abrirVentanaServicio.AbrirCrearAutor();
        }
    }
}
