using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.VistasModelo
{
    class EditarAutorVM : ObservableRecipient
    {
        private Autor autorActual;
        public Autor AutorActual
        {
            get { return autorActual; }
            set { SetProperty(ref autorActual, value); }
        }

        public EditarAutorVM()
        {

        }
    }
}
