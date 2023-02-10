using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.Servicios
{
    class CargarRedesSocialesServicio
    {
        public ObservableCollection<string> CargarRedesSociales()
        {
            ObservableCollection<string> nuevaListaRedesSociales = new ObservableCollection<string>();
            nuevaListaRedesSociales.Add("Twitter");
            nuevaListaRedesSociales.Add("Instagram");
            nuevaListaRedesSociales.Add("Facebook");

            return nuevaListaRedesSociales;
        }
    }
}
