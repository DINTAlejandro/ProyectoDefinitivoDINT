using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.VistasModelo
{
    class NuevaCategoriaVM : ObservableObject
    {
        private string categoria;

        public string Categoria
        {
            get { return categoria; }
            set { SetProperty(ref categoria, value); }
        }

        public NuevaCategoriaVM()
        {

        }
    }
}
