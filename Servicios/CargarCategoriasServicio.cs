using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.Servicios
{
    class CargarCategoriasServicio
    {
        public ObservableCollection<string> CargarCategorias()
        {
            ObservableCollection<string> nuevaListaCategorias = new ObservableCollection<string>();
            nuevaListaCategorias.Add("Categoría 1");
            nuevaListaCategorias.Add("Categoría 2");
            nuevaListaCategorias.Add("Categoría 3");

            return nuevaListaCategorias;
        }
    }
}
