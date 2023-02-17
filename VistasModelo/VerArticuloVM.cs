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
    public class VerArticuloVM : ObservableRecipient
    {
        //Propiedades
        private Articulo articuloActual;
        public Articulo ArticuloActual
        {
            get { return articuloActual; }
            set { SetProperty(ref articuloActual, value); }
        }

        private ObservableCollection<string> categorias;
        public ObservableCollection<string> Categorias
        {
            get { return categorias; }
            set { SetProperty(ref categorias, value); }
        }


        //Servicios
        

        public VerArticuloVM()
        {
            //Servicios

            //Propiedades
            ArticuloActual = WeakReferenceMessenger.Default.Send<ArticuloRequestMessage>();
        }
    }
}
