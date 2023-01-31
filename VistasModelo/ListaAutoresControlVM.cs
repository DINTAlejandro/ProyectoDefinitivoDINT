using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProyectoDefinitivoDINT.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.VistasModelo
{
    class ListaAutoresControlVM : ObservableObject
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
        RelayCommand editarAutorCommand;
        RelayCommand eliminarAutorCommand;
        RelayCommand verAutorCommnad;

        public ListaAutoresControlVM()
        {
            //Propiedades
            AutorActual = null;
            Autores = new ObservableCollection<Autor>();

            //Comandos
            editarAutorCommand = new RelayCommand(EditarAutor);
            eliminarAutorCommand = new RelayCommand(EliminarAutor);
            verAutorCommnad = new RelayCommand(VerAutor);

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

        }

        public void EliminarAutor()
        {

        }

        public void VerAutor()
        {

        }
    }
}
