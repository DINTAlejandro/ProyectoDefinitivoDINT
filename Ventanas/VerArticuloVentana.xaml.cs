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
    public partial class VerArticuloVentana : Window
    {
        private VerArticuloVM vm;
        public VerArticuloVentana()
        {
            InitializeComponent(); 
            vm = new VerArticuloVM();
            this.DataContext = vm;
        }
    }
}
