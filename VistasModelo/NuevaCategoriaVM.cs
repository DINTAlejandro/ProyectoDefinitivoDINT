using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.VistasModelo
{
    class NuevaCategoriaVM : ObservableObject
    {
        //Servicios
        private ServicioBD bbddServicio;

        //Propiedades
        private string categoria;

        public string Categoria
        {
            get { return categoria; }
            set { SetProperty(ref categoria, value); }
        }

        //Commands
        public RelayCommand AddCommand { get; }

        public NuevaCategoriaVM()
        {
            //Command
            AddCommand = new RelayCommand(Aceptar);

            //Servicios
            bbddServicio = new ServicioBD();
        }

        public void Aceptar()
        {
            if(Categoria != "")
                bbddServicio.InsertSecciones(Categoria);
            
        }
    }
}
