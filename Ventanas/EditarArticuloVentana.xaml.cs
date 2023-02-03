using ProyectoDefinitivoDINT.VistasModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoDefinitivoDINT.Ventanas
{
    /// <summary>
    /// Lógica de interacción para EditarArticuloVentana.xaml
    /// </summary>
    public partial class EditarArticuloVentana : Window
    {
        private EditarArticuloVM vm;
        public EditarArticuloVentana()
        {
            InitializeComponent();
            vm = new EditarArticuloVM();
            this.DataContext = vm;
        }
    }
}
